using System;
using System.IO;

namespace Day17_2 {
	class Program {

		static int xMin = 281;
		static int xMax = 311;

		static int yMin = -74;
		static int yMax = -54;

		static void Main (string[] args) {

			// target area: x=281..311, y=-74..-54

			int count = 0;

			for (int i = 0; i < 500; i++) {
				for (int j = -100; j < 1000; j++) {
					int xVel = i;
					int yVel = j;
					if (IsValid (xVel, yVel)) {
						count++;
					}
				}
				Console.WriteLine (i);
			}
			Console.WriteLine (count);
		}

		static bool IsValid (int xVel, int yVel) {

			int xPos = 0;
			int yPos = 0;

			while (yPos >= yMin) {

				xPos += xVel;
				yPos += yVel;

				switch (xVel) {
					case > 0:
						xVel--;
						break;
					case < 0:
						xVel++;
						break;
				}

				yVel--;

				if (xMin <= xPos && xPos <= xMax && yMin <= yPos && yPos <= yMax) {
					return true;
				}


			}

			return false;
		}
	}
}