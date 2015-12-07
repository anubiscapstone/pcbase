using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AnubisClient {
	public class Johnny5 : ControlInterface {
		private int[] servoPositions;

        public Johnny5(CommunicationsInterface commSock)
            : base(commSock)
        {
			servoPositions = new int[17];
            for (int i = 0; i < servoPositions.Length; i++)
            {
                servoPositions[i] = 1500;
            }
		}

		private int angleDecode(double angle) {
            if (angle < 0) return 600;
            if (angle > 180) return 2400;
            return (int)(angle * 10) + 600;
		}

		private string createVector() {
			string vec = "";

			for (int i = 0; i < servoPositions.Length; i++) {
				int pos = servoPositions[i];
				if (pos >= 0) vec += "#" + i.ToString() + " P" + pos + " ";
				else vec += "#" + i.ToString() + "L ";
			}

			vec += "\r";
			return vec;
		}

		private void storeVector() {
			commSock.sendline("sv " + createVector());
		}

		public override string getHeloString() {
			return "Johnny5";
		}

		public override void updateSkeleton(SkeletonRep mod) {
            servoPositions[13] = angleDecode(mod.Head.Yaw);
            servoPositions[16] = angleDecode(mod.Head.Pitch);

			servoPositions[8] = angleDecode(mod.ShoulderLeft.Roll);
			servoPositions[9] = angleDecode(mod.ShoulderLeft.Pitch);

			servoPositions[3] = angleDecode(mod.ShoulderRight.Roll);
			servoPositions[4] = angleDecode(mod.ShoulderRight.Pitch);

			servoPositions[14] = angleDecode(mod.FootRight.Pitch);
			servoPositions[15] = angleDecode(mod.FootLeft.Pitch);

			// more to come!

			storeVector();
		}

		public override void useNeutralSkeleton() {
			for (int i = 0; i < servoPositions.Length; i++) {
				servoPositions[i] = 1500;
			}
			storeVector();
		}

		public override void useNullSkeleton() {
			for (int i = 0; i < servoPositions.Length; i++) {
				servoPositions[i] = (i == 14 || i == 15 ? 1500 : -1);
			}
			storeVector();
		}

		public override void verifyRobot(EventHandler<GenericEventArgs<bool>> callback) {
			EventHandler<GenericEventArgs<string>> protocallback = (object sender, GenericEventArgs<string> e) => {
				callback(sender, new GenericEventArgs<bool>(e.payload == createVector()));
			};
			commSock.solicitResponse("rv", protocallback);
		}

		public override void requestData(string identifier, EventHandler<GenericEventArgs<string>> callback) {
			EventHandler<GenericEventArgs<string>> protocallback = (object sender, GenericEventArgs<string> e) => {
				// process the response, if needed
				callback(sender, e);
			};
            commSock.solicitResponse("rd " + identifier, protocallback);
		}

		public override void ping(EventHandler<GenericEventArgs<long>> callback) {
			Stopwatch timer = new Stopwatch();
			EventHandler<GenericEventArgs<string>> protocallback = (object sender, GenericEventArgs<string> e) => {
				timer.Stop();
				callback(sender, new GenericEventArgs<long>(timer.ElapsedMilliseconds));
			};
			timer.Start();
            commSock.solicitResponse("pg", protocallback);
		}
	}
}
