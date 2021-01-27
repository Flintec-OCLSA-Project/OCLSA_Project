using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OCLSA_Project_Version_01.Models;

namespace OCLSA_Project_Version_01
{
    public partial class MainForm : Form
    {
        private readonly ApplicationDbContext _context;

        public List<double> CenterReadings { get; set; } = new List<double>();
        public Dictionary<string, double> CornerReadings { get; set; } = new Dictionary<string, double>();
        private List<Corner> _cornerList = new List<Corner>();

        public double MaximumCenterReading { get; set; }
        public double MaximumUnbalanceReading { get; set; }
        public double MinimumUnbalanceReading { get; set; }
        public double MaximumFsoReading { get; set; }
        public double MinimumFsoReading { get; set; }
        public double CornerTrimValue { get; set; }

        public string LoadCellType { get; set; }

        public double LeftCornerTrimValue { get; set; }
        public double BackCornerTrimValue { get; set; }
        public double RightCornerTrimValue { get; set; }
        public double FrontCornerTrimValue { get; set; }

        public double FrontBackCornerDifferenceInDb { get; set; }
        public double LeftRightCornerDifferenceInDb { get; set; }

        private int _tenSecondsCount = 10;
        private int _fiveSecondsCount = 5;

        public double TrimmedFso { get; set; }
        public double CalculatedFso { get; set; }
        public double FinalFso { get; set; }

        public Stopwatch ProcessDuration { get; set; }

        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }

        public int TrimCount { get; set; }

        public string LoadCellStatus { get; set; }
        public string LoadCellRejectCriteria { get; set; }

        public bool StopTrimming { get; set; }

        public MainForm()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();

