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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.sensorListBox = new System.Windows.Forms.ListBox();
            this.refreshSensorsBtn = new System.Windows.Forms.Button();
            this.streamViewer1 = new AnubisClient.StreamViewer();
            this.startSensorBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
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
            // streamViewer1
            // 
            this.streamViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.streamViewer1.Location = new System.Drawing.Point(23, 24);
            this.streamViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.streamViewer1.Name = "streamViewer1";
            this.streamViewer1.Size = new System.Drawing.Size(879, 618);
            this.streamViewer1.TabIndex = 0;
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
    }
}