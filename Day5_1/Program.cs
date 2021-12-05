using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace Day5_1 {
	class Program {
		static void Main (string[] args) {

			string[] strings = File.ReadAllLines ("data.txt");

			List<((int x, int y) p1, (int x, int y) p2)> lines = new List<((int x, int y) p1, (int x, int y) p2)> ();

			for (int i = 0; i < strings.Length; i++) {
				string[] leftRight = strings[i].Split (" -> ");
				string[] p1 = leftRight[0].Split (",");
				string[] p2 = leftRight[1].Split (",");
				int x1 = int.Parse (p1[0]);
				int y1 = int.Parse (p1[1]);
				int x2 = int.Parse (p2[0]);
				int y2 = int.Parse (p2[1]);
				lines.Add (((x1, y1), (x2, y2)));
			}

			int[][] map = new int[1000][];
			for (int i = 0; i < map.Length; i++) {
				map[i] = new int[1000];
			}
			foreach (var line in lines) {
				if (line.p1.x == line.p2.x) {
					int yMin = Math.Min (line.p1.y, line.p2.y);
					int yMax = Math.Max (line.p1.y, line.p2.y);
					int x = line.p1.x;
					for (int y = yMin; y <= yMax; y++) {
						map[y][x]++;
					}
				}
				if (line.p1.y == line.p2.y) {
					int xMin = Math.Min (line.p1.x, line.p2.x);
					int xMax = Math.Max (line.p1.x, line.p2.x);
					int y = line.p1.y;
					for (int x = xMin; x <= xMax; x++) {
						map[y][x]++;
					}
				}
			}
			int count = 0;
			for (int i = 0; i < map.Length; i++) {
				for (int j = 0; j < map[i].Length; j++) {
					if (map[i][j] >= 2)
						count++;
				}
			}
			Console.WriteLine (count);
		}
	}
}
