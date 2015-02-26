using AnubisClient.D_Hardware;
using AudioVisualsLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnubisClient
{
    public partial class Oculus_Form : Form
    {
        private Oculus P_Interface;
        private Timer paintTime;
        private SkeletonRep sRep;
        private DoublyBufferedPane chalkBoard;
        public Oculus_Form(Oculus Interface)
        {
            InitializeComponent();
            this.Name = "oculus";
            P_Interface = Interface;
            paintTime = new Timer();
            paintTime.Interval = 20;
            paintTime.Tick += paintTime_Tick;

            chalkBoard = new DoublyBufferedPane();
            chalkBoard.Location = new Point(12, 12);
            chalkBoard.Size = new System.Drawing.Size(250, 250);
            Controls.Add(chalkBoard);
            
            chalkBoard.Paint += pn_OcGrid_Paint;

            sRep = new SkeletonRep();
           
        }

        void paintTime_Tick(object sender, EventArgs e)
        {
            P_Interface.modifyModel(sRep);

            Graphics g = chalkBoard.getGraphics();
            g.Clear(Color.White);
            Pen blackLine = new Pen(Brushes.Black, 3);
            Brush redDot = new SolidBrush(Color.Red);

            g.DrawLine(blackLine, 0, 125, 250, 125);
            g.DrawLine(blackLine, 125, 0, 125, 250);

            g.FillEllipse(redDot, (float)sRep.Head.Yaw, (float)sRep.Head.Pitch, 5, 5);

            chalkBoard.Refresh();
        }

        void pn_OcGrid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Oculus_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void Oculus_Form_Activated(object sender, EventArgs e)
        {
            paintTime.Start();
            P_Interface.OpenVRPlayer();
        }



    }
}
