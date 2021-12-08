using System;
using System.Collections.Generic;
using System.IO;

namespace Day8_1 {
	class Program {
		static void Main (string[] args) {

			string[] data = File.ReadAllLines ("data.txt");

			List<(string reading, string output)> values = new List<(string readings, string output)> ();
			for (int i = 0; i < data.Length; i++) {
				string[] split = data[i].Split (" | ");
				values.Add ((split[0], split[1]));
			}
			long total = 0;
			for (int i = 0; i < values.Count; i++) {
				string[] outputs = values[i].output.Split (' ');
				for (int j = 0; j < outputs.Length; j++) {
					switch (outputs[j].Length) {
					case 2: // 1
						total++;
						break;
					case 3: // 7
						total++;
						break;
					case 4: // 4
						total++;
						break;
					case 7: // 8
						total++;
						break;
					}
				}
			}
			Console.WriteLine (total);
		}
	}
}
