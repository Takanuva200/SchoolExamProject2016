namespace Client_Application.View
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label_AdID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCoordinates = new System.Windows.Forms.TextBox();
            this.textBoxOwner = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxPortSB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label_IDSB = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSBCoordinates = new System.Windows.Forms.TextBox();
            this.textBoxSBIPAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxPortSA = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label_IDSA = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSACoordinates = new System.Windows.Forms.TextBox();
            this.textBoxSAIPAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBoxAdvertisements = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.listBoxCoordinates = new System.Windows.Forms.ListBox();
            this.listBoxNumberOfPSensors = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.dateTimePickerOfExpiration = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.listBoxDateOfExpire = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(340, 264);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.dateTimePickerOfExpiration);
            this.tabPage1.Controls.Add(this.label_AdID);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBoxCoordinates);
            this.tabPage1.Controls.Add(this.textBoxOwner);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(332, 238);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create Advertisement";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label_AdID
            // 
            this.label_AdID.AutoSize = true;
            this.label_AdID.Location = new System.Drawing.Point(8, 35);
            this.label_AdID.Name = "label_AdID";
            this.label_AdID.Size = new System.Drawing.Size(59, 13);
            this.label_AdID.TabIndex = 7;
            this.label_AdID.Text = "label_AdID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Owner";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Coordinates:";
            // 
            // textBoxCoordinates
            // 
            this.textBoxCoordinates.Location = new System.Drawing.Point(8, 115);
            this.textBoxCoordinates.Name = "textBoxCoordinates";
            this.textBoxCoordinates.Size = new System.Drawing.Size(231, 20);
            this.textBoxCoordinates.TabIndex = 2;
            // 
            // textBoxOwner
            // 
            this.textBoxOwner.Location = new System.Drawing.Point(8, 76);
            this.textBoxOwner.Name = "textBoxOwner";
            this.textBoxOwner.Size = new System.Drawing.Size(231, 20);
            this.textBoxOwner.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create Advertisement";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(332, 238);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add a Pair Sensor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Add Sensor";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxPortSB);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label_IDSB);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxSBCoordinates);
            this.groupBox2.Controls.Add(this.textBoxSBIPAddress);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(170, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 182);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sensor B";
            // 
            // textBoxPortSB
            // 
            this.textBoxPortSB.Location = new System.Drawing.Point(11, 149);
            this.textBoxPortSB.Name = "textBoxPortSB";
            this.textBoxPortSB.Size = new System.Drawing.Size(139, 20);
            this.textBoxPortSB.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Port #";
            // 
            // label_IDSB
            // 
            this.label_IDSB.AutoSize = true;
            this.label_IDSB.Location = new System.Drawing.Point(8, 29);
            this.label_IDSB.Name = "label_IDSB";
            this.label_IDSB.Size = new System.Drawing.Size(60, 13);
            this.label_IDSB.TabIndex = 7;
            this.label_IDSB.Text = "label_IDSB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Sensor B Coordinates";
            // 
            // textBoxSBCoordinates
            // 
            this.textBoxSBCoordinates.Location = new System.Drawing.Point(11, 71);
            this.textBoxSBCoordinates.Name = "textBoxSBCoordinates";
            this.textBoxSBCoordinates.Size = new System.Drawing.Size(139, 20);
            this.textBoxSBCoordinates.TabIndex = 3;
            // 
            // textBoxSBIPAddress
            // 
            this.textBoxSBIPAddress.Location = new System.Drawing.Point(11, 110);
            this.textBoxSBIPAddress.Name = "textBoxSBIPAddress";
            this.textBoxSBIPAddress.Size = new System.Drawing.Size(139, 20);
            this.textBoxSBIPAddress.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "IP address";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPortSA);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label_IDSA);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxSACoordinates);
            this.groupBox1.Controls.Add(this.textBoxSAIPAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 182);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensor A";
            // 
            // textBoxPortSA
            // 
            this.textBoxPortSA.Location = new System.Drawing.Point(11, 148);
            this.textBoxPortSA.Name = "textBoxPortSA";
            this.textBoxPortSA.Size = new System.Drawing.Size(139, 20);
            this.textBoxPortSA.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Port #";
            // 
            // label_IDSA
            // 
            this.label_IDSA.AutoSize = true;
            this.label_IDSA.Location = new System.Drawing.Point(8, 29);
            this.label_IDSA.Name = "label_IDSA";
            this.label_IDSA.Size = new System.Drawing.Size(60, 13);
            this.label_IDSA.TabIndex = 6;
            this.label_IDSA.Text = "label_IDSA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sensor A Coordinates";
            // 
            // textBoxSACoordinates
            // 
            this.textBoxSACoordinates.Location = new System.Drawing.Point(11, 70);
            this.textBoxSACoordinates.Name = "textBoxSACoordinates";
            this.textBoxSACoordinates.Size = new System.Drawing.Size(139, 20);
            this.textBoxSACoordinates.TabIndex = 3;
            // 
            // textBoxSAIPAddress
            // 
            this.textBoxSAIPAddress.Location = new System.Drawing.Point(11, 109);
            this.textBoxSAIPAddress.Name = "textBoxSAIPAddress";
            this.textBoxSAIPAddress.Size = new System.Drawing.Size(139, 20);
            this.textBoxSAIPAddress.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP address";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 268);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(912, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // listBoxAdvertisements
            // 
            this.listBoxAdvertisements.FormattingEnabled = true;
            this.listBoxAdvertisements.Location = new System.Drawing.Point(342, 50);
            this.listBoxAdvertisements.Name = "listBoxAdvertisements";
            this.listBoxAdvertisements.Size = new System.Drawing.Size(156, 212);
            this.listBoxAdvertisements.TabIndex = 2;
            this.listBoxAdvertisements.SelectedIndexChanged += new System.EventHandler(this.listBoxAdvertisements_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(480, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Advertisements:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(495, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Coordinates";
            // 
            // listBoxCoordinates
            // 
            this.listBoxCoordinates.FormattingEnabled = true;
            this.listBoxCoordinates.Location = new System.Drawing.Point(498, 50);
            this.listBoxCoordinates.Name = "listBoxCoordinates";
            this.listBoxCoordinates.Size = new System.Drawing.Size(210, 212);
            this.listBoxCoordinates.TabIndex = 4;
            // 
            // listBoxNumberOfPSensors
            // 
            this.listBoxNumberOfPSensors.FormattingEnabled = true;
            this.listBoxNumberOfPSensors.Location = new System.Drawing.Point(708, 50);
            this.listBoxNumberOfPSensors.Name = "listBoxNumberOfPSensors";
            this.listBoxNumberOfPSensors.Size = new System.Drawing.Size(59, 212);
            this.listBoxNumberOfPSensors.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(705, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "# PSensors";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(342, 34);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(38, 13);
            this.label.TabIndex = 8;
            this.label.Text = "Owner";
            // 
            // dateTimePickerOfExpiration
            // 
            this.dateTimePickerOfExpiration.Location = new System.Drawing.Point(11, 158);
            this.dateTimePickerOfExpiration.Name = "dateTimePickerOfExpiration";
            this.dateTimePickerOfExpiration.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerOfExpiration.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Choose date of expiration";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(787, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Date of expiration";
            // 
            // listBoxDateOfExpire
            // 
            this.listBoxDateOfExpire.FormattingEnabled = true;
            this.listBoxDateOfExpire.Location = new System.Drawing.Point(767, 50);
            this.listBoxDateOfExpire.Name = "listBoxDateOfExpire";
            this.listBoxDateOfExpire.Size = new System.Drawing.Size(124, 212);
            this.listBoxDateOfExpire.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 290);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.listBoxDateOfExpire);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.listBoxNumberOfPSensors);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listBoxCoordinates);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxAdvertisements);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ListBox listBoxAdvertisements;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxOwner;
        private System.Windows.Forms.TextBox textBoxCoordinates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_AdID;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxPortSB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_IDSB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSBCoordinates;
        private System.Windows.Forms.TextBox textBoxSBIPAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxPortSA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_IDSA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSACoordinates;
        private System.Windows.Forms.TextBox textBoxSAIPAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox listBoxCoordinates;
        private System.Windows.Forms.ListBox listBoxNumberOfPSensors;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePickerOfExpiration;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox listBoxDateOfExpire;
    }
}

