using System;
using System.IO;

namespace Day2_1 {
	class Program {
		static void Main (string[] args) {
			int forward = 0;
			int depth = 0;

			foreach (string s in File.ReadAllLines ("data.txt")) {
				string[] split = s.Split (' ');
				int amount = int.Parse (split[1]);
				switch (split[0]) {
				case "forward":
					forward += amount;
					break;
				case "up":
					depth -= amount;
					break;
				case "down":
					depth += amount;
					break;
				}
			}
			Console.WriteLine (forward * depth);
		}
	}
}
