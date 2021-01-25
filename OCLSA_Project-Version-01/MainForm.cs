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
using OCLSA_Project_Version_01.Models;

namespace OCLSA_Project_Version_01
{
    public partial class MainForm : Form
    {
        private readonly ApplicationDbContext _context;

        public List<double> InitialAndFinalCenterReadings { get; set; } = new List<double>();
        public List<double> CenterReadings { get; set; } = new List<double>();
        public Dictionary<string, double> CornerReadings { get; set; } = new Dictionary<string, double>();
        private List<Corner> _cornerList = new List<Corner>();

        public double MaximumCenterReading { get; set; }
        public double MaximumUnbalanceReading { get; set; }
        public double MinimumUnbalanceReading { get; set; }
        public double MaximumFsoReading { get; set; }
        public double MinimumFsoReading { get; set; }
        public double CornerTrimValue { get; set; }

        public double LeftCornerTrimValue { get; set; }
        public double BackCornerTrimValue { get; set; }
        public double RightCornerTrimValue { get; set; }
        public double FrontCornerTrimValue { get; set; }
        public double LeftFrontCornerTrimValue { get; set; }
        public double LeftBackCornerTrimValue { get; set; }
        public double RightFrontCornerTrimValue { get; set; }
        public double RightBackCornerTrimValue { get; set; }

        public double FrontBackCornerDifferenceInDb { get; set; }
        public double LeftRightCornerDifferenceInDb { get; set; }

        private int _tenSecondsCount = 10;
        private int _fiveSecondsCount = 5;

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

            lbOperatorName.Text = fullName;
            lbOperatorId.Text = employeeId.ToString();
            lbLocation.Text = location;
            lbStation.Text = station;
            pbImage.Image = image;
        }

        private void Form1_Load(object sender, EventArgs e)
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

            var loadCell = CheckLoadCell();

            if (loadCell == null)
            {
                ShowMessage(@"Load cell not found");
                tbSerialNumber.Clear();
                return;
            }
            
            CheckDisplayCornerTrimValues(loadCell);

            GetMasterData(loadCell);

            DisplayMasterData();

            tbSerialNumber.ReadOnly = true;

            ShowMessage(@"Press Start to continue...");

            btnStart.Enabled = true;
            btnStop.Enabled = true;
            
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

            if (CheckBridgeUnbalance()) return;

            WriteCommand("01");
            
            var currentReading = Math.Abs(Convert.ToDouble(lblReading.Text));

            ShowMessage(@"Keep weight on center");

            TenSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(10));

            if (CheckWeight(currentReading)) return;

            var result = CheckFso();
            var initialFso = result.InitialFso;
            if (result.IsFsoNotOk) return;

            tbInitialFSO.Text = initialFso;

            WriteCommand("01");

            ShowMessage(@"Move weight to one corner...");

            TenSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(10));

            ShowMessage(@"Give exercise to load cell...");

            TenSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(10));

            ShowMessage(@"Move weight to center...");

            TenSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(10));

            WriteCommand("01");

            ShowMessage(@"Move weight to one corner...");

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

                    /*------------------Next Iteration - Trimming --------------------*/
                    for (var i = 0; i < 10; i++)
                    {
                        var oneTrimCycleDuration = Stopwatch.StartNew();

                        ShowMessage(@"Keep weight on the center...");

                        GetDisplaySaveCenterReadings();

                        FiveSecondsCounter.Start();
                        await Task.Delay(TimeSpan.FromSeconds(5));

                        WriteCommand("01");

                        await DisplaySaveMainCorners(tbLeftCorner, tbBackCorner, tbRightCorner, tbFrontCorner);

                        if (CheckToTrim())
                        {
                            ShowMessage(@"Corners are OK. No need to trim...!!!");
                            break;
                        }

                        ShowMessage(@"Rotate the armature to left position...");

                        FiveSecondsCounter.Start();
                        await Task.Delay(TimeSpan.FromSeconds(5));

                        ShowMessage(@"Remove the weight from the armature. Move the weight to center position.");

                        FiveSecondsCounter.Start();
                        await Task.Delay(TimeSpan.FromSeconds(5));

                        ShowMessage($@"Trim the {GetMinimumCornerName()} corner. Look Image...");

                        ShowTrimPosition(GetMinimumCornerName());

                        TenSecondsCounter.Start();
                        await Task.Delay(TimeSpan.FromSeconds(10));

                        ShowMessage(@"Press OK when Trimming is completed...");

                        oneTrimCycleDuration.Stop();

                        var timeElapsed = oneTrimCycleDuration.Elapsed.Minutes;

                        DisplayDataTable(timeElapsed);

                        CornerReadings.Clear();
                        CenterReadings.Clear();

                        ShowMessage(@"Press OK to check corners are OK...");

                        ClearCornerReadings();

                        //If i==10 give user the permission to stop the trimming and save it to the db - with reason
                    }

                    //Get the values of diagonal corners and the center and display them in boxes

                    ShowMessage(@"Trimming is completed...!!! Press OK to continue.");

                    
                    //Check with calibrated weight
                    //Check final FSO

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

        private void GetDisplaySaveCenterReadings()
        {
            tbCenter.Text = lblReading.Text;
            CenterReadings.Add(Convert.ToDouble(tbCenter));
        }

        private async Task CheckInitialCornerTest(LoadCell loadCell)
        {
            await DisplaySaveMainCorners(tbInitialLeftCornerReading, tbInitialBackCornerReading,
                tbInitialRightCornerReading, tbInitialFrontCornerReading);

            ShowMessage(@"Rotate the armature to left position...");

            FiveSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(5));

            await GetCornerReadings("Center", tbInitialCenterReading, true);

            if (CheckExcessiveCorners(loadCell)) return;

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

            var trimCount = 0;

            var columns = from d in cornerList
                select new
                {
                    Trim_Cycle = ++trimCount,
                    Left_Corner = d.LeftCorner,
                    Back_Corner = d.BackCorner,
                    Right_Corner = d.RightCorner,
                    Front_Corner = d.FrontCorner,
                    Center = d.Center,
                    Time_Duration = timeElapsed
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


        private async Task DisplaySaveMainCorners(Control leftCorner, Control backCorner, Control rightCorner, Control frontCorner)
        {
            await GetCornerReadings("Left", leftCorner);
            await GetCornerReadings("Back", backCorner);
            await GetCornerReadings("Right", rightCorner);
            await GetCornerReadings("Front", frontCorner);
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

            if (Convert.ToDouble(initialFso) <= MinimumFsoReading || MaximumFsoReading <= Convert.ToDouble(initialFso))
            {
                ShowMessage(@"Initial FSO is too high or low...!!!");
                return new CheckFsoResult() { InitialFso = initialFso, IsFsoNotOk = true};
            }

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

        private async Task GetCornerReadings(string corner, Control textBox, bool isCenter = false)
        {
            ShowMessage(
                isCenter == false ? $@"Rotate armature to {corner} position..." : $@"Move weight to {corner}...");

            FiveSecondsCounter.Start();
            await Task.Delay(TimeSpan.FromSeconds(5));

            var currentCornerReading = lblReading.Text;

            if (corner == "Center")
            {
                InitialAndFinalCenterReadings.Add(Convert.ToDouble(currentCornerReading));
            }
            else
            {
                CornerReadings.Add(corner, Convert.ToDouble(currentCornerReading));
            }

            textBox.Text = currentCornerReading;
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
    }

    public class CheckFsoResult
    {
        public string InitialFso { get; set; }
        public bool IsFsoNotOk { get; set; }
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
}
