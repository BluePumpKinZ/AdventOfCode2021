using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3_2 {
	class Program {
		static void Main (string[] args) {

			int digits = 12;
			// int[] counts = new int[12];
			List<string> strings = File.ReadAllLines ("data.txt").ToList ();
			for (int i = 0; i < digits; i++) {
				int bias = 0;
				strings.ForEach (s => bias += s[i] == '1' ? 1 : -1);
				strings = strings.Where (s => s[i] == (bias >= 0 ? '1' : '0')).ToList ();
				if (strings.Count == 1)
					break;
			}
			string result = strings[0];

			strings = File.ReadAllLines ("data.txt").ToList ();
			for (int i = 0; i < digits; i++) {
				int bias = 0;
				strings.ForEach (s => bias += s[i] == '1' ? 1 : -1);
				strings = strings.Where (s => s[i] == (bias >= 0 ? '0' : '1')).ToList ();
				if (strings.Count == 1)
					break;
			}
			string result1 = strings[0];

			int total = 0;
			int andereTotal = 0;
			for (int i = 0; i < digits; i++) {
				total <<= 1;
				total += result[i] == '0' ? 0 : 1;
				andereTotal <<= 1;
				andereTotal += result1[i] == '0' ? 0 : 1;
			}
			Console.WriteLine (total * andereTotal);
		}
	}
}