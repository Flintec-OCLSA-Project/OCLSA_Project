
namespace OCLSA_Project_Version_01.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.OCLSA = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOperatorCancel = new System.Windows.Forms.Button();
            this.btnOperatorLogin = new System.Windows.Forms.Button();
            this.cbStation = new System.Windows.Forms.ComboBox();
            this.Station = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.OCLSA);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 369);
            this.panel1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 30);
            this.label7.TabIndex = 15;
            this.label7.Text = "Automation System";
            // 
            // OCLSA
            // 
            this.OCLSA.AutoSize = true;
            this.OCLSA.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OCLSA.ForeColor = System.Drawing.Color.Black;
            this.OCLSA.Location = new System.Drawing.Point(60, 216);
            this.OCLSA.Name = "OCLSA";
            this.OCLSA.Size = new System.Drawing.Size(139, 50);
            this.OCLSA.TabIndex = 14;
            this.OCLSA.Text = "OCLSA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(35, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 178);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(454, 131);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(165, 29);
            this.tbPassword.TabIndex = 26;
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(290, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "Password";
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(454, 82);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(165, 29);
            this.tbUsername.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(290, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "Username";
            // 
            // btnOperatorCancel
            // 
            this.btnOperatorCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperatorCancel.Location = new System.Drawing.Point(492, 252);
            this.btnOperatorCancel.Name = "btnOperatorCancel";
            this.btnOperatorCancel.Size = new System.Drawing.Size(127, 43);
            this.btnOperatorCancel.TabIndex = 22;
            this.btnOperatorCancel.Text = "Cancel";
            this.btnOperatorCancel.UseVisualStyleBackColor = true;
            // 
            // btnOperatorLogin
            // 
            this.btnOperatorLogin.AutoSize = true;
            this.btnOperatorLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperatorLogin.Location = new System.Drawing.Point(332, 252);
            this.btnOperatorLogin.Name = "btnOperatorLogin";
            this.btnOperatorLogin.Size = new System.Drawing.Size(127, 43);
            this.btnOperatorLogin.TabIndex = 20;
            this.btnOperatorLogin.Text = "Login";
            this.btnOperatorLogin.UseVisualStyleBackColor = true;
            this.btnOperatorLogin.Click += new System.EventHandler(this.btnOperatorLogin_Click);
            // 
            // cbStation
            // 
            this.cbStation.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStation.FormattingEnabled = true;
            this.cbStation.Items.AddRange(new object[] {
            "Station 01",
            "Station 02"});
            this.cbStation.Location = new System.Drawing.Point(454, 176);
            this.cbStation.Name = "cbStation";
            this.cbStation.Size = new System.Drawing.Size(165, 29);
            this.cbStation.TabIndex = 29;
            // 
            // Station
            // 
            this.Station.AutoSize = true;
            this.Station.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Station.Location = new System.Drawing.Point(290, 180);
            this.Station.Name = "Station";
            this.Station.Size = new System.Drawing.Size(72, 25);
            this.Station.TabIndex = 28;
            this.Station.Text = "Station";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(648, 369);
            this.Controls.Add(this.cbStation);
            this.Controls.Add(this.Station);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnOperatorLogin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnOperatorCancel);
            this.MaximumSize = new System.Drawing.Size(664, 408);
            this.MinimumSize = new System.Drawing.Size(664, 408);
            this.Name = "LoginForm";
            this.Text = "Login Form";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label OCLSA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOperatorCancel;
        private System.Windows.Forms.Button btnOperatorLogin;
        private System.Windows.Forms.Label Station;
        public System.Windows.Forms.TextBox tbPassword;
        public System.Windows.Forms.TextBox tbUsername;
        public System.Windows.Forms.ComboBox cbStation;
    }
}