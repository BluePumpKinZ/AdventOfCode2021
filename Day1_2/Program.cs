using System;
using System.Collections.Generic;
using System.IO;

namespace Day1_2 {
	class Program {
		static void Main (string[] args) {

			List<int> data = new List<int> ();
			string[] strings = File.ReadAllLines ("data.txt");
			for (int i = 0; i < strings.Length; i++) {
				data.Add (int.Parse (strings[i]));
			}

			int count = 0;
			for (int i = 3; i < data.Count; i++) {
				int current = data[i] + data[i - 1] + data[i - 2];
				int last = data[i - 1] + data[i - 2] + data[i - 3];
				if (current > last)
					count++;
			}
			Console.WriteLine (count);

		}
	}
}
