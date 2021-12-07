using System;
using System.IO;
using System.Linq;

namespace Day6_2 {
	class Program {
		static void Main (string[] args) {
			string data = File.ReadAllText ("data.txt");

			string[] dataStrings = data.Split (",");

			long[] fishes = new long[9];
			for (int i = 0; i < dataStrings.Length; i++) {
				fishes[int.Parse (dataStrings[i])]++;
			}

			for (int i = 0; i < 256; i++) {
				long zeros = fishes[0];
				for (int j = 1; j <= 8; j++) {
					fishes[j - 1] = fishes[j];
				}
				fishes[6] += zeros;
				fishes[8] = zeros;
			}

			long total = 0;
			for (int i = 0; i < fishes.Length; i++)
				total += fishes[i];

			Console.WriteLine (total);
		}
	}
}
