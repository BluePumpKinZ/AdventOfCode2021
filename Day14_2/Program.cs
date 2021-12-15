using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day14_2 {
	class Program {

		private static List<(string match, char insert)> replacements;

		static void Main (string[] args) {

			string[] data = File.ReadAllLines ("data.txt");

			string startString = data[0];

			replacements = new List<(string, char)> ();

			for (int i = 2; i < data.Length; i++) {
				string[] split = data[i].Split (" -> ");
				replacements.Add ((split[0], split[1][0]));
			}

			Dictionary<char, int> occurences = CountChars (startString, 10);
			List<(char c, int count)> occurencesList = new List<(char, int)> ();
			foreach (KeyValuePair<char, int> kvp in occurences)
				occurencesList.Add ((kvp.Key, kvp.Value));

			occurencesList.Sort ((a, b) => a.count.CompareTo (b.count));
			Console.WriteLine (occurencesList[^1].count - occurencesList[0].count);
		}

		private static Dictionary<char, int> CountChars (string input, int iterationsToGo) {
			Dictionary<char, int> dic = new Dictionary<char, int> ();
			if (iterationsToGo == 0) {
				AddToDictionary (dic, input[0], 1);
				AddToDictionary (dic, input[1], 1);
				return dic;
			}
			iterationsToGo--;
			Dictionary<char, int> dicsList = new Dictionary<char, int> ();
			for (int i = 0; i < replacements.Count; i++) {
				if (input == replacements[i].match)
					dicsList.Add (CountChars (input, iterationsToGo));
			}
			dic = SumDictionaries (dicsList);
			return dic;
		}

		private static void AddToDictionary (Dictionary<char, int> dic, char c, int count) {
			dic.TryGetValue (c, out int ogValue);
			ogValue += count;
			dic[c] = ogValue;
		}

		private static Dictionary<char, int> SumDictionaries (Dictionary<char, int>[] dics) {
			Dictionary<char, int> sum = new Dictionary<char, int> ();
			for (int i = 0; i < dics.Length; i++) {
				foreach (KeyValuePair<char, int> kvp in dics[i]) {
					AddToDictionary (sum, kvp.Key, kvp.Value);
				}
			}

			return sum;

		}
	}
}