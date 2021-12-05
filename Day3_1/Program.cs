using System;
using System.Collections.Generic;
using System.IO;

namespace Day2_1 {
	class Program {
		static void Main (string[] args) {

			int[] counts = new int[12];
			string[] strings = File.ReadAllLines ("data.txt");
			for (int i = 0; i < strings.Length; i++) {
				for (int j = 0; j < 12; j++) {
					switch (strings[i][j]) {
						case '0':
							counts[j] += 1;
							break;
						case '1':
							counts[j] -= 1;
							break;
					}
				}
			}
			int total = 0;
			int andereTotal = 0;
			for (int i = 0; i < 12; i++) {
				total <<= 1;
				total += counts[i] > 0 ? 0 : 1;
				andereTotal <<= 1;
				andereTotal += counts[i] < 0 ? 0 : 1;
			}
			Console.WriteLine (andereTotal * total);
		}
	}
}