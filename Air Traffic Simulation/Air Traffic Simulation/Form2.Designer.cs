namespace Air_Traffic_Simulation
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.tbUsername = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.tbPassword = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl3 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btClose = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl4 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.btLogin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(55)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 450);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(158)))), ((int)(((byte)(209)))));
            this.label2.Location = new System.Drawing.Point(8, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 53);
            this.label2.TabIndex = 3;
            this.label2.Text = "Employee log-in";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(158)))), ((int)(((byte)(209)))));
            this.label1.Location = new System.Drawing.Point(7, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 80);
            this.label1.TabIndex = 2;
            this.label1.Text = "Air Traffic";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Cyan;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(344, 149);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(73, 17);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "Username";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Cyan;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(344, 221);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(69, 17);
            this.bunifuCustomLabel2.TabIndex = 2;
            this.bunifuCustomLabel2.Text = "Password";
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.Color.Silver;
            this.tbUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbUsername.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbUsername.HintForeColor = System.Drawing.Color.Empty;
            this.tbUsername.HintText = "";
            this.tbUsername.isPassword = false;
            this.tbUsername.LineFocusedColor = System.Drawing.Color.Blue;
            this.tbUsername.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.tbUsername.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.tbUsername.LineThickness = 3;
            this.tbUsername.Location = new System.Drawing.Point(347, 172);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(4);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(379, 33);
            this.tbUsername.TabIndex = 3;
            this.tbUsername.Text = "bunifuMaterialTextbox1";
            this.tbUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.Silver;
            this.tbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbPassword.HintForeColor = System.Drawing.Color.Empty;
            this.tbPassword.HintText = "";
            this.tbPassword.isPassword = false;
            this.tbPassword.LineFocusedColor = System.Drawing.Color.Blue;
            this.tbPassword.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.tbPassword.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.tbPassword.LineThickness = 3;
            this.tbPassword.Location = new System.Drawing.Point(347, 247);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(379, 33);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.Text = "bunifuMaterialTextbox2";
            this.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.label1;
            this.bunifuDragControl2.Vertical = true;
            // 
            // bunifuDragControl3
            // 
            this.bunifuDragControl3.Fixed = true;
            this.bunifuDragControl3.Horizontal = true;
            this.bunifuDragControl3.TargetControl = this.label2;
            this.bunifuDragControl3.Vertical = true;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(755, 44);
            this.panel2.TabIndex = 6;
            // 
            // btClose
            // 
            this.btClose.AutoSize = true;
            this.btClose.ForeColor = System.Drawing.Color.Cyan;
            this.btClose.Location = new System.Drawing.Point(722, 9);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(17, 17);
            this.btClose.TabIndex = 6;
            this.btClose.Text = "X";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl4
            // 
            this.bunifuDragControl4.Fixed = true;
            this.bunifuDragControl4.Horizontal = true;
            this.bunifuDragControl4.TargetControl = this.panel2;
            this.bunifuDragControl4.Vertical = true;
            // 
            // btLogin
            // 
            this.btLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btLogin.Location = new System.Drawing.Point(461, 304);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(146, 52);
            this.btLogin.TabIndex = 7;
            this.btLogin.Text = "Log-In";
            this.btLogin.UseVisualStyleBackColor = false;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(751, 450);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox tbUsername;
        private Bunifu.Framework.UI.BunifuMaterialTextbox tbPassword;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;
        private Bunifu.Framework.UI.BunifuCustomLabel btClose;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl4;
        private System.Windows.Forms.Button btLogin;
    }
}