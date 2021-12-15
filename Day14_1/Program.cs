using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day14_1 {
	class Program {
		static void Main (string[] args) {

			string[] data = File.ReadAllLines ("data.txt");

			List<char> workingString = data[0].ToCharArray ().ToList ();

			List<(string match, char insert)> replacements = new List<(string, char)> ();

			for (int i = 2; i < data.Length; i++) {
				string[] split = data[i].Split (" -> ");
				replacements.Add ((split[0], split[1][0]));
			}

			for (int i = 0; i < 10; i++) {
				for (int j = 0; j < workingString.Count - 1; j++) {
					string toMatch = workingString[j] + "" + workingString[j + 1];
					for (int k = 0; k < replacements.Count; k++) {
						if (toMatch == replacements[k].match) {
							workingString.Insert (j + 1, replacements[k].insert);
							j++;
						}
					}
				}
			}

			List<(char c, int count)> occurences = new List<(char, int)> ();
			foreach (var a in workingString.GroupBy (t => t)) {
				Console.WriteLine ($"{a.Key} {a.Count ()}");
				occurences.Add ((a.Key, a.Count ()));
			}

			occurences.Sort (delegate ((char c, int count) a, (char c, int count) b) { return a.count.CompareTo (b.count); });
			Console.WriteLine (occurences[^1].count - occurences[0].count);
		}
	}
}
