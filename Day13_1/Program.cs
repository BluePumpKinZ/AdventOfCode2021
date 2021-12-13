using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day13_1 {
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
					pairs.Add ((int.Parse(split[0]), int.Parse (split[1])));
				}
			}

			for (int i = 0; i < 1; i++) {
				for (int j = 0; j < pairs.Count; j++) {
					pairs[j] = folds[i].axis == 'x' ? FoldX (pairs[j], folds[i].pos) : FoldY (pairs[j], folds[i].pos);
				}

				pairs = pairs.Distinct ().ToList ();
			}
			Console.WriteLine (pairs.Count);
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
