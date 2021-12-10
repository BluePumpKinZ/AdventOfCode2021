using System;
using System.IO;

namespace Day2_2 {
	class Program {
		static void Main (string[] args) {
			long forward = 0;
			long depth = 0;
			long aim = 0;

			foreach (string s in File.ReadAllLines ("data.txt")) {
				string[] split = s.Split (' ');
				int amount = int.Parse (split[1]);
				switch (split[0]) {
				case "forward":
					forward += amount;
					depth += aim * amount;
					break;
				case "up":
					aim -= amount;
					break;
				case "down":
					aim += amount;
					break;
				}
			}
			Console.WriteLine (forward * depth);
		}
	}
}