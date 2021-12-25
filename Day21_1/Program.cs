using System;

namespace Day21_1 {
	class Program {

		static void Main (string[] args) {

			int p1 = 10;
			int p2 = 4;

		}

		static (long, long) Turn (int p1Pos, int p2Pos) {
			int roll = rollCounter++ + rollCounter++ + rollCounter++;
			rolls += 3;
			p1Pos += roll;
			p1Pos = (p1Pos - 1) % 10 + 1;
			p1Score += p1Pos;
			if (p1Score >= 21)
				return false;
			roll = rollCounter++ + rollCounter++ + rollCounter++;
			rolls += 3;
			p2Pos += roll;
			p2Pos = (p2Pos - 1) % 10 + 1;
			p2Score += p2Pos;
			if (p2Score >= 21)
				return false;
			return true;
		}
	}
}
