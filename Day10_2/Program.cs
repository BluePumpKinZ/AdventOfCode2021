using System;
using System.Collections.Generic;
using System.IO;

namespace Day10_2 {
	class Program {

		public enum Brackets {
			Square, Round, Curly, Tag
		}

		static void Main (string[] args) {

			string[] data = File.ReadAllLines ("data.txt");

			List<long> totals = new List<long> ();
			for (int i = 0; i < data.Length; i++) {
				if (GetLineScore (data[i], out List<Brackets> brackets) == 0) {
					long score = 0;
					brackets.Reverse ();
					for (int j = 0; j < brackets.Count; j++) {
						score *= 5;
						switch (brackets[j]) {
						case Brackets.Round:
							score += 1;
							break;
						case Brackets.Square:
							score += 2;
							break;
						case Brackets.Curly:
							score += 3;
							break;
						case Brackets.Tag:
							score += 4;
							break;
						}
					}
					totals.Add (score);
				}
			}
			totals.Sort ();
			Console.WriteLine (totals[(totals.Count - 1) / 2]);

		}

		static int GetLineScore (string line, out List<Brackets> brackets) {
			brackets = new List<Brackets> ();
			for (int i = 0; i < line.Length; i++) {
				switch (line[i]) {
				case '(':
					brackets.Add (Brackets.Round);
					break;
				case '[':
					brackets.Add (Brackets.Square);
					break;
				case '{':
					brackets.Add (Brackets.Curly);
					break;
				case '<':
					brackets.Add (Brackets.Tag);
					break;
				case ')':
					if (brackets[^1] != Brackets.Round)
						return 3;
					brackets.RemoveAt (brackets.Count - 1);
					break;
				case ']':
					if (brackets[^1] != Brackets.Square)
						return 57;
					brackets.RemoveAt (brackets.Count - 1);
					break;
				case '}':
					if (brackets[^1] != Brackets.Curly)
						return 1197;
					brackets.RemoveAt (brackets.Count - 1);
					break;
				case '>':
					if (brackets[^1] != Brackets.Tag)
						return 25137;
					brackets.RemoveAt (brackets.Count - 1);
					break;
				}
			}

			return 0;
		}
	}
}