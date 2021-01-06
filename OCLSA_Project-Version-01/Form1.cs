using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OCLSA_Project_Version_01.Models;

namespace OCLSA_Project_Version_01
{
    public partial class Form1 : Form
    {
        private readonly ApplicationDbContext _context;

        public double MaximumCenterReading { get; set; }
        public double MaximumUnbalanceReading { get; set; }
        public double MinimumUnbalanceReading { get; set; }
        public double MaximumFsoReading { get; set; }
        public double MinimumFsoReading { get; set; }

        private int counter = 10;

        public Form1()
        {
            InitializeComponent();

            _context = new ApplicationDbContext();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSerialNumber.Text == "")
            {
                ShowMessage(@"Please Enter the Serial Number...");
                return;
            }
            
            var enteredId = tbSerialNumber.Text;
            var loadCell = _context.LoadCells.Include(l => l.Type).SingleOrDefault(l => l.SerialNumber == enteredId);

            if (loadCell == null)
            {
                ShowMessage(@"Load cell not found");
                tbSerialNumber.Text = "";
            }
            else
            {
                MaximumCenterReading = loadCell.Type.MaximumCenterReading;
                MaximumUnbalanceReading = loadCell.Type.MaximumUnbalanceReading;
                MinimumUnbalanceReading = loadCell.Type.MinimumUnbalanceReading;
                MaximumFsoReading = loadCell.Type.MaximumFsoReading;
                MinimumFsoReading = loadCell.Type.MinimumFsoReading;

                //Get other default corner readings

                lblMaximumCenter.Text = MaximumCenterReading.ToString(CultureInfo.InvariantCulture);
                lblMaximumUnbalance.Text = MaximumUnbalanceReading.ToString(CultureInfo.InvariantCulture);
                lblMinimumUnbalance.Text = MinimumUnbalanceReading.ToString(CultureInfo.InvariantCulture);
                lblMaximumFSO.Text = MaximumFsoReading.ToString(CultureInfo.InvariantCulture);
                lblMinimumFSO.Text = MinimumFsoReading.ToString(CultureInfo.InvariantCulture);

                //Display default corner readings


                ShowMessage(@"Press Start to continue...");

                btnStart.Enabled = true;
                btnStop.Enabled = true;
            }


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
                }
            }
            catch (Exception exception)
            {
                ShowMessage(exception.Message);
            }

            initialTimer.Start();
        }

        private void initialTimer_Tick(object sender, EventArgs e)
        {
            WriteCommand("?");

            Thread.Sleep(100);

            string dataReading = Convert.ToString(serialPortVT400.ReadExisting());

            if (dataReading.Split('P').Length > 1)
            {
                lblReading.Text = dataReading.Split('P')[1];
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
            }

            //Bridge Unbalance Check
            var bridgeUnbalance = lblReading.Text;
            tbBridgeUnbalance.Text = bridgeUnbalance;

            if (Convert.ToDouble(bridgeUnbalance) <= MinimumUnbalanceReading && MaximumUnbalanceReading <= Convert.ToDouble(bridgeUnbalance))
            {
                ShowMessage(@"Initial Bridge Reading is not within the range...!!!");
                return;
            }

            WriteCommand("01");

            var currentReading = Math.Abs(Convert.ToDouble(lblReading.Text));

            ShowMessage(@"Keep weight on center");

            CountTimer.Start();
            await Task.Delay(10000);

            //Weight Check
            var readingAfterWeight = currentReading + 0.00050;

            if (Math.Abs(Convert.ToDouble(lblReading.Text)) < readingAfterWeight)
            {
                MessageBox.Show(@"Check weight on center...!!!");
            }

            //FSO Check
            var initialFso = lblReading.Text;

            if (Convert.ToDouble(initialFso) <= MinimumFsoReading || MaximumFsoReading <= Convert.ToDouble(initialFso))
            {
                ShowMessage(@"Initial FSO is too high or low...!!!");
                return;
            }

            tbInitialFSO.Text = initialFso;

            //Taring the instrument readings
            WriteCommand("01");

            ShowMessage(@"Move weight to one corner...");

            CountTimer.Start();
            await Task.Delay(10000);

            //Exercise
            ShowMessage(@"Give exercise to load cell...");

            CountTimer.Start();
            await Task.Delay(10000);

            ShowMessage(@"Move weight to center...");

            CountTimer.Start();
            await Task.Delay(10000);

            WriteCommand("01");

            ShowMessage(@"Move weight to one corner...");

            CountTimer.Start();
            await Task.Delay(10000);

            //Corner Check

            var loadCell = _context.LoadCells.Include(l => l.Type).SingleOrDefault(l => l.SerialNumber == tbSerialNumber.Text);

            if (loadCell == null) return;

            var testModeInDb = loadCell.Type.TestMode;

            switch (testModeInDb)
            {
                case TestMode.CornerTest:
                {
                    //Message - Rotate armature to left position
                    //timer-5s
                    //Save reading to a variable and display - inside cell

                    //Message - Rotate armature to back position
                    //timer-5s
                    //Save reading to a variable and display - inside cell

                    //Message - Rotate armature to right position
                    //timer-5s
                    //Save reading to a variable and display - inside cell

                    //Message - Rotate armature to front position
                    //timer-5s
                    //Save reading to a variable and display - inside cell


                    //Message - Move weight to center
                    //timer-5s
                    //Save reading to a variable and display - inside cell

                    //Check whether corner readings have excessive values - reject or proceed

                    //

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

        private static void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void CountTimer_Tick(object sender, EventArgs e)
        {
            counter--;

            if (counter < 0)
            {
                CountTimer.Stop();
                lblWaiting.Text = "";
                counter = 10;
            }
            else
            {
                lblWaiting.Text = @"Wait" + @" " + counter.ToString();
            }
        }
    }
}
