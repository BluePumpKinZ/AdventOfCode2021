using System;

namespace Day17_1 {
	class Program {

		static int xMin = 281;
		static int xMax = 311;

		static int yMin = -74;
		static int yMax = -54;

		static void Main (string[] args) {

			// target area: x=281..311, y=-74..-54

			int maxY = 0;

			for (int i = 0; i < 100; i++) {
				for (int j = 0; j < i; j++) {
					int xVel = i - j;
					int yVel = j;
					if (IsValid (xVel, yVel, out int highestY)) {
						maxY = Math.Max (highestY, maxY);
					}
				}
				Console.WriteLine (i);
			}
			Console.WriteLine (maxY);
		}

		static bool IsValid (int xVel, int yVel, out int maxY) {

			int xPos = 0;
			int yPos = 0;

			maxY = 0;

			while (yPos >= yMin) {

				xPos += xVel;
				yPos += yVel;

				maxY = Math.Max (maxY, yPos);

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
