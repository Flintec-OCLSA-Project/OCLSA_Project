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
                MessageBox.Show(@"Please Enter the Serial Number...");
                return;
            }
            
            var enteredId = tbSerialNumber.Text;
            var loadCell = _context.LoadCells.Include(l => l.Type).SingleOrDefault(l => l.SerialNumber == enteredId);

            if (loadCell == null)
            {
                MessageBox.Show(@"Load cell not found");
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


                MessageBox.Show(@"Press Start to continue...");

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
                MessageBox.Show(exception.Message);
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
            serialPortVT400.WriteLine(command);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (tbSerialNumber.TextLength <= 0) return;

            if (lblReading.Text.Length > 0)
            {
                lblStable.Text = @"Stable";
            }
            else
            {
                lblStable.Text = @"Not Stable";
                MessageBox.Show(@"Load Cell is not stable. Please Check Again!!!");
            }

            var bridgeUnbalance = lblReading.Text;
            tbBridgeUnbalance.Text = bridgeUnbalance;

            if (Convert.ToDouble(bridgeUnbalance) <= MinimumUnbalanceReading && MaximumUnbalanceReading <= Convert.ToDouble(bridgeUnbalance))
            {
                MessageBox.Show(@"Initial Bridge Reading is not within the range...!!!");
                return;
            }

            WriteCommand("01");

            var currentReading = Math.Abs(Convert.ToDouble(lblReading.Text));

            MessageBox.Show(@"Keep weight on center");

            var readingAfterWeight = currentReading + 0.00050;

            if (Math.Abs(Convert.ToDouble(lblReading.Text)) < readingAfterWeight)
            {
                MessageBox.Show(@"Check weight on center...!!!");
            }

            var initialFso = lblReading.Text;
            tbInitialFSO.Text = initialFso;

            if (Convert.ToDouble(initialFso) <= MinimumFsoReading && MaximumFsoReading <= Convert.ToDouble(initialFso))
            {
                MessageBox.Show(@"Initial FSO is too high or low...!!!");
                return;
            }

            MessageBox.Show(@"Give exercise to load cell...");

            CountTimer.Start();
            lblWaiting.Text = @"Wait" + @" " + counter.ToString();

            //Corner Check
        }

        private void CountTimer_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0) CountTimer.Stop();

            lblWaiting.Text = @"Wait" + @" " + counter.ToString();
        }
    }
}
