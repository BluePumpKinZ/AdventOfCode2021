using System;
using System.Collections.Generic;
using System.IO;

namespace Day6_1 {
	class Program {
		static void Main (string[] args) {

			string data = File.ReadAllText ("data.txt");
			
			string[] dataStrings = data.Split (",");
			List<long> fishes = new List<long> (dataStrings.Length);
			for (int i = 0; i < dataStrings.Length; i++) {
				fishes.Add (int.Parse (dataStrings[i]));
			}

			for (int i = 0; i < 80; i++) {
				long newFishes = 0;
				for (int j = 0; j < fishes.Count; j++) {
					fishes[j]--;
					if (fishes[j] == -1) {
						fishes[j] = 6;
						newFishes++;
					}
				}
				for (int j = 0; j < newFishes; j++)
					fishes.Add (8);
				
			}
			Console.WriteLine (fishes.Count);

		}
	}
}
