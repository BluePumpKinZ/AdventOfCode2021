using System;
using System.IO;
using System.Linq;

namespace Day7_2 {
	class Program {
		static void Main (string[] args) {
			string[] data = File.ReadAllText ("data.txt").Split (",");

			int[] points = new int[data.Length];
			for (int i = 0; i < points.Length; i++) {
				points[i] = int.Parse (data[i]);
			}

			int minIndex = -1;
			int minCount = int.MaxValue;
			for (int i = 0; i < 2000; i++) {
				int goal = i;
				int total = 0;
				for (int j = 0; j < points.Length; j++) {
					total += GetFuelConsumption (Math.Abs (points[j] - goal));
				}
				if (total < minCount) {
					minCount = total;
					minIndex = goal;
				}
			}
			Console.WriteLine (minCount);
		}

		static int GetFuelConsumption (int steps) {
			int total = 0;
			for (int i = 1; i <= steps; i++)
				total += i;
			return total;
		}
	}
}