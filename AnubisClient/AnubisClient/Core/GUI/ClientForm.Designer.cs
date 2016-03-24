namespace AnubisClient
{
    partial class ClientForm
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
            this.streamViewer1 = new AnubisClient.StreamViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.startSensorBtn = new System.Windows.Forms.Button();
            this.sensorListBox = new System.Windows.Forms.ListBox();
            this.refreshSensorsBtn = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.startCommBtn = new System.Windows.Forms.Button();
            this.commListBox = new System.Windows.Forms.ListBox();
            this.commArg1Lbl = new System.Windows.Forms.Label();
            this.commArg1Txt = new System.Windows.Forms.TextBox();
            this.commArg2Txt = new System.Windows.Forms.TextBox();
            this.commArg2Lbl = new System.Windows.Forms.Label();
            this.commArg3Txt = new System.Windows.Forms.TextBox();
            this.commArg3Lbl = new System.Windows.Forms.Label();
            this.commArg4Txt = new System.Windows.Forms.TextBox();
            this.commArg4Lbl = new System.Windows.Forms.Label();
            this.commArg5Txt = new System.Windows.Forms.TextBox();
            this.commArg5Lbl = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(936, 695);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.streamViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(928, 666);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stream Viewer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // streamViewer1
            // 
            this.streamViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.streamViewer1.Location = new System.Drawing.Point(23, 24);
            this.streamViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.streamViewer1.Name = "streamViewer1";
            this.streamViewer1.Size = new System.Drawing.Size(879, 618);
            this.streamViewer1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.startSensorBtn);
            this.tabPage2.Controls.Add(this.sensorListBox);
            this.tabPage2.Controls.Add(this.refreshSensorsBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(928, 666);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sensors";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // startSensorBtn
            // 
            this.startSensorBtn.Location = new System.Drawing.Point(206, 60);
            this.startSensorBtn.Name = "startSensorBtn";
            this.startSensorBtn.Size = new System.Drawing.Size(170, 29);
            this.startSensorBtn.TabIndex = 2;
            this.startSensorBtn.Text = "Start Device";
            this.startSensorBtn.UseVisualStyleBackColor = true;
            this.startSensorBtn.Click += new System.EventHandler(this.startSensorBtn_Click);
            // 
            // sensorListBox
            // 
            this.sensorListBox.FormattingEnabled = true;
            this.sensorListBox.ItemHeight = 16;
            this.sensorListBox.Location = new System.Drawing.Point(21, 60);
            this.sensorListBox.Name = "sensorListBox";
            this.sensorListBox.Size = new System.Drawing.Size(170, 100);
            this.sensorListBox.TabIndex = 1;
            this.sensorListBox.SelectedIndexChanged += new System.EventHandler(this.sensorListBox_SelectedIndexChanged);
            // 
            // refreshSensorsBtn
            // 
            this.refreshSensorsBtn.Location = new System.Drawing.Point(21, 17);
            this.refreshSensorsBtn.Name = "refreshSensorsBtn";
            this.refreshSensorsBtn.Size = new System.Drawing.Size(170, 29);
            this.refreshSensorsBtn.TabIndex = 0;
            this.refreshSensorsBtn.Text = "Refresh Devices";
            this.refreshSensorsBtn.UseVisualStyleBackColor = true;
            this.refreshSensorsBtn.Click += new System.EventHandler(this.refreshSensorsBtn_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.commArg5Txt);
            this.tabPage3.Controls.Add(this.commArg5Lbl);
            this.tabPage3.Controls.Add(this.commArg4Txt);
            this.tabPage3.Controls.Add(this.commArg4Lbl);
            this.tabPage3.Controls.Add(this.commArg3Txt);
            this.tabPage3.Controls.Add(this.commArg3Lbl);
            this.tabPage3.Controls.Add(this.commArg2Txt);
            this.tabPage3.Controls.Add(this.commArg2Lbl);
            this.tabPage3.Controls.Add(this.commArg1Txt);
            this.tabPage3.Controls.Add(this.commArg1Lbl);
            this.tabPage3.Controls.Add(this.startCommBtn);
            this.tabPage3.Controls.Add(this.commListBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(928, 666);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Communications";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // startCommBtn
            // 
            this.startCommBtn.Location = new System.Drawing.Point(16, 133);
            this.startCommBtn.Name = "startCommBtn";
            this.startCommBtn.Size = new System.Drawing.Size(170, 29);
            this.startCommBtn.TabIndex = 4;
            this.startCommBtn.Text = "Start Device";
            this.startCommBtn.UseVisualStyleBackColor = true;
            this.startCommBtn.Click += new System.EventHandler(this.startcommBtn_Click);
            // 
            // commListBox
            // 
            this.commListBox.FormattingEnabled = true;
            this.commListBox.ItemHeight = 16;
            this.commListBox.Location = new System.Drawing.Point(16, 17);
            this.commListBox.Name = "commListBox";
            this.commListBox.Size = new System.Drawing.Size(170, 100);
            this.commListBox.TabIndex = 3;
            this.commListBox.SelectedIndexChanged += new System.EventHandler(this.commListBox_SelectedIndexChanged);
            // 
            // commArg1Lbl
            // 
            this.commArg1Lbl.AutoSize = true;
            this.commArg1Lbl.Location = new System.Drawing.Point(16, 179);
            this.commArg1Lbl.Name = "commArg1Lbl";
            this.commArg1Lbl.Size = new System.Drawing.Size(46, 17);
            this.commArg1Lbl.TabIndex = 5;
            this.commArg1Lbl.Text = "label1";
            // 
            // commArg1Txt
            // 
            this.commArg1Txt.Location = new System.Drawing.Point(19, 213);
            this.commArg1Txt.Name = "commArg1Txt";
            this.commArg1Txt.Size = new System.Drawing.Size(100, 22);
            this.commArg1Txt.TabIndex = 6;
            // 
            // commArg2Txt
            // 
            this.commArg2Txt.Location = new System.Drawing.Point(19, 289);
            this.commArg2Txt.Name = "commArg2Txt";
            this.commArg2Txt.Size = new System.Drawing.Size(100, 22);
            this.commArg2Txt.TabIndex = 8;
            // 
            // commArg2Lbl
            // 
            this.commArg2Lbl.AutoSize = true;
            this.commArg2Lbl.Location = new System.Drawing.Point(16, 255);
            this.commArg2Lbl.Name = "commArg2Lbl";
            this.commArg2Lbl.Size = new System.Drawing.Size(46, 17);
            this.commArg2Lbl.TabIndex = 7;
            this.commArg2Lbl.Text = "label2";
            // 
            // commArg3Txt
            // 
            this.commArg3Txt.Location = new System.Drawing.Point(19, 365);
            this.commArg3Txt.Name = "commArg3Txt";
            this.commArg3Txt.Size = new System.Drawing.Size(100, 22);
            this.commArg3Txt.TabIndex = 10;
            // 
            // commArg3Lbl
            // 
            this.commArg3Lbl.AutoSize = true;
            this.commArg3Lbl.Location = new System.Drawing.Point(16, 331);
            this.commArg3Lbl.Name = "commArg3Lbl";
            this.commArg3Lbl.Size = new System.Drawing.Size(46, 17);
            this.commArg3Lbl.TabIndex = 9;
            this.commArg3Lbl.Text = "label3";
            // 
            // commArg4Txt
            // 
            this.commArg4Txt.Location = new System.Drawing.Point(19, 447);
            this.commArg4Txt.Name = "commArg4Txt";
            this.commArg4Txt.Size = new System.Drawing.Size(100, 22);
            this.commArg4Txt.TabIndex = 12;
            // 
            // commArg4Lbl
            // 
            this.commArg4Lbl.AutoSize = true;
            this.commArg4Lbl.Location = new System.Drawing.Point(16, 413);
            this.commArg4Lbl.Name = "commArg4Lbl";
            this.commArg4Lbl.Size = new System.Drawing.Size(46, 17);
            this.commArg4Lbl.TabIndex = 11;
            this.commArg4Lbl.Text = "label4";
            // 
            // commArg5Txt
            // 
            this.commArg5Txt.Location = new System.Drawing.Point(19, 526);
            this.commArg5Txt.Name = "commArg5Txt";
            this.commArg5Txt.Size = new System.Drawing.Size(100, 22);
            this.commArg5Txt.TabIndex = 14;
            // 
            // commArg5Lbl
            // 
            this.commArg5Lbl.AutoSize = true;
            this.commArg5Lbl.Location = new System.Drawing.Point(16, 492);
            this.commArg5Lbl.Name = "commArg5Lbl";
            this.commArg5Lbl.Size = new System.Drawing.Size(46, 17);
            this.commArg5Lbl.TabIndex = 13;
            this.commArg5Lbl.Text = "label5";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 723);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private StreamViewer streamViewer1;
        private System.Windows.Forms.ListBox sensorListBox;
        private System.Windows.Forms.Button refreshSensorsBtn;
        private System.Windows.Forms.Button startSensorBtn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox commArg5Txt;
        private System.Windows.Forms.Label commArg5Lbl;
        private System.Windows.Forms.TextBox commArg4Txt;
        private System.Windows.Forms.Label commArg4Lbl;
        private System.Windows.Forms.TextBox commArg3Txt;
        private System.Windows.Forms.Label commArg3Lbl;
        private System.Windows.Forms.TextBox commArg2Txt;
        private System.Windows.Forms.Label commArg2Lbl;
        private System.Windows.Forms.TextBox commArg1Txt;
        private System.Windows.Forms.Label commArg1Lbl;
        private System.Windows.Forms.Button startCommBtn;
        private System.Windows.Forms.ListBox commListBox;
    }
}