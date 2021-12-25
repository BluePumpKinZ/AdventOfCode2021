using System;
using System.IO;

namespace Day25_1 {

	class Program {

		static void Main (string[] args) {
			Console.WriteLine ("Hello World!");

			string[] data = File.ReadAllLines ("data.txt");

			char[][] grid = new char[data.Length][];
			for (int i = 0; i < data.Length; i++) {
				grid[i] = data[i].ToCharArray ();
			}

			int width = data[0].Length;
			int height = data.Length;

			int totalLoops = 0;

			while (true) {
				totalLoops++;
				bool edited = false;

				bool[][] canMove = new bool[height][];
				for (int i = 0; i < canMove.Length; i++)
					canMove[i] = new bool[width];

				for (int y = 0; y < height; y++) {
					for (int x = 0; x < width; x++) {
						if (grid[y][x] != '>')
							continue;
						int xIndex = (x + 1) % width;
						if (grid[y][xIndex] == '.')
							canMove[y][x] = true;
					}
				}

				for (int y = 0; y < height; y++) {
					for (int x = 0; x < width; x++) {
						if (!canMove[y][x])
							continue;
						grid[y][x] = '.';
						int xIndex = (x + 1) % width;
						grid[y][xIndex] = '>';
						edited = true;
					}
				}
				//
				canMove = new bool[height][];
				for (int i = 0; i < canMove.Length; i++)
					canMove[i] = new bool[width];

				for (int y = 0; y < height; y++) {
					for (int x = 0; x < width; x++) {
						if (grid[y][x] != 'v')
							continue;
						int yIndex = (y + 1) % height;
						if (grid[yIndex][x] == '.')
							canMove[y][x] = true;
					}
				}

				for (int y = 0; y < height; y++) {
					for (int x = 0; x < width; x++) {
						if (!canMove[y][x])
							continue;
						grid[y][x] = '.';
						int yIndex = (y + 1) % height;
						grid[yIndex][x] = 'v';
						edited = true;
					}
				}
				//
				canMove = new bool[height][];
				for (int i = 0; i < canMove.Length; i++)
					canMove[i] = new bool[width];

				for (int y = 0; y < height; y++) {
					for (int x = 0; x < width; x++) {
						if (grid[y][x] != '<')
							continue;
						int xIndex = (x - 1 + width) % width;
						if (grid[y][xIndex] == '.')
							canMove[y][x] = true;
					}
				}

				for (int y = 0; y < height; y++) {
					for (int x = 0; x < width; x++) {
						if (!canMove[y][x])
							continue;
						grid[y][x] = '.';
						int xIndex = (x - 1 + width) % width;
						grid[y][xIndex] = '<';
						edited = true;
					}
				}
				if (!edited) {
					Console.Write (totalLoops);
					return;
				}
				edited = false;
			}


		}

	}

}
