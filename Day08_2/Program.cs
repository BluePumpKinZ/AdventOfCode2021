using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8_2 {
	class Program {
		static void Main (string[] args) {

			string[] data = File.ReadAllLines ("data.txt");

			List<(string reading, string output)> values = new List<(string readings, string output)> ();
			for (int i = 0; i < data.Length; i++) {
				string[] split = data[i].Split (" | ");
				values.Add ((split[0], split[1]));
			}

			int total = 0;
			for (int i = 0; i < values.Count; i++) {

				string[] readings = values[i].reading.Split (' ');
				string[] outputs = values[i].output.Split (' ');


				/////////////// PARSING READINGS ///////////////

				char top, topLeft, topRight, middle, bottomLeft, bottomRight, bottom;

				string one, two, three, four, five, six, seven, eight, nine, zero;
				one = readings.Single (s => s.Length == 2);
				seven = readings.Single (s => s.Length == 3);
				four = readings.Single (s => s.Length == 4);
				eight = readings.Single (s => s.Length == 7);

				top = RemoveCharsAndReturnOne (seven, one); // A seven has an extra segment on top compared to a one.

				List<string> sixNineAndZero = readings.Where (s => s.Length == 6).ToList ();
				six = null; // String will get assigned in the following brackets
				for (int j = 0; j < 3; j++) {
					if (RemoveCharsAndReturnOne (one, sixNineAndZero[j]) != '\0')
						six = sixNineAndZero[j];
				}

				// 6 is only missing one segment
				topRight = RemoveCharsAndReturnOne (eight, six);

				// 1 is the combination of topRight and bottomRight
				bottomRight = RemoveCharsAndReturnOne (one, topRight.ToString ());

				List<string> nineAndZero = sixNineAndZero;
				nineAndZero.Remove (six);

				// subtracting 0 from 4 leaves the middle segment but not for 9
				if (RemoveCharsAndReturnOne (four, nineAndZero[0]) != '\0') {
					zero = nineAndZero[0];
					nine = nineAndZero[1];
				} else {
					nine = nineAndZero[0];
					zero = nineAndZero[1];
				}
				bottomLeft = RemoveCharsAndReturnOne (eight, nine);
				middle = RemoveCharsAndReturnOne (eight, zero);

				List<string> twoThreeAndFive = readings.ToList ();
				twoThreeAndFive.Remove (one);
				twoThreeAndFive.Remove (four);
				twoThreeAndFive.Remove (six);
				twoThreeAndFive.Remove (seven);
				twoThreeAndFive.Remove (eight);
				twoThreeAndFive.Remove (nine);
				twoThreeAndFive.Remove (zero);

				two = null; // String will get assigned in the following brackets
				for (int j = 0; j < twoThreeAndFive.Count; j++) {
					if (twoThreeAndFive[j].Contains (bottomLeft))
						two = twoThreeAndFive[j];
				}

				List<string> threeAndFive = twoThreeAndFive;
				threeAndFive.Remove (two);

				// A three has the topRight segment, five does not
				if (threeAndFive[0].Contains (topRight)) {
					three = threeAndFive[0];
					five = threeAndFive[1];
				} else {
					five = threeAndFive[0];
					three = threeAndFive[1];
				}
				
				// Subtracting both one and two from zero leaves only the topleft segment
				topLeft = RemoveCharsAndReturnOne (RemoveChars (zero, one), two);

				// Substracting every segment except the bottom gives the bottom
				bottom = RemoveCharsAndReturnOne (eight, new string(new char[]{ top, topLeft, topRight, middle, bottomLeft, bottomRight }));

				one = sortCharsInString (one);
				two = sortCharsInString (two);
				three = sortCharsInString (three);
				four = sortCharsInString (four);
				five = sortCharsInString (five);
				six = sortCharsInString (six);
				seven = sortCharsInString (seven);
				eight = sortCharsInString (eight);
				nine = sortCharsInString (nine);
				zero = sortCharsInString (zero);


				/////////////// PARSING OUTPUT ///////////////

				for (int j = 0; j < outputs.Length; j++) {
					outputs[j] = sortCharsInString (outputs[j]);
				}

				int number = 0;
				for (int j = 0; j < outputs.Length; j++) {
					number *= 10;
					if (outputs[j] == one) {
						number += 1;
					} else if (outputs[j] == two) {
						number += 2;
					} else if (outputs[j] == three) {
						number += 3;
					} else if (outputs[j] == four) {
						number += 4;
					} else if (outputs[j] == five) {
						number += 5;
					} else if (outputs[j] == six) {
						number += 6;
					} else if (outputs[j] == seven) {
						number += 7;
					} else if (outputs[j] == eight) {
						number += 8;
					} else if (outputs[j] == nine) {
						number += 9;
					} else if (outputs[j] == zero) {
						number += 0;
					} else {
						throw new ArgumentException ("Number could be not found");
					}
				}
				total += number;
			}
			Console.WriteLine (total);
		}

		static string sortCharsInString (string value) {
			char[] chars = value.ToCharArray ();
			Array.Sort (chars);

			return new string (chars);
		}

		static string RemoveChars (string a, string b) {
			List<char> chars = a.ToCharArray ().ToList ();
			foreach (char c in b)
				chars.Remove (c);

			return new string (chars.ToArray ());
		}

		static char RemoveCharsAndReturnOne (string a, string b) {
			List<char> chars = a.ToCharArray ().ToList ();
			foreach (char c in b)
				chars.Remove (c);

			if (chars.Count == 0)
				return '\0';
			return chars[0];
		}
	}
}