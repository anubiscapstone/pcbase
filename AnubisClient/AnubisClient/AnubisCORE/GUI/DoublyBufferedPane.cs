using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AudioVisualsLogic {
	public partial class DoublyBufferedPane : UserControl {
		private bool initializationComplete;
		private bool isDisposing;
		private BufferedGraphicsContext backbufferContext;
		private BufferedGraphics backbufferGraphics;
		private Graphics drawingGraphics;

		public DoublyBufferedPane() {
			InitializeComponent();
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			backbufferContext = BufferedGraphicsManager.Current;
			initializationComplete = true;
			RecreateBuffers();
		}

		protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			RecreateBuffers();
			return;
		}

		protected override void Dispose(bool disposing) {
			isDisposing = true;
			if (disposing) {
				if (components != null) components.Dispose();
				if (backbufferGraphics != null) backbufferGraphics.Dispose();
				if (backbufferContext != null) try {
					backbufferContext.Dispose();
				}
				catch { }
			}
			base.Dispose(disposing);
			return;
		}

		private void RecreateBuffers() {
			if (!initializationComplete || isDisposing) return;
			backbufferContext.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
			if (backbufferGraphics != null) backbufferGraphics.Dispose();
			backbufferGraphics = backbufferContext.Allocate(this.CreateGraphics(), new Rectangle(0, 0, Math.Max(this.Width, 1), Math.Max(this.Height, 1)));
			drawingGraphics = backbufferGraphics.Graphics;
			this.Invalidate();
		}

		public Graphics getGraphics() {
			return drawingGraphics;
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			if (!isDisposing && backbufferGraphics != null) backbufferGraphics.Render(e.Graphics);
		}
	}
}