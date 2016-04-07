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
            this.stopSensorBtn = new System.Windows.Forms.Button();
            this.activeSensorListBox = new System.Windows.Forms.ListBox();
            this.startSensorBtn = new System.Windows.Forms.Button();
            this.sensorListBox = new System.Windows.Forms.ListBox();
            this.refreshSensorsBtn = new System.Windows.Forms.Button();
            this.stopCommBtn = new System.Windows.Forms.Button();
            this.activeCommListBox = new System.Windows.Forms.ListBox();
            this.commArg5Txt = new System.Windows.Forms.TextBox();
            this.commArg5Lbl = new System.Windows.Forms.Label();
            this.commArg4Txt = new System.Windows.Forms.TextBox();
            this.commArg4Lbl = new System.Windows.Forms.Label();
            this.commArg3Txt = new System.Windows.Forms.TextBox();
            this.commArg3Lbl = new System.Windows.Forms.Label();
            this.commArg2Txt = new System.Windows.Forms.TextBox();
            this.commArg2Lbl = new System.Windows.Forms.Label();
            this.commArg1Txt = new System.Windows.Forms.TextBox();
            this.commArg1Lbl = new System.Windows.Forms.Label();
            this.startCommBtn = new System.Windows.Forms.Button();
            this.commListBox = new System.Windows.Forms.ListBox();
            this.streamViewer1 = new AnubisClient.StreamViewer();
            this.controlListBox = new System.Windows.Forms.ListBox();
            this.stopControlBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stopSensorBtn
            // 
            this.stopSensorBtn.Location = new System.Drawing.Point(1104, 151);
            this.stopSensorBtn.Name = "stopSensorBtn";
            this.stopSensorBtn.Size = new System.Drawing.Size(170, 29);
            this.stopSensorBtn.TabIndex = 4;
            this.stopSensorBtn.Text = "Stop Device";
            this.stopSensorBtn.UseVisualStyleBackColor = true;
            this.stopSensorBtn.Click += new System.EventHandler(this.stopSensorBtn_Click);
            // 
            // activeSensorListBox
            // 
            this.activeSensorListBox.FormattingEnabled = true;
            this.activeSensorListBox.ItemHeight = 16;
            this.activeSensorListBox.Location = new System.Drawing.Point(910, 151);
            this.activeSensorListBox.Name = "activeSensorListBox";
            this.activeSensorListBox.Size = new System.Drawing.Size(170, 100);
            this.activeSensorListBox.TabIndex = 3;
            this.activeSensorListBox.SelectedIndexChanged += new System.EventHandler(this.activeSensorListBox_SelectedIndexChanged);
            // 
            // startSensorBtn
            // 
            this.startSensorBtn.Location = new System.Drawing.Point(1104, 61);
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
            this.sensorListBox.Location = new System.Drawing.Point(910, 13);
            this.sensorListBox.Name = "sensorListBox";
            this.sensorListBox.Size = new System.Drawing.Size(170, 100);
            this.sensorListBox.TabIndex = 1;
            this.sensorListBox.SelectedIndexChanged += new System.EventHandler(this.sensorListBox_SelectedIndexChanged);
            // 
            // refreshSensorsBtn
            // 
            this.refreshSensorsBtn.Location = new System.Drawing.Point(1104, 13);
            this.refreshSensorsBtn.Name = "refreshSensorsBtn";
            this.refreshSensorsBtn.Size = new System.Drawing.Size(170, 29);
            this.refreshSensorsBtn.TabIndex = 0;
            this.refreshSensorsBtn.Text = "Refresh Devices";
            this.refreshSensorsBtn.UseVisualStyleBackColor = true;
            this.refreshSensorsBtn.Click += new System.EventHandler(this.refreshSensorsBtn_Click);
            // 
            // stopCommBtn
            // 
            this.stopCommBtn.Location = new System.Drawing.Point(1103, 421);
            this.stopCommBtn.Name = "stopCommBtn";
            this.stopCommBtn.Size = new System.Drawing.Size(170, 29);
            this.stopCommBtn.TabIndex = 16;
            this.stopCommBtn.Text = "Stop Server";
            this.stopCommBtn.UseVisualStyleBackColor = true;
            this.stopCommBtn.Click += new System.EventHandler(this.stopCommBtn_Click);
            // 
            // activeCommListBox
            // 
            this.activeCommListBox.FormattingEnabled = true;
            this.activeCommListBox.ItemHeight = 16;
            this.activeCommListBox.Location = new System.Drawing.Point(910, 421);
            this.activeCommListBox.Name = "activeCommListBox";
            this.activeCommListBox.Size = new System.Drawing.Size(170, 100);
            this.activeCommListBox.TabIndex = 15;
            this.activeCommListBox.SelectedIndexChanged += new System.EventHandler(this.activeCommListBox_SelectedIndexChanged);
            // 
            // commArg5Txt
            // 
            this.commArg5Txt.Location = new System.Drawing.Point(1569, 365);
            this.commArg5Txt.Name = "commArg5Txt";
            this.commArg5Txt.Size = new System.Drawing.Size(100, 22);
            this.commArg5Txt.TabIndex = 14;
            // 
            // commArg5Lbl
            // 
            this.commArg5Lbl.AutoSize = true;
            this.commArg5Lbl.Location = new System.Drawing.Point(1566, 331);
            this.commArg5Lbl.Name = "commArg5Lbl";
            this.commArg5Lbl.Size = new System.Drawing.Size(46, 17);
            this.commArg5Lbl.TabIndex = 13;
            this.commArg5Lbl.Text = "label5";
            // 
            // commArg4Txt
            // 
            this.commArg4Txt.Location = new System.Drawing.Point(1452, 365);
            this.commArg4Txt.Name = "commArg4Txt";
            this.commArg4Txt.Size = new System.Drawing.Size(100, 22);
            this.commArg4Txt.TabIndex = 12;
            // 
            // commArg4Lbl
            // 
            this.commArg4Lbl.AutoSize = true;
            this.commArg4Lbl.Location = new System.Drawing.Point(1449, 331);
            this.commArg4Lbl.Name = "commArg4Lbl";
            this.commArg4Lbl.Size = new System.Drawing.Size(46, 17);
            this.commArg4Lbl.TabIndex = 11;
            this.commArg4Lbl.Text = "label4";
            // 
            // commArg3Txt
            // 
            this.commArg3Txt.Location = new System.Drawing.Point(1334, 365);
            this.commArg3Txt.Name = "commArg3Txt";
            this.commArg3Txt.Size = new System.Drawing.Size(100, 22);
            this.commArg3Txt.TabIndex = 10;
            // 
            // commArg3Lbl
            // 
            this.commArg3Lbl.AutoSize = true;
            this.commArg3Lbl.Location = new System.Drawing.Point(1331, 331);
            this.commArg3Lbl.Name = "commArg3Lbl";
            this.commArg3Lbl.Size = new System.Drawing.Size(46, 17);
            this.commArg3Lbl.TabIndex = 9;
            this.commArg3Lbl.Text = "label3";
            // 
            // commArg2Txt
            // 
            this.commArg2Txt.Location = new System.Drawing.Point(1218, 365);
            this.commArg2Txt.Name = "commArg2Txt";
            this.commArg2Txt.Size = new System.Drawing.Size(100, 22);
            this.commArg2Txt.TabIndex = 8;
            // 
            // commArg2Lbl
            // 
            this.commArg2Lbl.AutoSize = true;
            this.commArg2Lbl.Location = new System.Drawing.Point(1215, 331);
            this.commArg2Lbl.Name = "commArg2Lbl";
            this.commArg2Lbl.Size = new System.Drawing.Size(46, 17);
            this.commArg2Lbl.TabIndex = 7;
            this.commArg2Lbl.Text = "label2";
            // 
            // commArg1Txt
            // 
            this.commArg1Txt.Location = new System.Drawing.Point(1103, 365);
            this.commArg1Txt.Name = "commArg1Txt";
            this.commArg1Txt.Size = new System.Drawing.Size(100, 22);
            this.commArg1Txt.TabIndex = 6;
            // 
            // commArg1Lbl
            // 
            this.commArg1Lbl.AutoSize = true;
            this.commArg1Lbl.Location = new System.Drawing.Point(1100, 331);
            this.commArg1Lbl.Name = "commArg1Lbl";
            this.commArg1Lbl.Size = new System.Drawing.Size(46, 17);
            this.commArg1Lbl.TabIndex = 5;
            this.commArg1Lbl.Text = "label1";
            // 
            // startCommBtn
            // 
            this.startCommBtn.Location = new System.Drawing.Point(1103, 287);
            this.startCommBtn.Name = "startCommBtn";
            this.startCommBtn.Size = new System.Drawing.Size(170, 29);
            this.startCommBtn.TabIndex = 4;
            this.startCommBtn.Text = "Start Server";
            this.startCommBtn.UseVisualStyleBackColor = true;
            this.startCommBtn.Click += new System.EventHandler(this.startcommBtn_Click);
            // 
            // commListBox
            // 
            this.commListBox.FormattingEnabled = true;
            this.commListBox.ItemHeight = 16;
            this.commListBox.Location = new System.Drawing.Point(910, 287);
            this.commListBox.Name = "commListBox";
            this.commListBox.Size = new System.Drawing.Size(170, 100);
            this.commListBox.TabIndex = 3;
            this.commListBox.SelectedIndexChanged += new System.EventHandler(this.commListBox_SelectedIndexChanged);
            // 
            // streamViewer1
            // 
            this.streamViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.streamViewer1.Location = new System.Drawing.Point(13, 13);
            this.streamViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.streamViewer1.Name = "streamViewer1";
            this.streamViewer1.Size = new System.Drawing.Size(879, 618);
            this.streamViewer1.TabIndex = 0;
            // 
            // controlListBox
            // 
            this.controlListBox.FormattingEnabled = true;
            this.controlListBox.ItemHeight = 16;
            this.controlListBox.Location = new System.Drawing.Point(1303, 13);
            this.controlListBox.Name = "controlListBox";
            this.controlListBox.Size = new System.Drawing.Size(170, 100);
            this.controlListBox.TabIndex = 17;
            // 
            // stopControlBtn
            // 
            this.stopControlBtn.Location = new System.Drawing.Point(1499, 12);
            this.stopControlBtn.Name = "stopControlBtn";
            this.stopControlBtn.Size = new System.Drawing.Size(170, 29);
            this.stopControlBtn.TabIndex = 18;
            this.stopControlBtn.Text = "Stop Device";
            this.stopControlBtn.UseVisualStyleBackColor = true;
            this.stopControlBtn.Click += new System.EventHandler(this.stopControlBtn_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 645);
            this.Controls.Add(this.stopControlBtn);
            this.Controls.Add(this.controlListBox);
            this.Controls.Add(this.streamViewer1);
            this.Controls.Add(this.stopCommBtn);
            this.Controls.Add(this.stopSensorBtn);
            this.Controls.Add(this.activeCommListBox);
            this.Controls.Add(this.commArg5Txt);
            this.Controls.Add(this.activeSensorListBox);
            this.Controls.Add(this.commArg5Lbl);
            this.Controls.Add(this.sensorListBox);
            this.Controls.Add(this.commArg4Txt);
            this.Controls.Add(this.startSensorBtn);
            this.Controls.Add(this.commArg4Lbl);
            this.Controls.Add(this.refreshSensorsBtn);
            this.Controls.Add(this.commArg3Txt);
            this.Controls.Add(this.commListBox);
            this.Controls.Add(this.commArg3Lbl);
            this.Controls.Add(this.startCommBtn);
            this.Controls.Add(this.commArg2Txt);
            this.Controls.Add(this.commArg1Lbl);
            this.Controls.Add(this.commArg2Lbl);
            this.Controls.Add(this.commArg1Txt);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Anubis II";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private StreamViewer streamViewer1;
        private System.Windows.Forms.ListBox sensorListBox;
        private System.Windows.Forms.Button refreshSensorsBtn;
        private System.Windows.Forms.Button startSensorBtn;
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
        private System.Windows.Forms.ListBox activeSensorListBox;
        private System.Windows.Forms.ListBox activeCommListBox;
        private System.Windows.Forms.Button stopSensorBtn;
        private System.Windows.Forms.Button stopCommBtn;
        private System.Windows.Forms.ListBox controlListBox;
        private System.Windows.Forms.Button stopControlBtn;
    }
}