namespace AnubisClient
{
    partial class Oculus_Form
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
            this.btn_startVrPlayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_startVrPlayer
            // 
            this.btn_startVrPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_startVrPlayer.Location = new System.Drawing.Point(61, 95);
            this.btn_startVrPlayer.Name = "btn_startVrPlayer";
            this.btn_startVrPlayer.Size = new System.Drawing.Size(147, 47);
            this.btn_startVrPlayer.TabIndex = 0;
            this.btn_startVrPlayer.Text = "Start VrPlayer";
            this.btn_startVrPlayer.UseVisualStyleBackColor = true;
            this.btn_startVrPlayer.Click += new System.EventHandler(this.btn_startVrPlayer_Click);
            // 
            // Oculus_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btn_startVrPlayer);
            this.Name = "Oculus_Form";
            this.Text = "Oculus_Form";
            this.Activated += new System.EventHandler(this.Oculus_Form_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Oculus_Form_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_startVrPlayer;
    }
}