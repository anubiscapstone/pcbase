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
            this.NetCommWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ts_ViewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_NetworkMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.activeRobotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscb_RobotMenu = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_HardwareMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.kinect1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscb_HardwareList = new System.Windows.Forms.ToolStripComboBox();
            this.kinect3ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.streamViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_OptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_ViewWindow});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ts_ViewWindow
            // 
            this.ts_ViewWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_NetworkMenu,
            this.ts_HardwareMenu,
            this.streamViewerToolStripMenuItem,
            this.ts_OptionsMenu});
            this.ts_ViewWindow.Name = "ts_ViewWindow";
            this.ts_ViewWindow.Size = new System.Drawing.Size(96, 20);
            this.ts_ViewWindow.Text = "View Windows";
            this.ts_ViewWindow.DropDownClosed += new System.EventHandler(this.ts_ViewWindow_DropDownClosed);
            // 
            // ts_NetworkMenu
            // 
            this.ts_NetworkMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeRobotsToolStripMenuItem,
            this.tscb_RobotMenu,
            this.toolStripSeparator1});
            this.ts_NetworkMenu.Name = "ts_NetworkMenu";
            this.ts_NetworkMenu.Size = new System.Drawing.Size(149, 22);
            this.ts_NetworkMenu.Text = "Network";
            // 
            // activeRobotsToolStripMenuItem
            // 
            this.activeRobotsToolStripMenuItem.Enabled = false;
            this.activeRobotsToolStripMenuItem.Name = "activeRobotsToolStripMenuItem";
            this.activeRobotsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.activeRobotsToolStripMenuItem.Text = "Active Robots";
            // 
            // tscb_RobotMenu
            // 
            this.tscb_RobotMenu.Name = "tscb_RobotMenu";
            this.tscb_RobotMenu.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // ts_HardwareMenu
            // 
            this.ts_HardwareMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kinect1ToolStripMenuItem,
            this.tscb_HardwareList,
            this.kinect3ToolStripMenuItem});
            this.ts_HardwareMenu.Name = "ts_HardwareMenu";
            this.ts_HardwareMenu.Size = new System.Drawing.Size(149, 22);
            this.ts_HardwareMenu.Text = "Hardware";
            // 
            // kinect1ToolStripMenuItem
            // 
            this.kinect1ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Window;
            this.kinect1ToolStripMenuItem.Enabled = false;
            this.kinect1ToolStripMenuItem.Name = "kinect1ToolStripMenuItem";
            this.kinect1ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.kinect1ToolStripMenuItem.Text = "Active Hardware";
            // 
            // tscb_HardwareList
            // 
            this.tscb_HardwareList.Name = "tscb_HardwareList";
            this.tscb_HardwareList.Size = new System.Drawing.Size(152, 23);
            this.tscb_HardwareList.SelectedIndexChanged += new System.EventHandler(this.tscb_HardwareList_SelectedIndexChanged);
            // 
            // kinect3ToolStripMenuItem
            // 
            this.kinect3ToolStripMenuItem.Name = "kinect3ToolStripMenuItem";
            this.kinect3ToolStripMenuItem.Size = new System.Drawing.Size(209, 6);
            // 
            // streamViewerToolStripMenuItem
            // 
            this.streamViewerToolStripMenuItem.Name = "streamViewerToolStripMenuItem";
            this.streamViewerToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.streamViewerToolStripMenuItem.Text = "Stream Viewer";
            this.streamViewerToolStripMenuItem.Click += new System.EventHandler(this.streamViewerToolStripMenuItem_Click);
            // 
            // ts_OptionsMenu
            // 
            this.ts_OptionsMenu.Name = "ts_OptionsMenu";
            this.ts_OptionsMenu.Size = new System.Drawing.Size(149, 22);
            this.ts_OptionsMenu.Text = "Options";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker NetCommWorker;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ts_ViewWindow;
        private System.Windows.Forms.ToolStripMenuItem ts_NetworkMenu;
        private System.Windows.Forms.ToolStripMenuItem ts_HardwareMenu;
        private System.Windows.Forms.ToolStripMenuItem ts_OptionsMenu;
        private System.Windows.Forms.ToolStripComboBox tscb_HardwareList;
        private System.Windows.Forms.ToolStripSeparator kinect3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kinect1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeRobotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tscb_RobotMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem streamViewerToolStripMenuItem;


    }
}