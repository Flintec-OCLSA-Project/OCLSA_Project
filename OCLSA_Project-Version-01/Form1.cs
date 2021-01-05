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
            }
            else
            {
                var maximumCenterReading = loadCell.Type.MaximumCenterReading;
                var maximumUnbalanceReading = loadCell.Type.MaximumUnbalanceReading;
                var minimumUnbalanceReading = loadCell.Type.MinimumUnbalanceReading;
                var maximumFsoReading = loadCell.Type.MaximumFsoReading;
                var minimumFsoReading = loadCell.Type.MinimumFsoReading;

                //Get other default corner readings

                lblMaximumCenter.Text = maximumCenterReading.ToString(CultureInfo.InvariantCulture);
                lblMaximumUnbalance.Text = maximumUnbalanceReading.ToString(CultureInfo.InvariantCulture);
                lblMinimumUnbalance.Text = minimumUnbalanceReading.ToString(CultureInfo.InvariantCulture);
                lblMaximumFSO.Text = maximumFsoReading.ToString(CultureInfo.InvariantCulture);
                lblMinimumFSO.Text = minimumFsoReading.ToString(CultureInfo.InvariantCulture);

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

            initialTimer.Start();
        }

        private void initialTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!serialPortVT400.IsOpen)
                {
                    serialPortVT400.Open();
                    serialPortVT400.DiscardInBuffer();
                    serialPortVT400.DiscardOutBuffer();

                    serialPortVT400.WriteLine("?");

                    Thread.Sleep(100);

                    string dataReading = Convert.ToString(serialPortVT400.ReadExisting());

                    if (dataReading.Split('P').Length > 1)
                    {
                        lblReading.Text = dataReading.Split('P')[1];
                    }

                    serialPortVT400.Close();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
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

            tbBridgeUnbalance.Text = lblReading.Text;


        }
    }
}
