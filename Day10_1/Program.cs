using System;
using System.Collections.Generic;
using System.IO;

namespace Day10_1 {
	class Program {

		public enum Brackets {
			Square, Round, Curly, Tag
		}

		static void Main (string[] args) {

			string[] data = File.ReadAllLines ("data.txt");

			int total = 0;
			for (int i = 0; i < data.Length; i++) {
				total += GetLineScore (data[i]);
			}
			Console.WriteLine (total);

		}

		static int GetLineScore (string line) {
			List<Brackets> brackets = new List<Brackets> ();
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
