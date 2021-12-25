using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day16_1 {
	class Program {

		class Packet {

			public int ID { get; set; }
			public int Version { get; set; }
			public long Value { get; set; }
			public List<Packet> SubPackets { get; } = new List<Packet> ();

			public int GetVersionSum () {
				return Version + SubPackets.Sum (t => t.GetVersionSum ());
			}

		}

		static void Main (string[] args) {

			string data = File.ReadAllText ("data.txt");

			BitArray bits = new BitArray (data.Length * 4);
			int arrayIndex = 0;
			for (int i = 0; i < data.Length; i++) {
				bool[] array = GetBits (data[i]);
				for (int j = 0; j < array.Length; j++)
					bits.Set (arrayIndex++, array[j]);
			}

			int index = 0;
			Packet packet = GetValueFromArray (bits, ref index);
			Console.WriteLine (packet.GetVersionSum ());
		}

		static Packet GetValueFromArray (BitArray array, ref int index) {

			bool versionBit1 = array[index++];
			bool versionBit2 = array[index++];
			bool versionBit3 = array[index++];

			int version = (versionBit1 ? 4 : 0) + (versionBit2 ? 2 : 0) + (versionBit3 ? 1 : 0);

			bool idBit1 = array[index++];
			bool idBit2 = array[index++];
			bool idBit3 = array[index++];

			int id = (idBit1 ? 4 : 0) + (idBit2 ? 2 : 0) + (idBit3 ? 1 : 0);

			switch (id) {
			case 4:
				List<bool> valueBitsList = new List<bool> ();

				while (array[index++]) {
					for (int i = 0; i < 4; i++)
						valueBitsList.Add (array[index++]);
				}
				for (int i = 0; i < 4; i++)
					valueBitsList.Add (array[index++]);

				long total = 0;

				for (int i = 0; i < valueBitsList.Count; i++) {
					total <<= 1;
					total += valueBitsList[i] ? 1 : 0;
				}

				return new Packet () {
					ID = id,
					Version = version,
					Value = total
				};
			default:
				Packet toReturn = new Packet () {
					ID = id,
					Version = version
				};
				if (!array[index++]) {
					// L0
					bool[] valueBits = new bool[15];
					for (int i = 0; i < 15; i++) {
						valueBits[i] = array[index++];
					}
					int length = 0;
					for (int i = 0; i < valueBits.Length; i++) {
						length <<= 1;
						length += valueBits[i] ? 1 : 0;
					}
					int startIndex = index;
					while (index - startIndex < length - 1) {
						toReturn.SubPackets.Add (GetValueFromArray (array, ref index));
					}
				} else {
					// L1
					bool[] valueBits = new bool[11];
					for (int i = 0; i < 11; i++) {
						valueBits[i] = array[index++];
					}
					int packetCount = 0;
					for (int i = 0; i < valueBits.Length; i++) {
						packetCount <<= 1;
						packetCount += valueBits[i] ? 1 : 0;
					}
					for (int i = 0; i < packetCount; i++) {
						toReturn.SubPackets.Add (GetValueFromArray (array, ref index));
					}
				}

				return toReturn;
			}

		}

		static bool[] GetBits (char hex) {
			switch (hex) {
			case '0':
				return new bool[] { false, false, false, false };
			case '1':
				return new bool[] { false, false, false, true };
			case '2':
				return new bool[] { false, false, true, false };
			case '3':
				return new bool[] { false, false, true, true };
			case '4':
				return new bool[] { false, true, false, false };
			case '5':
				return new bool[] { false, true, false, true };
			case '6':
				return new bool[] { false, true, true, false };
			case '7':
				return new bool[] { false, true, true, true };
			case '8':
				return new bool[] { true, false, false, false };
			case '9':
				return new bool[] { true, false, false, true };
			case 'A':
				return new bool[] { true, false, true, false };
			case 'B':
				return new bool[] { true, false, true, true };
			case 'C':
				return new bool[] { true, true, false, false };
			case 'D':
				return new bool[] { true, true, false, true };
			case 'E':
				return new bool[] { true, true, true, false };
			case 'F':
				return new bool[] { true, true, true, true };
			}

			throw new ArgumentException ($"{hex} is not a hex character.");
		}
	}
}
