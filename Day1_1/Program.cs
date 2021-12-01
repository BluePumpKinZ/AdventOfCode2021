using System;
using System.Collections.Generic;
using System.IO;

namespace Day1_1 {
	class Program {
		static void Main (string[] args) {

			List<int> data = new List<int> ();
			string[] strings = File.ReadAllLines ("data.txt");
			for (int i = 0; i < strings.Length; i++) {
				data.Add (int.Parse(strings[i]));
			}

			int count = 0;
			for (int i = 1; i < data.Count; i++) {
				if (data[i] > data[i - 1])
					count++;
			}
			Console.WriteLine (count);

		}
	}
}
