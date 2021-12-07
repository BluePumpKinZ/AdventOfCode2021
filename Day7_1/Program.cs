using System;
using System.IO;
using System.Linq;

namespace Day7_1 {
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
					total += Math.Abs (points[j] - goal);
				}
				if (total < minCount) {
					minCount = total;
					minIndex = goal;
				}
			}
			Console.WriteLine (minCount);
		}

	}
}