            pbLoadCell.Show();
        }

        public MainForm(string fullName, int employeeId, string location, string station, Image image)
        {
            InitializeComponent();

            _context = new ApplicationDbContext();

            pbLoadCell.Show();

            lblOperatorName.Text = fullName;
            lblOperatorId.Text = employeeId.ToString();
            lblLocation.Text = location;
            lblStation.Text = station;
            pbImage.Image = image;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = false;

            try
            {
                if (serialPortVT400.IsOpen)
                {
                    serialPortVT400.Close();
                }
                else
                {
                    serialPortVT400.Open();
                    serialPortVT400.DiscardInBuffer();
                    serialPortVT400.DiscardOutBuffer();
                    initialTimer.Start();
                    stableCheckTimer.Start();
                }
            }
            catch (Exception exception)
            {
                ShowMessage(exception.Message);
            }

        }

        private void tbSerialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(Keys.Return)) return;

            if (tbSerialNumber.Text == "")
            {
                ShowMessage(@"Please Enter the Serial Number...");
                return;
            }

            StartingTime = DateTime.Now;

            var loadCell = CheckLoadCell();

            if (loadCell == null)
            {
                ShowMessage(@"Load cell not found");
                tbSerialNumber.Clear();
                return;
            }

            LoadCellType = loadCell.TypeName;
            
            CheckDisplayCornerTrimValues(loadCell);

            GetMasterData(loadCell);

            DisplayMasterData();

            tbSerialNumber.ReadOnly = true;

            ShowMessage(@"Press Start to continue...");

            btnStart.Enabled = true;
            btnStop.Enabled = true;

            ProcessDuration = Stopwatch.StartNew();
            
        }

        private void CheckDisplayCornerTrimValues(LoadCell loadCell)
        {
            if (loadCell.Type.CornerTrimValue != null && loadCell.Type.CornerTrimValue != 0.0)
            {
                CornerTrimValue = (double)loadCell.Type.CornerTrimValue;

                var trimCornerLabels = new List<Control> {lblLeftCorner, lblBackCorner, lblRightCorner, lblFrontCorner};

                foreach (var cornerLabel in trimCornerLabels)
                {
                    cornerLabel.Text = CornerTrimValue.ToString(CultureInfo.InvariantCulture);
                }
            }
            else
            {
                if (loadCell.Type.LeftCornerTrimValue != null)
                    LeftCornerTrimValue = (double) loadCell.Type.LeftCornerTrimValue;

                if (loadCell.Type.BackCornerTrimValue != null)
                    BackCornerTrimValue = (double) loadCell.Type.BackCornerTrimValue;

                if (loadCell.Type.RightCornerTrimValue != null)
                    RightCornerTrimValue = (double) loadCell.Type.RightCornerTrimValue;

                if (loadCell.Type.FrontCornerTrimValue != null)
                    FrontCornerTrimValue = (double) loadCell.Type.FrontCornerTrimValue;

                DisplayMasterCornerData();
            }
        }

        private void DisplayMasterCornerData()
        {
            lblLeftCorner.Text = LeftCornerTrimValue.ToString(CultureInfo.CurrentCulture);
            lblBackCorner.Text = BackCornerTrimValue.ToString(CultureInfo.CurrentCulture);
            lblRightCorner.Text = RightCornerTrimValue.ToString(CultureInfo.CurrentCulture);
            lblFrontCorner.Text = FrontCornerTrimValue.ToString(CultureInfo.CurrentCulture);
        }

        private void GetMasterData(LoadCell loadCell)
        {
            MaximumCenterReading = loadCell.Type.MaximumCenterValue;
            MaximumUnbalanceReading = loadCell.Type.MaximumUnbalanceValue;
            MinimumUnbalanceReading = loadCell.Type.MinimumUnbalanceValue;
            MaximumFsoReading = loadCell.Type.MaximumFsoValue;
            MinimumFsoReading = loadCell.Type.MinimumFsoValue;

            LeftRightCornerDifferenceInDb = loadCell.Type.LeftRightCornerDifference;
            FrontBackCornerDifferenceInDb = loadCell.Type.FrontBackCornerDifference;
        }

        private void DisplayMasterData()
        {
            lblMaximumCenter.Text = MaximumCenterReading.ToString(CultureInfo.InvariantCulture);
            lblMaximumUnbalance.Text = MaximumUnbalanceReading.ToString(CultureInfo.InvariantCulture);
            lblMinimumUnbalance.Text = MinimumUnbalanceReading.ToString(CultureInfo.InvariantCulture);
            lblMaximumFSO.Text = MaximumFsoReading.ToString(CultureInfo.InvariantCulture);
            lblMinimumFSO.Text = MinimumFsoReading.ToString(CultureInfo.InvariantCulture);
        }

        private void initialTimer_Tick(object sender, EventArgs e)
        {
            WriteCommand("?");

            Thread.Sleep(100);

            var dataReading = Convert.ToString(serialPortVT400.ReadExisting());

            if (dataReading.Split('P').Length > 1)
            {
                lblReading.Text = dataReading.Split('P')[1];
            }

            if (dataReading.Split('T').Length > 1)
            {
                lblReading.Text = dataReading.Split('T')[1];
            }
        }

        private void WriteCommand(string command)
        {
            try
            { 
                serialPortVT400.WriteLine(command);
            }
            catch (Exception error)
            { 
                ShowMessage(error.Message);
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (tbSerialNumber.TextLength <= 0) return;

            if (lblReading.Text.Length > 0)
            {
                lblStable.Text = @"Stable";
            }
            else
            {
                lblStable.Text = @"Not Stable";
                ShowMessage(@"Load Cell is not stable. Please Check Again!!!");
                return;
            }

            if (CheckBridgeUnbalance())
            {
                StopProcessAndExit(@"Load Cell is Rejected due to High Balance...!!!", RejectionCriteria.HighBalance);
                return;
            }

            await Task.Delay(TimeSpan.FromSeconds(1));
            WriteCommand("01");
            
            var currentReading = Math.Abs(Convert.ToDouble(lblReading.Text));

            ShowMessage(@"Keep weight on center");

            TenSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(10));

            if (CheckWeight(currentReading)) return;

            var result = CheckFso();
            var initialFso = result.InitialFso;
            if (result.IsFsoNotOk && result.IsFsoLow)
            {
                StopProcessAndExit(@"Load Cell is rejected due to Low FSO...!!!", RejectionCriteria.LowFso);
                return;
            }

            if (result.IsFsoNotOk && result.IsFsoHigh)
            {
                StopProcessAndExit(@"Load Cell is rejected due to High FSO...!!!", RejectionCriteria.HighFso);
                return;
            }

            tbInitialFSO.Text = initialFso;

            await Task.Delay(TimeSpan.FromSeconds(1));
            WriteCommand("01");

            ShowMessage(@"Move weight to Left Corner...");

            TenSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(10));

            ShowMessage(@"Give exercise to load cell. Rotate the armature...!!!");

            TenSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(10));

            ShowMessage(@"Move weight from Left Corner to Center...");

            TenSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(10));

            WriteCommand("01");

            ShowMessage(@"Remove weight from center & keep on Left Corner...!!!");

            TenSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(10));

            var checkCornerTestMode = CheckCornerTestMode();
            var loadCell = checkCornerTestMode.LoadCell;
            if (checkCornerTestMode.IsLoadCellNotAvailable) return;

            switch (checkCornerTestMode.TestModeInDb)
            {
                case TestMode.CornerTest:
                {
                    await CheckInitialCornerTest(loadCell);

                    for (var i = 0; i < 15; i++)
                    {
                        var oneTrimCycleDuration = Stopwatch.StartNew();

                        ShowMessage(@"Keep weight on the center...");

                        FiveSecondsCounter.Start();
                        await Task.Delay(TimeSpan.FromSeconds(5));
                        ShowMessage(@"Press OK when ready...!!!");

                        await Task.Delay(TimeSpan.FromSeconds(1));
                        WriteCommand("01");

                        ShowMessage(@"Remove weight from center & keep on Left Corner.");

                        FiveSecondsCounter.Start();
                        await Task.Delay(TimeSpan.FromSeconds(5));
                        ShowMessage(@"Press OK when ready...!!!");

                        await GetCornerReadings("Left", tbLeftCorner);
                        await GetCornerReadings("Back", tbBackCorner);
                        await GetCornerReadings("Right", tbRightCorner);
                        await GetCornerReadings("Front", tbFrontCorner);
                        
                        ShowMessage(@"Rotate the armature to left position...");

                        FiveSecondsCounter.Start();
                        await Task.Delay(TimeSpan.FromSeconds(5));

                        ShowMessage(@"Remove the weight from the armature. Keep the weight on center.");

                        FiveSecondsCounter.Start();
                        await Task.Delay(TimeSpan.FromSeconds(5));
                        ShowMessage(@"Press OK when ready...!!!");

                        GetDisplaySaveCenterReadings();

                        await Task.Delay(TimeSpan.FromSeconds(1));
                        WriteCommand("01");

                        if (CheckToTrim())
                        {
                            ShowMessage(@"Corners are OK. No need to trim...!!! Move weight to the left corner.");
                            CornerReadings.Clear();
                            CenterReadings.Clear();
                            ClearCornerReadings();
                            break;
                        }
                        
                        ShowMessage(@"Please remove the weight...");

                        FiveSecondsCounter.Start();
                        await Task.Delay(TimeSpan.FromSeconds(5));

                        ShowMessage($@"Trim the {GetMinimumCornerName()} corner. Look Image...");

                        ShowTrimPosition(GetMinimumCornerName());

                        TenSecondsCounter.Start();
                        await Task.Delay(TimeSpan.FromSeconds(10));

                        ShowMessage(@"Press OK when trimming is completed...");

                        oneTrimCycleDuration.Stop();

                        var timeElapsed = oneTrimCycleDuration.Elapsed.Minutes;

                        DisplayDataTable(timeElapsed);

                        CornerReadings.Clear();
                        CenterReadings.Clear();

                        ShowMessage(@"Press OK to check corners are OK...");

                        ClearCornerReadings();

                        if (i <= 10) continue;
                        StopProcessAndExit(@"Further trimming is useless...!!! Press OK to stop the process.", RejectionCriteria.Unstable);
                        break;
                    }

                    if(StopTrimming) return;

                    tbTrimmedCyclesCount.Text = TrimCount.ToString();

                    await CheckDisplayAllFinalCorners();

                    if(IsCalculatedFsoInRange())
                    {
                        ShowMessage(@"Load Cell is Passed....");

                        LoadCellStatus = Status.Passed.ToString();
                        LoadCellRejectCriteria = ToDescriptionString(RejectionCriteria.No);

                    }
                    else
                    {
                        ShowMessage(@"FSO is high... Add resistors for correction.");

                        //Show solution for adding resistors

                        return;
                    }

                    ProcessDuration.Stop();

                    DisplayFinalFso();

                    DisplayTotalTime();

                    EndingTime = DateTime.Now;

                    SaveFinalDataToDb();

                    ShowMessage(@"Process is completed & Data saved... Press OK to trim a new cell.");

                    ResetMainForm();

                    break;
                }
                
                case TestMode.DiagonalTest:
                    break;

                case TestMode.FullTest:
                    break;

                default:
                    ShowMessage(@"Error in selecting test mode...");
                    break;
            }
        }

        private void StopProcessAndExit(string errorMessage, RejectionCriteria reason)
        {
            ShowMessage(errorMessage);

            LoadCellStatus = Status.Rejected.ToString();
            LoadCellRejectCriteria = ToDescriptionString(reason);

            EndingTime = DateTime.Now;
            StopTrimming = true;

            SaveRejectedDataToDb();

            ResetMainForm();
        }

        private void SaveRejectedDataToDb()
        {
            try
            {
                var trimmedLoadCell = new TrimmedLoadCell
                {
                    SerialNumber = tbSerialNumber.Text,
                    LoadCellType = LoadCellType,
                    StartingTime = StartingTime,
                    EndingTime = EndingTime,
                    Status = LoadCellStatus,
                    RejectCriteria = LoadCellRejectCriteria,
                    TrimCount = TrimCount,
                    Operator = lblOperatorName.Text,
                    OperatorId = Convert.ToInt32(lblOperatorId.Text)
                };

                _context.TrimmedLoadCells.Add(trimmedLoadCell);
                _context.SaveChanges();

            }
            catch (Exception exception)
            {
                ShowMessage(exception.Message);
            }
        }

        private void SaveFinalDataToDb()
        {
            try
            {
                var trimmedLoadCell = new TrimmedLoadCell
                {
                    SerialNumber = tbSerialNumber.Text,
                    LoadCellType = LoadCellType,
                    StartingTime = StartingTime,
                    EndingTime = EndingTime,
                    BridgeUnbalance = Convert.ToDouble(tbBridgeUnbalance.Text),
                    InitialFso = Convert.ToDouble(tbInitialFSO.Text),
                    InitialLeftCorner = Convert.ToDouble(tbInitialLeftCornerReading.Text),
                    InitialD1Corner = Convert.ToDouble(tbInitialD1Reading.Text),
                    InitialBackCorner = Convert.ToDouble(tbInitialBackCornerReading.Text),
                    InitialD2Corner = Convert.ToDouble(tbInitialD2Reading.Text),
                    InitialRightCorner = Convert.ToDouble(tbInitialRightCornerReading.Text),
                    InitialD3Corner = Convert.ToDouble(tbInitialD3Reading.Text),
                    InitialFrontCorner = Convert.ToDouble(tbInitialFrontCornerReading.Text),
                    InitialD4Corner = Convert.ToDouble(tbInitialD4Reading.Text),
                    FinalLeftCorner = Convert.ToDouble(tbLeftCorner.Text),
                    FinalD1Corner = Convert.ToDouble(tbD1Reading.Text),
                    FinalBackCorner = Convert.ToDouble(tbBackCorner.Text),
                    FinalD2Corner = Convert.ToDouble(tbD2Reading.Text),
                    FinalRightCorner = Convert.ToDouble(tbRightCorner.Text),
                    FinalD3Corner = Convert.ToDouble(tbD3Reading.Text),
                    FinalFrontCorner = Convert.ToDouble(tbFrontCorner.Text),
                    FinalD4Corner = Convert.ToDouble(tbD4Reading.Text),
                    TrimmedFso = TrimmedFso,
                    FactoredFso = CalculatedFso,
                    FinalFso = FinalFso,
                    Status = LoadCellStatus,
                    RejectCriteria = LoadCellRejectCriteria,
                    TrimCount = TrimCount,
                    Operator = lblOperatorName.Text,
                    OperatorId = Convert.ToInt32(lblOperatorId.Text)
                };

                _context.TrimmedLoadCells.Add(trimmedLoadCell);
                _context.SaveChanges();

            }
            catch (Exception exception)
            {
                ShowMessage(exception.Message);
            }
        }

        private void DisplayTotalTime()
        {
            var processDuration = ProcessDuration.Elapsed.Minutes;

            tbTotalTime.Text = $@"{processDuration} Minutes";
        }

        private void DisplayFinalFso()
        {
            FinalFso = CalculatedFso;
            tbFinalFSO.Text = FinalFso.ToString(CultureInfo.CurrentCulture);
        }

        private void ResetMainForm()
        {
            tbSerialNumber.ReadOnly = false;
            ClearAllInputsAndOutputs();
            lblStable.Text = "";
            btnStart.Enabled = false;
            btnStart.Enabled = false;
        }

        private void ClearAllInputsAndOutputs()
        {
            foreach (var textBox in Controls.OfType<TextBox>())
            {
                textBox.Clear();
            }

            var labelList = new List<Label>
            {
                lblLeftCorner, lblBackCorner, lblRightCorner, lblFrontCorner, lblMaximumCenter, lblMaximumFSO,
                lblMinimumFSO, lblMaximumUnbalance, lblMinimumUnbalance
            };

            foreach (var label in labelList)
            {
                label.Text = "";
            }

        }

        private bool IsCalculatedFsoInRange()
        {
            ShowMessage(@"Keep the calibrated weight on the center.");

            var calibratedCenterReading = lblReading.Text;
            CalculateFso(calibratedCenterReading);

            return MinimumFsoReading < CalculatedFso && CalculatedFso < MaximumFsoReading;
        }

        private void CalculateFso(string output)
        {
            var checkLoadCell = CheckLoadCell();

            if (checkLoadCell == null) return;

            var appliedLoad = checkLoadCell.Type.AppliedLoad;
            var capacity = checkLoadCell.Type.Capacity;
            var factor = checkLoadCell.Type.Factor;

            CalculatedFso = (Convert.ToDouble(output) * capacity * factor) / appliedLoad;
        }

        private async Task CheckDisplayAllFinalCorners()
        {
            FiveSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(5));
            ShowMessage(@"Press OK when ready...!!!");

            var currentCornerReading = lblReading.Text;
            CornerReadings.Add("Left", Convert.ToDouble(currentCornerReading));
            tbLeftCorner.Text = currentCornerReading;

            await GetCornerReadings("D1", tbD1Reading);
            await GetCornerReadings("Back", tbBackCorner);

            await GetCornerReadings("D2", tbD2Reading);
            await GetCornerReadings("Right", tbRightCorner);

            await GetCornerReadings("D3", tbD3Reading);
            await GetCornerReadings("Front", tbFrontCorner);

            await GetCornerReadings("D4", tbD4Reading);

            ShowMessage(@"Move armature to Left position.");

            FiveSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(5));
            ShowMessage(@"Press OK when ready...!!!");

            await GetCornerReadings("Center", tbCenter);

            WriteCommand("01");

            ShowMessage(@"Remove the weight from center. Trimming is completed...!!! Press OK to continue.");

            var trimmedCenterReading = lblReading.Text;

            TrimmedFso = Math.Abs(Convert.ToDouble(trimmedCenterReading));
        }

        private void GetDisplaySaveCenterReadings()
        {
            tbCenter.Text = lblReading.Text;
            CenterReadings.Add(Convert.ToDouble(tbCenter.Text));
        }

        private async Task CheckInitialCornerTest(LoadCell loadCell)
        {
            await GetCornerReadings("Left", tbInitialLeftCornerReading);
            await GetCornerReadings("D1", tbInitialD1Reading);
            await GetCornerReadings("Back", tbInitialBackCornerReading);

            await GetCornerReadings("D2", tbInitialD2Reading);
            await GetCornerReadings("Right", tbInitialRightCornerReading);

            await GetCornerReadings("D3", tbInitialD3Reading);
            await GetCornerReadings("Front", tbInitialFrontCornerReading);

            await GetCornerReadings("D4", tbInitialD4Reading);

            ShowMessage(@"Rotate the armature to left position...");

            FiveSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(5));

            await GetCornerReadings("Center", tbInitialCenterReading);

            if (CheckExcessiveCorners(loadCell))
            {
                StopProcessAndExit(@"Load Cell is rejected due to Excessive Corners...!!!", RejectionCriteria.ExcessiveCorners);
                return;
            }

            WriteCommand("01");

            ShowMessage(@"Please remove the weight...");

            FiveSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(5));

            ShowMessage($@"Trim the {GetMinimumCornerName()} corner. Look Image...");

            ShowTrimPosition(GetMinimumCornerName());

            TenSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(10));

            CornerReadings.Clear();

            ShowMessage(@"Press OK when Trimming is completed...");
        }

        private bool CheckToTrim()
        {
            var leftRightCornerDifference = Math.Abs(CornerReadings["Left"]) - Math.Abs(CornerReadings["Right"]);
            var frontBackCornerDifference = Math.Abs(CornerReadings["Front"]) - Math.Abs(CornerReadings["Back"]);

            var areCornersDifferenceInRange = leftRightCornerDifference < LeftRightCornerDifferenceInDb
                                              && frontBackCornerDifference < FrontBackCornerDifferenceInDb;

            return CornerTrimValue != 0 ? CheckCornersAndDifference(areCornersDifferenceInRange) 
                : CheckCornersWithSameValueAndDifference(areCornersDifferenceInRange);
        }

        private bool CheckCornersWithSameValueAndDifference(bool areCornersDifferenceInRange)
        {
            var areCornersInRange = (Math.Abs(CornerReadings["Left"]) < CornerTrimValue)
                                    && (Math.Abs(CornerReadings["Back"]) < CornerTrimValue)
                                    && (Math.Abs(CornerReadings["Right"]) < CornerTrimValue)
                                    && (Math.Abs(CornerReadings["Front"]) < CornerTrimValue);

            return areCornersInRange && areCornersDifferenceInRange;
        }

        private bool CheckCornersAndDifference(bool areCornersDifferenceInRange)
        {
            var areCornersInRange = (Math.Abs(CornerReadings["Left"]) < LeftCornerTrimValue)
                                    && (Math.Abs(CornerReadings["Back"]) < BackCornerTrimValue)
                                    && (Math.Abs(CornerReadings["Right"]) < RightCornerTrimValue)
                                    && (Math.Abs(CornerReadings["Front"]) < FrontCornerTrimValue);

            return areCornersInRange && areCornersDifferenceInRange;
        }

        private LoadCell CheckLoadCell()
        {
            var loadCell = _context.LoadCells.Include(l => l.Type).SingleOrDefault(l => l.SerialNumber == tbSerialNumber.Text);
            return loadCell;
        }

        private void DisplayDataTable(int timeElapsed)
        {
            var cornerList = GetDisplayData();

            TrimCount = 0;

            var columns = from d in cornerList
                select new
                {
                    Trim_Cycle = ++TrimCount,
                    Left= d.LeftCorner,
                    Back = d.BackCorner,
                    Right = d.RightCorner,
                    Front = d.FrontCorner,
                    d.Center,
                    Time = timeElapsed
                };

            trimDataGridView.DataSource = columns.ToList();
        }

        private IEnumerable<Corner> GetDisplayData()
        {
            var corner = new Corner(
                CornerReadings["Left"], CornerReadings["Back"], CornerReadings["Right"], CornerReadings["Front"], CenterReadings[0]
            );

            _cornerList.Add(corner);

            return _cornerList;
        }

        private void ClearCornerReadings()
        {
            var cornerList = new List<Control>
            {
                tbLeftCorner, tbBackCorner, tbRightCorner, tbFrontCorner, tbCenter
            };

            foreach (var corner in cornerList)
            {
                corner.Text = "";
            }
        }

        private string GetMinimumCornerName()
        {
            var minCorner = CornerReadings
                .Aggregate((l, r) => l.Value < r.Value ? l : r);

            var minCornerName = minCorner.Key;
            return minCornerName;
        }

        private bool CheckExcessiveCorners(LoadCell loadCell)
        {
            if (CornerReadings.Any(initialCornerReading =>
                loadCell.Type.ExcessiveCornerValue < initialCornerReading.Value))
            {
                ShowMessage(@"Load Cell has excessive corners. Load Cell is rejected...");
                return true;
            }

            EndingTime = DateTime.Now;

            return false;
        }

        private CheckCornerTestModeResult CheckCornerTestMode()
        {
            var loadCell = CheckLoadCell();

            if (loadCell == null)
            {
                return new CheckCornerTestModeResult(){LoadCell = null, TestModeInDb = null, IsLoadCellNotAvailable = true};
            }

            var testModeInDb = loadCell.Type.TestMode;

            return new CheckCornerTestModeResult(){LoadCell = loadCell, TestModeInDb = testModeInDb, IsLoadCellNotAvailable = false};
        }

        private CheckFsoResult CheckFso()
        {
            var initialFso = lblReading.Text;

            if (Convert.ToDouble(initialFso) <= MinimumFsoReading)
            {
                ShowMessage(@"Initial FSO is too Low...!!!");
                return new CheckFsoResult() { InitialFso = initialFso, IsFsoNotOk = true, IsFsoLow = true};
            }

            if (MaximumFsoReading <= Convert.ToDouble(initialFso))
            {
                ShowMessage(@"Initial FSO is too High...!!!");
                return new CheckFsoResult() { InitialFso = initialFso, IsFsoNotOk = true, IsFsoHigh = true};
            }

            EndingTime = DateTime.Now;

            return new CheckFsoResult(){InitialFso = initialFso, IsFsoNotOk = false};
        }

        private bool CheckWeight(double currentReading)
        {
            var readingAfterWeight = currentReading + 0.00050;

            if (!(Math.Abs(Convert.ToDouble(lblReading.Text)) < readingAfterWeight)) return false;
            ShowMessage(@"Check weight on center...!!!");
            return true;
        }

        private bool CheckBridgeUnbalance()
        {
            var bridgeUnbalance = lblReading.Text;
            tbBridgeUnbalance.Text = bridgeUnbalance;

            if (Convert.ToDouble(bridgeUnbalance) <= MinimumUnbalanceReading &&
                MaximumUnbalanceReading <= Convert.ToDouble(bridgeUnbalance))
            {
                ShowMessage(@"Initial Bridge Reading is not within the range...!!!");
                return true;
            }

            EndingTime = DateTime.Now;

            return false;
        }

        private static void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void TenSecondsCounter_Tick(object sender, EventArgs e)
        {
            _tenSecondsCount--;

            if (_tenSecondsCount < 0)
            {
                TenSecondsCounter.Stop();
                lblWaiting.Text = "";
                _tenSecondsCount = 10;
            }
            else
            {
                lblWaiting.Text = $@"Wait {_tenSecondsCount}";
            }
        }

        private void FiveSecondsCounter_Tick(object sender, EventArgs e)
        {
            _fiveSecondsCount--;

            if (_fiveSecondsCount < 0)
            {
                FiveSecondsCounter.Stop();
                lblWaiting.Text = "";
                _fiveSecondsCount = 5;
            }
            else
            {
                lblWaiting.Text = $@"Wait {_fiveSecondsCount}";
            }
        }

        private async Task GetCornerReadings(string corner, Control textBox)
        {
            ShowSuitableInstruction(corner);

            FiveSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(5));
            ShowMessage(@"Press OK when ready...!!!");

            var currentCornerReading = lblReading.Text;

            if (corner == "D1" || corner == "D2" || corner == "D3" || corner == "D4")
            {
                textBox.Text = currentCornerReading;
                return;
            }

            if (corner == "Center")
            {
                textBox.Text = currentCornerReading;
                return;
            }
            
            CornerReadings.Add(corner, Convert.ToDouble(currentCornerReading));
            
            textBox.Text = currentCornerReading;
        }

        private static void ShowSuitableInstruction(string corner)
        {
            switch (corner)
            {
                case "Center":
                    ShowMessage($@"Move weight to {corner}.");
                    return;
                case "Left":
                    return;
                default:
                    ShowMessage($@"Rotate armature to {corner} position...");
                    break;
            }
        }

        private void ShowTrimPosition(string positionName)
        {
            pbLoadCell.Hide();

            switch (positionName)
            {
                case "Left":
                    pbLeft.Show();
                    break;

                case "Back":
                    pbBack.Show();
                    break;

                case "Right":
                    pbRight.Show();
                    break;

                case "Front":
                    pbFront.Show();
                    break;
            }
        }

        private void lblReading_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void stableCheckTimer_Tick(object sender, EventArgs e)
        {
            lblReading_TextChanged(sender, e);
        }

        private static string ToDescriptionString(RejectionCriteria value)
        {
            var attributes = (DescriptionAttribute[])value
                .GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }

    public class CheckFsoResult
    {
        public string InitialFso { get; set; }
        public bool IsFsoNotOk { get; set; }
        public bool IsFsoLow { get; set; }
        public bool IsFsoHigh { get; set; }
    }

    public class CheckCornerTestModeResult
    {
        public LoadCell LoadCell { get; set; }
        public string TestModeInDb { get; set; }
        public bool IsLoadCellNotAvailable { get; set; }
    }

    public class Corner
    {
        public double LeftCorner { get; set; }
        public double BackCorner { get; set; }
        public double RightCorner { get; set; }
        public double FrontCorner { get; set; }
        public double Center { get; set; }

        public Corner(double leftCorner, double backCorner, double rightCorner, double frontCorner, double center)
        {
            LeftCorner = leftCorner;
            BackCorner = backCorner;
            RightCorner = rightCorner;
            FrontCorner = frontCorner;
            Center = center;
        }
    }

    public enum Status
    {
        Rejected,
        Passed
    }

    public enum RejectionCriteria
    {
        [Description("High Balance")]
        HighBalance,

        [Description("High FSO")]
        HighFso,

        [Description("Low FSO")]
        LowFso,

        [Description("Excessive Corners")]
        ExcessiveCorners,

        [Description("Unstable")]
        Unstable,

        [Description("High Zero")]
        HighZero,

        [Description("No Complete")]
        NoComplete,

        [Description("No")]
        No
    }
}
