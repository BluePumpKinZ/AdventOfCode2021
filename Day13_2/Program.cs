using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day13_2 {
	class Program {
		static void Main (string[] args) {

			string[] data = File.ReadAllLines ("data.txt");

			List<(int x, int y)> pairs = new List<(int, int)> ();
			List<(char axis, int pos)> folds = new List<(char, int)> ();

			for (int i = 0; i < data.Length; i++) {
				if (data[i] == "")
					continue;
				if (data[i].StartsWith ("fold along ")) {
					string[] split = data[i].Split ('=');
					folds.Add ((split[0][^1], int.Parse (split[1])));
				} else {
					string[] split = data[i].Split (',');
					pairs.Add ((int.Parse (split[0]), int.Parse (split[1])));
				}
			}

			for (int i = 0; i < folds.Count; i++) {
				for (int j = 0; j < pairs.Count; j++) {
					pairs[j] = folds[i].axis == 'x' ? FoldX (pairs[j], folds[i].pos) : FoldY (pairs[j], folds[i].pos);
				}

				pairs = pairs.Distinct ().ToList ();
			}

			bool[][] screen = new bool[6][];
			for (int i = 0; i < screen.Length; i++) {
				screen[i] = new bool[39];
			}
			foreach (var p in pairs)
				screen[p.y][p.x] = true;

			for (int i = 0; i < screen.Length; i++) {
				for (int j = 0; j < screen[i].Length; j++) {
					Console.Write (screen[i][j] ? '#' : ' ');
				}
				Console.WriteLine ();
			}
		}

		static (int, int) FoldX ((int x, int y) pair, int x) {
			if (pair.x < x)
				return pair;

			int newX = 2 * x - pair.x;
			return (newX, pair.y);
		}

		static (int, int) FoldY ((int x, int y) pair, int y) {
			if (pair.y < y)
				return pair;

			int newY = 2 * y - pair.y;
			return (pair.x, newY);
		}
	}
}