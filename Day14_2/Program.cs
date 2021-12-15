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

			Dictionary<char, long> sum = new Dictionary<char, long> ();
			for (int i = 0; i < startString.Length - 1; i++) {
				sum = SumDictionaries (sum, CountCharsCached (startString[i] + "" + startString[i + 1], 40));
			}
			AddToDictionary (sum, startString[^1], 1);
			List<(char c, long count)> occurencesList = new List<(char, long)> ();
			foreach (KeyValuePair<char, long> kvp in sum)
				occurencesList.Add ((kvp.Key, kvp.Value));

			occurencesList.Sort ((a, b) => a.count.CompareTo (b.count));
			Console.WriteLine (occurencesList[^1].count - occurencesList[0].count);
		}

		private static Dictionary<(string input, int iterationsToGo), Dictionary<char, long>> cache = new Dictionary<(string input, int iterationsToGo), Dictionary<char, long>> ();
		private static Dictionary<char, long> CountCharsCached (string input, int iterationsToGo) {

			var key = (input, iterationsToGo);

			if (cache.TryGetValue (key, out Dictionary<char, long> dic)) {
				return dic;
			}
			else {
				Dictionary<char, long> newValue = CountChars (input, iterationsToGo);
				cache.Add (key, newValue);

				return newValue;
			}
		}

		private static Dictionary<char, long> CountChars (string input, int iterationsToGo) {
			if (iterationsToGo == 0) {
				Dictionary<char, long> dic = new Dictionary<char, long> ();
				AddToDictionary (dic, input[0], 1);
				// AddToDictionary (dic, input[1], 1);
				return dic;
			}
			iterationsToGo--;

			(string match, char insert) replacement = default;
			for (int i = 0; i < replacements.Count; i++) {
				string match = replacements[i].match;
				if (input == match) {
					replacement = replacements[i];
					break;
				}
			}

			if (replacement != default) {

				Dictionary<char, long> a = CountCharsCached (input[0] + "" + replacement.insert, iterationsToGo);
				Dictionary<char, long> b = CountCharsCached (replacement.insert + "" + input[1], iterationsToGo);

				return SumDictionaries (a, b);

			}

			return CountChars (input, 0);
		}

		private static void AddToDictionary (Dictionary<char, long> dic, char c, long count) {
			dic.TryGetValue (c, out long ogValue);
			ogValue += count;
			dic[c] = ogValue;
		}

		private static Dictionary<char, long> SumDictionaries (params Dictionary<char, long>[] dics) {
			Dictionary<char, long> sum = new Dictionary<char, long> ();
			for (int i = 0; i < dics.Length; i++) {
				foreach (KeyValuePair<char, long> kvp in dics[i]) {
					AddToDictionary (sum, kvp.Key, kvp.Value);
				}
			}

			return sum;

		}
	}
}