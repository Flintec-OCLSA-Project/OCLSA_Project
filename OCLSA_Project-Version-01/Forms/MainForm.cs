using OCLSA_Project_Version_01.Common;
using OCLSA_Project_Version_01.DataAccess.MainForm;
using OCLSA_Project_Version_01.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCLSA_Project_Version_01.Forms
{
    public partial class MainForm : Form
    {
        private readonly ApplicationDbContext _context;

        public List<double> CenterReadings { get; set; } = new List<double>();
        public Dictionary<string, double> CornerReadings { get; set; } = new Dictionary<string, double>();
        private List<Corner> _cornerList = new List<Corner>();
        private List<string> TrimTimeList { get; set; } = new List<string>();

        public double MaximumCenterReading { get; set; }
        public double MaximumUnbalanceReading { get; set; }
        public double MinimumUnbalanceReading { get; set; }
        public double MaximumFsoReading { get; set; }
        public double MinimumFsoReading { get; set; }
        public double MaximumFsoReadingFinal { get; set; }
        public double MinimumFsoReadingFinal { get; set; }
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

        private bool _stopTrimming;

        public int ResistorsToAdd { get; set; }

        public bool IsFsoCorrectionAvailable { get; set; }

        public bool CurrentStatus = true;

        public MainForm()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();

            pbPositions.Image = Properties.Resources.LoadCell;
        }

        public MainForm(string fullName, int employeeId, string location, string station, Image image)
        {
            InitializeComponent();

            _context = new ApplicationDbContext();

            pbPositions.Image = Properties.Resources.LoadCell;

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
                    /*serialPortVT400.DiscardInBuffer();
                    serialPortVT400.DiscardOutBuffer();*/
                    initialTimer.Start();
                }
            }
            catch (Exception exception)
            {
                ShowMessage(exception.Message);
            }

        }

        private void initialTimer_Tick(object sender, EventArgs e)
        {
            WriteCommand("?");

            Thread.Sleep(100);

            var dataReading = Convert.ToString(serialPortVT400.ReadExisting());

            lblStable.Text = dataReading.Contains('@') ? @"Unstable" : @"Stable";
            lblStable.ForeColor = lblStable.Text == @"Unstable" ? Color.Red : Color.Lime;

            if (dataReading.Split('P').Length > 1)
            {
                lblReading.Text = dataReading.Split('P')[1];
            }

            if (dataReading.Split('R').Length > 1)
            {
                lblReading.Text = dataReading.Split('R')[1];
            }

            if (dataReading.Split('T').Length > 1)
            {
                lblReading.Text = dataReading.Split('T')[1];
            }

            if (dataReading.Split('@').Length > 1)
            {
                lblReading.Text = dataReading.Split('@')[1];
            }
        }

        private void WriteCommand(string command)
        {
            try
            {
                serialPortVT400.DiscardInBuffer();
                serialPortVT400.DiscardOutBuffer();
                serialPortVT400.WriteLine(command);
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
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
            ProcessDuration = Stopwatch.StartNew();

            var loadCell = CheckLoadCell();

            if (loadCell == null)
            {
                ShowMessage(@"Load cell not found");
                tbSerialNumber.Clear();
                return;
            }

            var trimmedLoadCell = CheckTrimmedLoadCell();

            //Todo - Direct user what to do when a serial number of trimmed cell is entered
            if (trimmedLoadCell != null && !trimmedLoadCell.IsFsoCorrectionAvailable)
            {
                ShowMessage(@"Load Cell is tested before. Press OK to Exit.");
                ResetMainForm();
                return;
            }

            LoadCellType = loadCell.TypeName;

            CheckDisplayCornerTrimValues(loadCell);

            GetMasterData(loadCell);

            DisplayMasterData();

            tbSerialNumber.ReadOnly = true;

            ShowMessage(@"Press start to continue...");

            btnStart.Enabled = true;
            btnStop.Enabled = true;
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
                lblWaiting.Text = $@"Wait {_tenSecondsCount} Seconds";
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
                lblWaiting.Text = $@"Wait {_fiveSecondsCount} Seconds";
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (CheckBridgeUnbalance())
            {
                tbStatus.Text = Status.Rejected.ToString();
                await StopProcessAndExit(@"Load Cell is rejected due to High Balance...!!!", Status.Rejected, RejectionCriteria.HighBalance);
                return;
            }

            ShowMessage(@"Press TARE button to tare");
            //WriteCommand("1");

            var currentReading = Math.Abs(Convert.ToDouble(lblReading.Text));

            ShowMessage(@"Keep weight on Center");
            ShowArmaturePosition(@"Center");
            await DisplayWaitingStatus(@"Keep weight on Center", 10, false);

            while (CheckWeight(currentReading))
            {
                await DisplayWaitingStatus(@"Keep weight on Center", 10, false);
            }

            var result = CheckFso();
            var initialFso = result.InitialFso;

            switch (result.IsFsoNotOk)
            {
                case true when result.IsFsoLow:
                    tbStatus.Text = Status.Rejected.ToString();
                    await StopProcessAndExit(@"Load Cell is rejected due to Low FSO...!!!", Status.Rejected, RejectionCriteria.LowFso);
                    return;
                case true when result.IsFsoHigh:
                    tbStatus.Text = Status.Rejected.ToString();
                    await StopProcessAndExit(@"Load Cell is rejected due to High FSO...!!!", Status.Rejected, RejectionCriteria.HighFso);
                    return;
            }

            tbInitialFSO.Text = initialFso;

            ShowMessage(@"Press TARE button to tare");
            //WriteCommand("1");

            ShowMessage(@"Move weight to Left Corner");
            ShowArmaturePosition(@"Left");
            await DisplayWaitingStatus(@"Move weight to Left Corner", 10, false);

            ShowMessage(@"Give exercise to Load Cell");
            await DisplayWaitingStatus(@"Give exercise to Load Cell", 10, false);

            await Task.Delay(TimeSpan.FromSeconds(2));
            ShowMessage(@"Move weight from Left Corner to Center");
            ShowArmaturePosition(@"Center");
            await DisplayWaitingStatus(@"Move weight from Left Corner to Center", 10, false);

            ShowMessage(@"Press TARE button to tare");
            //WriteCommand("1");

            ShowMessage(@"Remove weight from Center & keep on Left Corner");
            ShowArmaturePosition(@"Left");
            await DisplayWaitingStatus(@"Move weight from Center to Left Corner", 10, false);

            var checkCornerTestMode = CheckCornerTestMode();
            var loadCell = checkCornerTestMode.LoadCell;
            if (checkCornerTestMode.IsLoadCellNotAvailable) return;

            switch (checkCornerTestMode.TestModeInDb)
            {
                case TestMode.CornerTest:
                    {
                        CurrentStatus = true;

                        await CheckInitialCornerTest(loadCell);

                        if (CurrentStatus == true)
                        {
                            for (var i = 0; i < 15; i++)
                            {
                                var oneTrimCycleDuration = Stopwatch.StartNew();

                                await CheckDisplayMainCorners();

                                if (CheckToTrim())
                                {
                                    ShowMessage(@"Corners are OK. No need to trim...!!! Move weight to the Left Corner.");
                                    ShowArmaturePosition(@"Left");
                                    CornerReadings.Clear();
                                    CenterReadings.Clear();
                                    ClearDisplayedCornerReadings();
                                    break;
                                }

                                await RemoveWeightAndShowTrimDetails();

                                oneTrimCycleDuration.Stop();
                                var time = CalculateOneTrimCycleDuration(oneTrimCycleDuration);
                                TrimTimeList.Add(time);
                                oneTrimCycleDuration.Reset();

                                DisplayDataTable();
                                ClearCornerAndCenterLists();

                                ShowMessage(@"Press OK to check corners are OK...");

                                ClearDisplayedCornerReadings();

                                if (i <= 10) continue;

                                tbTrimmedCyclesCount.Text = TrimCount.ToString();
                                _stopTrimming = true;
                                await StopProcessAndExit(@"Further trimming is useless...!!! Press OK to stop the process.",
                                    Status.Failed, RejectionCriteria.Unstable);
                                break;
                            }

                            if (_stopTrimming)
                            {
                                _stopTrimming = false;
                                return;
                            }

                            tbTrimmedCyclesCount.Text = TrimCount.ToString();

                            await CheckDisplayAllFinalCorners();

                            if (!IsCalculatedFsoInRange())
                            {
                                await AddResistorsToCorrectFso();
                                return;
                            }

                            ShowMessage(@"Load Cell is Passed");

                            SetStatusAndRejectCriteria(Status.Passed, RejectionCriteria.No);

                            ProcessDuration.Stop();

                            DisplayFinalFso();
                            tbTotalTime.Text = DisplayTotalTime();

                            EndingTime = DateTime.Now;

                            SaveFinalDataToDb();

                            ShowMessage(@"Process is completed. Press OK to trim a new cell.");

                            ResetMainForm();

                        }
                        else
                        {

                        }

                        break;
                    }

                case TestMode.DiagonalTest:
                    break;

                case TestMode.FullTest:
                    break;

                default:
                    ShowMessage(@"Error in selecting test mode");
                    break;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            var result = ResultMessage.Result(@"Do you want to stop the process?", @"Choose option");

            if (result == DialogResult.No) return;

            Application.ExitThread();
        }

        private void CheckDisplayCornerTrimValues(LoadCell loadCell)
        {
            if (loadCell.Type.CornerTrimValue != null && loadCell.Type.CornerTrimValue != 0.0)
            {
                CornerTrimValue = (double)loadCell.Type.CornerTrimValue;

                var trimCornerLabels = new List<Control> { lblLeftCorner, lblBackCorner, lblRightCorner, lblFrontCorner };

                foreach (var cornerLabel in trimCornerLabels)
                {
                    cornerLabel.Text = CornerTrimValue.ToString(CultureInfo.InvariantCulture);
                }
            }
            else
            {
                if (loadCell.Type.LeftCornerTrimValue != null)
                    LeftCornerTrimValue = (double)loadCell.Type.LeftCornerTrimValue;

                if (loadCell.Type.BackCornerTrimValue != null)
                    BackCornerTrimValue = (double)loadCell.Type.BackCornerTrimValue;

                if (loadCell.Type.RightCornerTrimValue != null)
                    RightCornerTrimValue = (double)loadCell.Type.RightCornerTrimValue;

                if (loadCell.Type.FrontCornerTrimValue != null)
                    FrontCornerTrimValue = (double)loadCell.Type.FrontCornerTrimValue;

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
            MinimumFsoReadingFinal = loadCell.Type.MinimumFsoValueFinal;
            MaximumFsoReadingFinal = loadCell.Type.MaximumFsoValueFinal;

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
            lblMinimumFSOFinal.Text = MinimumFsoReadingFinal.ToString(CultureInfo.CurrentCulture);
            lblMaximumFSOFinal.Text = MaximumFsoReadingFinal.ToString(CultureInfo.CurrentCulture);
        }

        private async Task AddResistorsToCorrectFso()
        {
            var loadCellInDb = CheckLoadCell();

            if (loadCellInDb == null) return;

            switch (loadCellInDb.MetalCategory)
            {
                case nameof(MetalCategory.Aluminium):
                    {
                        await StopProcessAndExit(@"FSO is high & can not be corrected by adding resistors...!!!", Status.Rejected,
                            RejectionCriteria.HighFso);
                        break;
                    }
                case nameof(MetalCategory.Steel):
                    {
                        if (MinimumFsoReading < CalculatedFso && CalculatedFso < loadCellInDb.Type.FsoCorrectionValue)
                            ResistorsToAdd = 1;

                        if (loadCellInDb.Type.FsoCorrectionValue < CalculatedFso)
                            ResistorsToAdd = 3;

                        SetStatusAndRejectCriteria(Status.Failed, RejectionCriteria.HighFso);

                        IsFsoCorrectionAvailable = true;

                        ProcessDuration.Stop();
                        tbTotalTime.Text = DisplayTotalTime();
                        EndingTime = DateTime.Now;

                        SaveFinalDataToDb();

                        ShowMessage(
                            ResistorsToAdd > 1
                            ? $@"Add CP {ResistorsToAdd} resistor to fix High FSO. Press OK to trim a new cell."
                            : $@"Add {ResistorsToAdd} resistors to fix High FSO. Press OK to trim a new cell."
                            );

                        ResetMainForm();
                        break;
                    }
                default:
                    {
                        await StopProcessAndExit(@"FSO can not be corrected by adding resistors...!!!", Status.Failed,
                            RejectionCriteria.HighFso);
                        break;
                    }
            }
        }

        private void SetStatusAndRejectCriteria(Status status, RejectionCriteria reason)
        {
            LoadCellStatus = status.ToString();
            LoadCellRejectCriteria = EnumStringFormatter.ToDescriptionString(reason);
            tbStatus.Text = status.ToString();
        }

        private void ClearCornerAndCenterLists()
        {
            CornerReadings.Clear();
            CenterReadings.Clear();
            TrimTimeList.Clear();
        }

        private static string CalculateOneTrimCycleDuration(Stopwatch duration)
        {
            var timeElapsed = duration.Elapsed.Duration();
            return $"{timeElapsed.Minutes:D2}:{timeElapsed.Seconds:D2}";
        }

        private async Task RemoveWeightAndShowTrimDetails()
        {
            ShowMessage(@"Please remove the weight");
            await DisplayWaitingStatus(@"Please remove the weight", 5, true);

            ShowMessage($@"Look Image to trim the {GetMinimumCornerName()} corner");

            ShowTrimPosition(GetMinimumCornerName());
            await DisplayWaitingStatus($@"Look Image to trim the {GetMinimumCornerName()} corner", 5, true);
        }

        private async Task CheckDisplayMainCorners()
        {
            ShowMessage(@"Keep weight on the Center");
            ShowArmaturePosition(@"Center");
            await DisplayWaitingStatus(@"Keep weight on the Center", 5, true);

            ShowMessage(@"Press TARE button to tare");
            //WriteCommand("1");

            ShowMessage(@"Remove the weight and keep on Left Corner");
            ShowArmaturePosition(@"Left");
            await DisplayWaitingStatus(@"Remove the weight and keep on Left Corner", 5, true);

            GetLeftCornerReading(tbLeftCorner);
            await GetCornerReadings("Back", tbBackCorner);
            await GetCornerReadings("Right", tbRightCorner);
            await GetCornerReadings("Front", tbFrontCorner);

            ShowMessage(@"Rotate the armature to Left position");
            ShowArmaturePosition(@"Left");
            await DisplayWaitingStatus(@"Rotate the armature to Left position", 5, true);

            await Task.Delay(TimeSpan.FromSeconds(2));
            ShowMessage(@"Remove the weight and keep on Center");
            ShowArmaturePosition(@"Center");
            await DisplayWaitingStatus(@"Remove the weight and keep on Center", 5, true);

            //ShowMessage(@"Press TARE button to tare");
            //WriteCommand("1");
            GetDisplaySaveCenterReadings(tbCenter);
        }

        private void GetLeftCornerReading(Control textBox)
        {
            var currentCornerReading = lblReading.Text;
            CornerReadings.Add("Left", Convert.ToDouble(currentCornerReading));
            textBox.Text = currentCornerReading;
        }

        private async Task DisplayWaitingStatus(string command, int waitingTime, bool isLessCount)
        {
            if (isLessCount)
                FiveSecondsCounter.Start();
            else
                TenSecondsCounter.Start();

            lblDisplayMessage.Text = command;

            await Task.Delay(TimeSpan.FromSeconds(waitingTime));
            ShowMessage(@"Press OK when ready...!!!");

            lblDisplayMessage.Text = "";
        }

        private async Task StopProcessAndExit(string errorMessage, Status status, RejectionCriteria reason)
        {
            ShowMessage(errorMessage);

            SetStatusAndRejectCriteria(status, reason);

            EndingTime = DateTime.Now;
            ProcessDuration.Stop();

            tbTotalTime.Text = DisplayTotalTime();

            SaveFinalDataToDb();

            await Task.Delay(TimeSpan.FromSeconds(2));

            var result = ResultMessage.Result("Select YES to start a new task & NO to exit from the application.",
                "Choose Option");

            if (result == DialogResult.Yes)
                ResetMainForm();
            else
                Application.Exit();
        }

        private void SaveFinalDataToDb()
        {
            try
            {
                //var totalTimeInMinutes = Regex.Replace(tbTotalTime.Text, "[^0-9]+", string.Empty);
                var totalTime = string.IsNullOrWhiteSpace(tbBridgeUnbalance.Text) ? "Unavailable" : tbTotalTime.Text;

                var trimmedLoadCell = new TrimmedLoadCell
                {
                    SerialNumber = tbSerialNumber.Text,
                    LoadCellType = LoadCellType,
                    StartingTime = StartingTime,
                    EndingTime = EndingTime,
                    BridgeUnbalance = string.IsNullOrWhiteSpace(tbBridgeUnbalance.Text)
                        ? 0d
                        : Convert.ToDouble(tbBridgeUnbalance.Text),
                    InitialFso = string.IsNullOrWhiteSpace(tbInitialFSO.Text)
                        ? 0d
                        : Convert.ToDouble(tbInitialFSO.Text),
                    InitialLeftCorner = string.IsNullOrWhiteSpace(tbInitialLeftCornerReading.Text)
                        ? 0d
                        : Convert.ToDouble(tbInitialLeftCornerReading.Text),
                    InitialD1Corner = string.IsNullOrWhiteSpace(tbInitialD1Reading.Text)
                        ? 0d
                        : Convert.ToDouble(tbInitialD1Reading.Text),
                    InitialBackCorner = string.IsNullOrWhiteSpace(tbInitialBackCornerReading.Text)
                        ? 0d
                        : Convert.ToDouble(tbInitialBackCornerReading.Text),
                    InitialD2Corner = string.IsNullOrWhiteSpace(tbInitialD2Reading.Text)
                        ? 0d
                        : Convert.ToDouble(tbInitialD2Reading.Text),
                    InitialRightCorner = string.IsNullOrWhiteSpace(tbInitialRightCornerReading.Text)
                        ? 0d
                        : Convert.ToDouble(tbInitialRightCornerReading.Text),
                    InitialD3Corner = string.IsNullOrWhiteSpace(tbInitialD3Reading.Text)
                        ? 0d
                        : Convert.ToDouble(tbInitialD3Reading.Text),
                    InitialFrontCorner = string.IsNullOrWhiteSpace(tbInitialFrontCornerReading.Text)
                        ? 0d
                        : Convert.ToDouble(tbInitialFrontCornerReading.Text),
                    InitialD4Corner = string.IsNullOrWhiteSpace(tbInitialD4Reading.Text)
                        ? 0d
                        : Convert.ToDouble(tbInitialD4Reading.Text),
                    FinalLeftCorner = string.IsNullOrWhiteSpace(tbLeftCorner.Text)
                        ? 0d
                        : Convert.ToDouble(tbLeftCorner.Text),
                    FinalD1Corner = string.IsNullOrWhiteSpace(tbD1Reading.Text)
                        ? 0d
                        : Convert.ToDouble(tbD1Reading.Text),
                    FinalBackCorner = string.IsNullOrWhiteSpace(tbBackCorner.Text)
                        ? 0d
                        : Convert.ToDouble(tbBackCorner.Text),
                    FinalD2Corner = string.IsNullOrWhiteSpace(tbD2Reading.Text)
                        ? 0d
                        : Convert.ToDouble(tbD2Reading.Text),
                    FinalRightCorner = string.IsNullOrWhiteSpace(tbRightCorner.Text)
                        ? 0d
                        : Convert.ToDouble(tbRightCorner.Text),
                    FinalD3Corner = string.IsNullOrWhiteSpace(tbD3Reading.Text)
                        ? 0d
                        : Convert.ToDouble(tbD3Reading.Text),
                    FinalFrontCorner = string.IsNullOrWhiteSpace(tbFrontCorner.Text)
                        ? 0d
                        : Convert.ToDouble(tbFrontCorner.Text),
                    FinalD4Corner = string.IsNullOrWhiteSpace(tbD4Reading.Text)
                        ? 0d
                        : Convert.ToDouble(tbD4Reading.Text),
                    TrimmedFso = TrimmedFso,
                    FactoredFso = CalculatedFso,
                    FinalFso = FinalFso,
                    Status = LoadCellStatus,
                    RejectCriteria = LoadCellRejectCriteria,
                    TrimCount = TrimCount,
                    Operator = lblOperatorName.Text,
                    OperatorId = Convert.ToInt32(lblOperatorId.Text),
                    NoOfResistors = ResistorsToAdd,
                    IsFsoCorrectionAvailable = IsFsoCorrectionAvailable,
                    TotalTime = totalTime
                };

                _context.TrimmedLoadCells.Add(trimmedLoadCell);
                _context.SaveChanges();

            }
            catch (Exception exception)
            {
                ShowMessage(exception.Message);
            }
        }

        private string DisplayTotalTime()
        {
            var processDuration = ProcessDuration.Elapsed.Duration();
            return $@"{processDuration.Minutes:D2} : {processDuration.Seconds:D2}";
        }

        private void DisplayFinalFso()
        {
            FinalFso = CalculatedFso;
            tbFinalFSO.Text = Math.Round(FinalFso, 5).ToString(CultureInfo.CurrentCulture);
        }

        private void ResetMainForm()
        {
            tbSerialNumber.ReadOnly = false;
            ClearAllInputsAndOutputs();
            btnStart.Enabled = false;
            btnStart.Enabled = false;
            ResistorsToAdd = 0;
            TrimCount = 0;
            FinalFso = 0.0;
            TrimmedFso = 0.0;
            CalculatedFso = 0.0;
            IsFsoCorrectionAvailable = false;
            ProcessDuration?.Reset();
            pbPositions.Image = Properties.Resources.LoadCell;
            CurrentStatus = true;

            if (CenterReadings.Count != 0) CenterReadings.Clear();
            if (CornerReadings.Count != 0) CornerReadings.Clear();
            if (TrimTimeList.Count != 0) TrimTimeList.Clear();
            if (_cornerList.Count != 0) _cornerList.Clear();
        }

        private void ClearAllInputsAndOutputs()
        {
            var textBoxList = new List<TextBox>
            {
                tbSerialNumber, tbBridgeUnbalance, tbInitialFSO, tbFinalFSO, tbTrimmedCyclesCount, tbTotalTime, tbStatus, tbInitialLeftCornerReading,
                tbInitialBackCornerReading, tbInitialRightCornerReading, tbInitialFrontCornerReading, tbInitialD1Reading, tbInitialD2Reading,
                tbInitialD3Reading, tbInitialD4Reading, tbLeftCorner, tbFrontCorner, tbBackCorner, tbRightCorner, tbD1Reading, tbD2Reading, tbD3Reading,
                tbD4Reading, tbCenter, tbInitialCenterReading
            };

            foreach (var textBox in textBoxList)
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
            ShowMessage(@"Press TARE button to tare");

            ShowMessage(@"Keep the calibrated weight on the Center");
            ShowArmaturePosition("FinalCenter");

            var calibratedCenterReading = lblReading.Text;
            CalculateFso(calibratedCenterReading);

            return MinimumFsoReadingFinal < CalculatedFso && CalculatedFso < MaximumFsoReadingFinal;
        }

        private void CalculateFso(string output)
        {
            var checkLoadCell = CheckLoadCell();

            if (checkLoadCell == null) return;

            var appliedLoad = checkLoadCell.Type.AppliedLoad;
            var capacity = checkLoadCell.Type.Capacity;
            var factor = checkLoadCell.Type.Factor;

            CalculatedFso = Math.Round((Convert.ToDouble(output) * capacity * factor) / appliedLoad, 5);
        }

        private async Task CheckDisplayAllFinalCorners()
        {
            ShowArmaturePosition(@"Left");
            await DisplayWaitingStatus(@"Move weight to the Left Corner", 5, true);

            GetLeftCornerReading(tbLeftCorner);
            await GetCornerReadings("D1", tbD1Reading);
            await GetCornerReadings("Back", tbBackCorner);
            await GetCornerReadings("D2", tbD2Reading);
            await GetCornerReadings("Right", tbRightCorner);
            await GetCornerReadings("D3", tbD3Reading);
            await GetCornerReadings("Front", tbFrontCorner);
            await GetCornerReadings("D4", tbD4Reading);

            ShowMessage(@"Move armature to Left position");
            ShowArmaturePosition(@"Left");
            await DisplayWaitingStatus(@"Move armature to Left position", 5, true);

            await GetCornerReadings("Center", tbCenter);
            tbCenter.Text = lblReading.Text;
            GetDisplaySaveCenterReadings(tbCenter);

            ShowMessage(@"Remove the weight from Center. Trimming is completed...!!! Press OK to continue.");

            var trimmedCenterReading = lblReading.Text;
            TrimmedFso = Math.Abs(Convert.ToDouble(trimmedCenterReading));
        }

        private void GetDisplaySaveCenterReadings(Control textBox)
        {
            textBox.Text = lblReading.Text;
            CenterReadings.Add(Convert.ToDouble(textBox.Text));
        }

        private async Task CheckInitialCornerTest(LoadCell loadCell)
        {
            var oneTrimCycleDuration = Stopwatch.StartNew();

            GetLeftCornerReading(tbInitialLeftCornerReading);
            await GetCornerReadings("D1", tbInitialD1Reading);
            await GetCornerReadings("Back", tbInitialBackCornerReading);
            await GetCornerReadings("D2", tbInitialD2Reading);
            await GetCornerReadings("Right", tbInitialRightCornerReading);
            await GetCornerReadings("D3", tbInitialD3Reading);
            await GetCornerReadings("Front", tbInitialFrontCornerReading);
            await GetCornerReadings("D4", tbInitialD4Reading);

            ShowMessage(@"Rotate the armature to Left position");
            ShowArmaturePosition(@"Left");
            await DisplayWaitingStatus(@"Rotate the armature to Left position", 5, true);

            await GetCornerReadings("Center", tbInitialCenterReading);

            if (CheckExcessiveCorners(loadCell))
            {
                await StopProcessAndExit(@"Load Cell is rejected due to Excessive Corners...!!!",
                    Status.Failed, RejectionCriteria.ExcessiveCorners);
                return;
            }

            tbInitialCenterReading.Text = lblReading.Text;
            GetDisplaySaveCenterReadings(tbInitialCenterReading);

            ShowMessage(@"Please remove the weight");
            await DisplayWaitingStatus(@"Please remove the weight", 5, true);

            if (CheckToTrim())
            {
                CurrentStatus = false;

                ShowMessage(@"Corners are OK. No need to trim...!!! Move weight to the Left Corner.");
                ShowArmaturePosition(@"Left");
                CornerReadings.Clear();
                CenterReadings.Clear();
                ClearDisplayedCornerReadings();

                /*Checking FSO*/
                tbTrimmedCyclesCount.Text = TrimCount.ToString();

                await CheckDisplayAllFinalCorners();

                if (!IsCalculatedFsoInRange())
                {
                    await AddResistorsToCorrectFso();
                    return;
                }

                ShowMessage(@"Load Cell is Passed");

                SetStatusAndRejectCriteria(Status.Passed, RejectionCriteria.No);

                ProcessDuration.Stop();

                DisplayFinalFso();
                tbTotalTime.Text = DisplayTotalTime();

                EndingTime = DateTime.Now;

                SaveFinalDataToDb();

                ShowMessage(@"Process is completed. Press OK to trim a new cell.");

                ResetMainForm();

            }
            else
            {
                CurrentStatus = true;

                ShowMessage($@"Trim the {GetMinimumCornerName()} corner. Look Image...");

                ShowTrimPosition(GetMinimumCornerName());
                await DisplayWaitingStatus($@"Trim the {GetMinimumCornerName()} corner. Look Image", 5, true);

                oneTrimCycleDuration.Stop();
                var time = CalculateOneTrimCycleDuration(oneTrimCycleDuration);
                TrimTimeList.Add(time);
                oneTrimCycleDuration.Reset();

                DisplayDataTable();
                ClearCornerAndCenterLists();
            }
        }

        private bool CheckToTrim()
        {
            var leftRightCornerDifference = CornerReadings["Left"] - CornerReadings["Right"];
            var frontBackCornerDifference = CornerReadings["Front"] - CornerReadings["Back"];

            var areCornersDifferenceInRange = Math.Abs(leftRightCornerDifference) < LeftRightCornerDifferenceInDb
                                              && Math.Abs(frontBackCornerDifference) < FrontBackCornerDifferenceInDb;

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
            var areCornersInRange = (Math.Abs(CornerReadings["Left"]) < Convert.ToDouble(lblLeftCorner.Text))
                                    && (Math.Abs(CornerReadings["Back"]) < Convert.ToDouble(lblBackCorner.Text))
                                    && (Math.Abs(CornerReadings["Right"]) < Convert.ToDouble(lblRightCorner.Text))
                                    && (Math.Abs(CornerReadings["Front"]) < Convert.ToDouble(lblFrontCorner.Text));

            return areCornersInRange && areCornersDifferenceInRange;
        }

        private LoadCell CheckLoadCell()
        {
            var loadCell = _context.LoadCells.Include(l => l.Type).SingleOrDefault(l => l.SerialNumber == tbSerialNumber.Text);
            return loadCell;
        }

        private TrimmedLoadCell CheckTrimmedLoadCell()
        {
            var loadCell = _context.TrimmedLoadCells.SingleOrDefault(l => l.SerialNumber == tbSerialNumber.Text);
            return loadCell;
        }

        private void DisplayDataTable()
        {
            var cornerList = GetDisplayData();

            TrimCount = 0;

            var columns = from d in cornerList
                          select new
                          {
                              Trim_Cycle = ++TrimCount,
                              Left = d.LeftCorner,
                              Back = d.BackCorner,
                              Right = d.RightCorner,
                              Front = d.FrontCorner,
                              d.Center,
                              Time = d.TrimTime
                          };

            trimDataGridView.DataSource = columns.ToList();
        }

        private IEnumerable<Corner> GetDisplayData()
        {
            var corner = new Corner(
                CornerReadings["Left"],
                CornerReadings["Back"],
                CornerReadings["Right"],
                CornerReadings["Front"],
                CenterReadings[0],
                TrimTimeList[0]
            );

            _cornerList.Add(corner);

            return _cornerList;
        }

        private void ClearDisplayedCornerReadings()
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
                return new CheckCornerTestModeResult() { LoadCell = null, TestModeInDb = null, IsLoadCellNotAvailable = true };
            }

            var testModeInDb = loadCell.Type.TestMode;

            return new CheckCornerTestModeResult() { LoadCell = loadCell, TestModeInDb = testModeInDb, IsLoadCellNotAvailable = false };
        }

        private CheckFsoResult CheckFso()
        {
            var initialFso = lblReading.Text;

            if (Convert.ToDouble(initialFso) <= MinimumFsoReading)
            {
                ShowMessage(@"Initial FSO is too Low...!!!");
                return new CheckFsoResult() { InitialFso = initialFso, IsFsoNotOk = true, IsFsoLow = true };
            }

            if (MaximumFsoReading <= Convert.ToDouble(initialFso))
            {
                ShowMessage(@"Initial FSO is too High...!!!");
                return new CheckFsoResult() { InitialFso = initialFso, IsFsoNotOk = true, IsFsoHigh = true };
            }

            EndingTime = DateTime.Now;

            return new CheckFsoResult() { InitialFso = initialFso, IsFsoNotOk = false };
        }

        private bool CheckWeight(double currentReading)
        {
            var readingAfterWeight = currentReading + 0.00050;

            if (!(Math.Abs(Convert.ToDouble(lblReading.Text)) < readingAfterWeight)) return false;
            ShowMessage(@"Check weight on Center...!!!");
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

        private async Task GetCornerReadings(string corner, Control textBox)
        {
            ShowMessage(GiveInstruction(corner));
            ShowArmaturePosition(corner);

            var textToDisplay = GiveInstruction(corner);

            await DisplayWaitingStatus(textToDisplay, 5, true);

            var currentReading = lblReading.Text;

            if (corner == "D1" || corner == "D2" || corner == "D3" || corner == "D4")
            {
                textBox.Text = currentReading;
                return;
            }

            if (corner == "Center") return;

            CornerReadings.Add(corner, Convert.ToDouble(currentReading));

            textBox.Text = currentReading;
        }

        private static string GiveInstruction(string corner)
        {
            return corner == "Center" ? $@"Move weight to {corner}" : $@"Rotate armature to {corner} position";
        }

        private void ShowTrimPosition(string positionName)
        {
            switch (positionName)
            {
                case "Left":
                    pbPositions.Image = Properties.Resources.TrimLeft;
                    break;

                case "Back":
                    pbPositions.Image = Properties.Resources.TrimBack;
                    break;

                case "Right":
                    pbPositions.Image = Properties.Resources.TrimRight;
                    break;

                case "Front":
                    pbPositions.Image = Properties.Resources.TrimFront;
                    break;
            }
        }

        private void ShowArmaturePosition(string positionName)
        {
            switch (positionName)
            {
                case "Left":
                    pbPositions.Image = Properties.Resources.Left;
                    break;

                case "Back":
                    pbPositions.Image = Properties.Resources.Back;
                    break;

                case "Right":
                    pbPositions.Image = Properties.Resources.Right;
                    break;

                case "Front":
                    pbPositions.Image = Properties.Resources.Front;
                    break;

                case "D1":
                    pbPositions.Image = Properties.Resources.D1;
                    break;

                case "D2":
                    pbPositions.Image = Properties.Resources.D2;
                    break;

                case "D3":
                    pbPositions.Image = Properties.Resources.D3;
                    break;

                case "D4":
                    pbPositions.Image = Properties.Resources.D4;
                    break;

                case "Center":
                    pbPositions.Image = Properties.Resources.Center;
                    break;

                case "FinalCenter":
                    pbPositions.Image = Properties.Resources.CalibratedWeight;
                    break;
            }
        }
    }
}
