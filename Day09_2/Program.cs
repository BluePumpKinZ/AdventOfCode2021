using System;
using System.Collections.Generic;
using System.IO;

namespace Day9_2 {
	class Program {

		private static int width, height;
		private static int[][] points;
		static bool[][] explored;

		static void Main (string[] args) {

			string[] data = File.ReadAllLines ("data.txt");

			points = new int[data.Length][];
			explored = new bool[points.Length][];
			height = data.Length;
			width = data[0].Length;
			for (int i = 0; i < height; i++) {
				points[i] = new int[width];
				explored[i] = new bool[width];
				for (int j = 0; j < width; j++)
					points[i][j] = int.Parse (data[i][j].ToString ());
			}

			List<int> basinSizes = new List<int> ();
			for (int y = 0; y < height; y++) {
				for (int x = 0; x < width; x++) {
					int basinSize = 0;
					GetBasinSize (x, y, ref basinSize);
					if (basinSize > 0)
						basinSizes.Add (basinSize);
				}
			}
			basinSizes.Sort ();
			basinSizes.Reverse ();
			Console.WriteLine (basinSizes[0] * basinSizes[1] * basinSizes[2]);

		}

		static void GetBasinSize (int x, int y, ref int totalSize) {
			if (x > 0 && !explored[y][x - 1] && points[y][x - 1] != 9) {
				explored[y][x - 1] = true;
				totalSize++;
				GetBasinSize (x - 1, y, ref totalSize);
			}
			if (x < width - 1 && !explored[y][x + 1] && points[y][x + 1] != 9) {
				explored[y][x + 1] = true;
				totalSize++;
				GetBasinSize (x + 1, y, ref totalSize);
			}
			if (y > 0 && !explored[y - 1][x] && points[y - 1][x] != 9) {
				explored[y - 1][x] = true;
				totalSize++;
				GetBasinSize (x, y - 1, ref totalSize);
			}
			if (y < height - 1 && !explored[y + 1][x] && points[y + 1][x] != 9) {
				explored[y + 1][x] = true;
				totalSize++;
				GetBasinSize (x, y + 1, ref totalSize);
			}
		}
	}
}
