using System;
using System.IO;

namespace Day20_1 {
	class Program {

		static void Main () {

			string[] data = File.ReadAllLines ("data.txt");

			string pattern = data[0];

			char[][] grid = new char[data.Length - 2][];
			for (int i = 0; i < grid.Length; i++) {
				grid[i] = data[i + 2].ToCharArray ();
			}
			for (int i = 0; i < 50; i++) {
				DoIter (ref grid, pattern);
			}
			int count = 0;
			for (int i = 0; i < grid.Length; i++) {
				for (int j = 0; j < grid[0].Length; j++) {
					if (grid[i][j] == '#')
						count++;
				}
			}
			Console.WriteLine (count);

		}

		static void DoIter (ref char[][] grid, string pattern) {

			char[][] newGrid = new char[grid.Length][];
			for (int i = 0; i < newGrid.Length; i++) {
				newGrid[i] = new char[grid[0].Length];
			}

			for (int y = 1; y < grid.Length - 1; y++) {
				for (int x = 1; x < grid.Length - 1; x++) {
					int index = (grid[y - 1][x - 1] == '#' ? 256 : 0) +
								(grid[y - 1][x] == '#' ? 128 : 0) +
								(grid[y - 1][x + 1] == '#' ? 64 : 0) +
								(grid[y][x - 1] == '#' ? 32 : 0) +
								(grid[y][x] == '#' ? 16 : 0) +
								(grid[y][x + 1] == '#' ? 8 : 0) +
								(grid[y + 1][x - 1] == '#' ? 4 : 0) +
								(grid[y + 1][x] == '#' ? 2 : 0) +
								(grid[y + 1][x + 1] == '#' ? 1 : 0);
					newGrid[y][x] = pattern[index];
				}
			}

			grid = newGrid;
			char fillBorder = grid[1][1];
			for (int i = 0; i < grid[0].Length; i++)
				grid[0][i] = fillBorder;

			for (int i = 0; i < grid[^1].Length; i++)
				grid[^1][i] = fillBorder;

			for (int i = 0; i < grid.Length; i++)
				grid[i][0] = fillBorder;

			for (int i = 0; i < grid.Length; i++)
				grid[i][^1] = fillBorder;
		}

	}
}
