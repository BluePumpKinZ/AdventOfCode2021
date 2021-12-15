using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day15_2 {
	class Program {
		static void Main (string[] args) {

			string[] data = File.ReadAllLines ("data.txt");
			int[][] tempgrid = new int[data.Length][];
			for (int i = 0; i < data.Length; i++) {
				tempgrid[i] = new int[data[i].Length];
				for (int j = 0; j < data[i].Length; j++) {
					tempgrid[i][j] = int.Parse (data[i][j].ToString ());
				}
			}

			int[][] grid = new int[tempgrid.Length * 5][];
			for (int i = 0; i < grid.Length; i++) {
				grid[i] = new int[tempgrid[0].Length * 5];
			}

			for (int i = 0; i < grid.Length; i++) {
				for (int j = 0; j < grid[i].Length; j++) {
					int tempgridI = i % tempgrid.Length;
					int tempgridJ = j % tempgrid[0].Length;
					int extrastep = i / tempgrid.Length + j / tempgrid[0].Length;
					grid[i][j] = (tempgrid[tempgridI][tempgridJ] + extrastep - 1) % 9 + 1;
				}
			}

			int[][] costs = new int[grid.Length][];
			for (int i = 0; i < costs.Length; i++) {
				costs[i] = new int[grid[i].Length];
			}

			// Calculate simple cost values only going right and down
			costs[0][0] = 0;
			for (int i = 1; i < costs.Length * 2; i++) {
				for (int j = 0; j <= i; j++) {
					int x = i - j;
					int y = j;

					if (x >= costs[0].Length)
						continue;

					if (y >= costs.Length)
						continue;

					List<int> possibleCosts = new List<int> ();
					if (x > 0)
						possibleCosts.Add (costs[y][x - 1]);
					if (y > 0)
						possibleCosts.Add (costs[y - 1][x]);

					int cost = grid[y][x] + possibleCosts.Min ();
					costs[y][x] = cost;
				}
			}

			// Calculate full costs
			int iterations = 100;
			for (int k = 0; k < iterations; k++) {
				for (int i = 1; i < costs.Length * 2; i++) {
					for (int j = 0; j <= i; j++) {
						int x = i - j;
						int y = j;

						if (x >= costs[0].Length)
							continue;

						if (y >= costs.Length)
							continue;

						List<int> possibleCosts = new List<int> ();
						possibleCosts.Add (costs[y][x] - grid[y][x]);
						if (x > 0)
							possibleCosts.Add (costs[y][x - 1]);
						if (y > 0)
							possibleCosts.Add (costs[y - 1][x]);

						if (x < costs[0].Length - 1)
							possibleCosts.Add (costs[y][x + 1]);
						if (y < costs.Length - 1)
							possibleCosts.Add (costs[y + 1][x]);

						int cost = grid[y][x] + possibleCosts.Min ();
						costs[y][x] = cost;
					}
				}
			}

			Console.WriteLine (costs[^1][^1]);
		}
	}
}
