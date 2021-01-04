using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCLSA_Project_Version_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
