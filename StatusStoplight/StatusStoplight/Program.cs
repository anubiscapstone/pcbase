using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StatusStoplight {
	public class Program {
        public const string HOST_FILE = "host.conf";
        public const string HELO_FILE = "helo.conf";

		private static Stoplight stl;

		public static void Main(string[] args) {
			// Read server information from host file
			if (!File.Exists(HOST_FILE)) {
				Console.WriteLine("Error: Host file missing");
				return;
			}

			string[] lines = File.ReadAllLines(HOST_FILE);
			if (lines.Length < 2) {
				Console.WriteLine("Error: Malformed host file");
				return;
			}
			string server = lines[0];
			int port;
			try {
				port = int.Parse(lines[1]);
			}
			catch {
				Console.WriteLine("Error: Could not parse port to an integer");
				return;
			}

            // Read HELO String
            if (!File.Exists(HELO_FILE))
            {
                Console.WriteLine("Error: Helo file missing");
                return;
            }

            lines = File.ReadAllLines(HELO_FILE);
            if (lines.Length < 1)
            {
                Console.WriteLine("Error: Malformed helo file");
                return;
            }
            string helo = lines[0];

			// Init stoplight
			stl = new Stoplight();

			// Register an event handler
			Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            // Ready
            Console.WriteLine("Server: " + server + ":" + port.ToString());
            Console.WriteLine("Ident:  " + helo);
            Console.WriteLine("Ready.");
            Console.WriteLine();

			// Server connection Loop
			while (true) {
                Console.WriteLine("Disconnected");
				stl.red();
				Sock s = connectToServer(server, port);
                s.sendline(helo);
                Console.WriteLine("Connected");
				processNet(s);
				s.close();
			}
		}

		private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e) {
			stl.close();
		}

		private static Sock connectToServer(string server, int port) {
			while (true) {
				try {
					Sock s = new Sock(server, port);
					return s;
				}
				catch { }
			}
		}

		private static void processNet(Sock s) {
            Console.WriteLine("Idle");
            string prevLine = "";
			stl.yellow();
			try {
				while (true) {
					string line = s.readline();
					if (line == "s" && prevLine != "s" ) {
                        Console.WriteLine("Active");
						stl.green();
					}

					else if (line == "e") {
                        Console.WriteLine("Idle");
						stl.yellow();
					}

					else if (line == "pg") {
						s.sendline("pg");
					}

					else {
						s.sendline("err");
					}
                    prevLine = line;
				}
			}
			catch {
                int asdfsadf;
            }
		}
	}
}
