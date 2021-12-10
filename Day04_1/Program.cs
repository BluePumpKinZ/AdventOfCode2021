using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4_1 {
	class Program {
		static void Main (string[] args) {

			List<string> strings = File.ReadAllLines ("data.txt").ToList ();
			strings = strings.Where (s => s != "").ToList ();
			string orderString = strings[0];
			strings.RemoveAt (0);
			string[] orderStrings = orderString.Split (",");
			int[] order = new int[orderStrings.Length];
			for (int i = 0; i < order.Length; i++) {
				order[i] = int.Parse (orderStrings[i]);
			}

			List<int[][]> boards = new List<int[][]> ();
			for (int i = 0; i < strings.Count; i += 5) {
				int[][] board = new int[5][];
				for (int j = 0; j < 5; j++) {
					string lineString = strings[i + j];
					lineString = lineString.Replace ("  ", " ").Trim ();
					string[] numbers = lineString.Split (' ');
					int[] line = new int[5];
					for (int k = 0; k < 5; k++) {
						line[k] = int.Parse (numbers[k]);
					}
					board[j] = line;
				}
				boards.Add (board);
			}

			for (int i = 0; i < order.Length; i++) {
				for (int j = 0; j < boards.Count; j++) {
					ReplaceValue (boards[j], order[i]);
				}

				for (int j = 0; j < boards.Count; j++) {
					if (HasWon (boards[j])) {

						int total = 0;
						for (int x = 0; x < 5; x++) {
							for (int y = 0; y < 5; y++) {
								total += Math.Max (boards[j][y][x], 0);
							}
						}
						int score = total * order[i];
						Console.WriteLine (score);

						return;
					}
				}
			}


		}

		static void ReplaceValue (int[][] board, int value) {
			for (int x = 0; x < 5; x++) {
				for (int y = 0; y < 5; y++) {
					if (board[y][x] == value)
						board[y][x] = -1;
				}
			}
		}

		static bool HasWon (int[][] board) {

			// Vertical Stripes
			bool won;
			for (int x = 0; x < 5; x++) {
				won = true;
				for (int y = 0; y < 5; y++) {
					if (board[y][x] != -1)
						won = false;
				}
				if (won)
					return true;
			}

			// Horizontal Stripes
			for (int y = 0; y < 5; y++) {
				won = true;
				for (int x = 0; x < 5; x++) {
					if (board[y][x] != -1)
						won = false;
				}
				if (won)
					return true;
			}

			// Diagonals
			won = true;
			for (int i = 0; i < 5; i++) {
				if (board[i][i] != -1)
					won = false;
			}
			if (won)
				return true;

			won = true;
			for (int i = 0; i < 5; i++) {
				if (board[i][4 - i] != -1)
					won = false;
			}
			if (won)
				return true;


			return false;
		}
	}
}
