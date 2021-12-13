using System;
using System.IO;

namespace Day11_1 {
	class Program {

		private static int total;

		static void Main () {

			string[] data = File.ReadAllLines ("data.txt");
			int[][] grid = new int[10][];

			for (int i = 0; i < grid.Length; i++) {
				grid[i] = new int[10];
				for (int j = 0; j < 10; j++)
					grid[i][j] = int.Parse (data[i][j].ToString ());
			}

			for (int i = 0; i < 100; i++) {
				bool[][] flashed = new bool[10][];

				for (int j = 0; j < 10; j++)
					flashed[j] = new bool[10];

				for (int y = 0; y < 10; y++) {
					for (int x = 0; x < 10; x++) {
						IncreaseCell (grid, flashed, x, y);
					}
				}

				for (int y = 0; y < 10; y++) {
					for (int x = 0; x < 10; x++) {
						if (grid[y][x] > 9) {
							grid[y][x] = 0;
						}
					}
				}
			}
			Console.WriteLine (total);
		}

		private static void IncreaseCell (int[][] grid, bool[][] flashed, int _x, int _y) {
			grid[_y][_x]++;

			if (grid[_y][_x] != 10)
				return;

			flashed[_y][_x] = true;
			total++;
			int xMin = Math.Max (0, _x - 1);
			int xMax = Math.Min (9, _x + 1);

			int yMin = Math.Max (0, _y - 1);
			int yMax = Math.Min (9, _y + 1);
			for (int x = xMin; x <= xMax; x++) {
				for (int y = yMin; y <= yMax; y++) {
					if (flashed[y][x])
						continue;
					IncreaseCell (grid, flashed, x, y);
				}
			}
		}

		private static bool HasNines (int[][] grid) {
			for (int y = 0; y < 10; y++) {
				for (int x = 0; x < 10; x++) {
					if (grid[y][x] == 9)
						return true;
				}
			}
			return false;
		}
	}
}
