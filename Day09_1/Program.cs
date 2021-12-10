using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day9_1 {
	class Program {

		private static int width, height;

		static void Main (string[] args) {

			string[] data = File.ReadAllLines ("data.txt");

			int[][] points = new int[data.Length][];
			height = data.Length;
			width = data[0].Length;
			for (int i = 0; i < height; i++) {
				points[i] = new int[width];
				for (int j = 0; j < width; j++)
					points[i][j] = int.Parse (data[i][j].ToString ());
			}

			int totalRisk = 0;

			for (int y = 0; y < height; y++) {
				for (int x = 0; x < width; x++) {
					if (IsLowPoint (points, x, y))
						totalRisk += points[y][x] + 1;
				}
			}
			Console.WriteLine (totalRisk);
		}

		static bool IsLowPoint (int[][] points, int x, int y) {
			List<int> neighbours = new List<int> ();
			if (x > 0)
				neighbours.Add (points[y][x - 1]);
			if (x < width - 1)
				neighbours.Add (points[y][x + 1]);
			if (y > 0)
				neighbours.Add (points[y - 1][x]);
			if (y < height - 1)
				neighbours.Add (points[y + 1][x]);

			return points[y][x] < neighbours.Min ();
		}
	}
}
