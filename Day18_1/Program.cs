using System;
using System.IO;

namespace Day18_1 {

	public class Program {

		public class Number {

			public int Value { get; set; }
			public Number X { get; set; }
			public Number Y { get; set; }

			public void Parse (string input) {
				int depth = 0;
				int commaPos = -1;
				for (int i = 0; i < input.Length; i++) {
					char c = input[i];
					if (c == '[') {
						depth++;
					} else if (c == ']') {
						depth--;
					} else if (c == ',' && depth == 1) {
						commaPos = i;
					}
				}
				if (depth != 0)
					throw new OperationCanceledException ("Depth did not work properly");

				if (commaPos == -1) {
					Value = int.Parse (input);
					return;
				}

				X = new Number ();
				Y = new Number ();
				X.Parse (input.Substring (1, commaPos - 1));
				Y.Parse (input.Substring (commaPos + 1, input.Length - commaPos - 2));
			}

			public override string ToString () {
				if (X is null && Y is null)
					return Value.ToString ();
				return $"[{X},{Y}]";
			}

		}

		static void Main (string[] args) {

			string[] data = File.ReadAllLines ("data.txt");

			Number[] numbers = new Number[data.Length];
			for (int i = 0; i < numbers.Length; i++) {
				numbers[i] = new Number ();
				numbers[i].Parse (data[i]);
			}

			Number total = numbers[0];
			for (int i = 1; i < numbers.Length; i++) {
				total = Add (total, numbers[i]);
			}


			Console.WriteLine (Magnitude (total));
		}

		static Number Add (Number a, Number b) {
			Number c = new Number ();
			c.X = a;
			c.Y = b;
			while (Explode (c, c, 1) || SplitAll (c)) {}

			return c;
		}

		static Number FindFirstLeft (Number total, Number findNeighbor) {
			Number target;
			Number newTarget = findNeighbor;
			do {
				target = newTarget;
				newTarget = GetParent (total, target);
				if (newTarget == null)
					return null;
			} while (newTarget.Y != target);

			target = newTarget.X;
			while (target.Y is not null) {
				target = target.Y;
			}
			return target;
		}

		static Number FindFirstRight (Number total, Number findNeighbor) {
			Number target;
			Number newTarget = findNeighbor;
			do {
				target = newTarget;
				newTarget = GetParent (total, target);
				if (newTarget == null)
					return null;
			} while (newTarget.X != target);

			target = newTarget.Y;
			while (target.X is not null) {
				target = target.X;
			}
			return target;
		}

		static Number GetParent (Number n, Number toFind) {
			if (n.X == toFind || n.Y == toFind)
				return n;

			if (n.X is not null) {
				Number left = GetParent (n.X, toFind);

				if (left is not null)
					return left;
			}
			if (n.Y is not null) {
				Number right = GetParent (n.Y, toFind);
				if (right is not null)
					return right;
			}
			return null;
		}

		static bool Explode (Number total, Number n, int depth) {
			if (n.X is not null)
				if (Explode (total, n.X, depth + 1))
					return true;
			if (n.Y is not null)
				if (Explode (total, n.Y, depth + 1))
					return true;
			if (depth == 5 && n.X is not null && n.Y is not null) {

				int leftValueAdd = n.X.Value;
				int rightValueAdd = n.Y.Value;



				Number left = FindFirstLeft (total, n);
				Number right = FindFirstRight (total, n);
				if (left is not null) {
					left.Value += leftValueAdd;
				}
				if (right is not null) {
					right.Value += rightValueAdd;
				}

				n.X = null;
				n.Y = null;

				return true;
			}
			
			return false;
		}

		static bool SplitAll (Number n) {
			if (n.X is not null)
				if (SplitAll (n.X))
					return true;
			if (n.Y is not null)
				if (SplitAll (n.Y))
					return true;
			if (n.X is null && n.Y is null) {
				if (n.Value >= 10) {
					Split (n);

					return true;
				}
			}
			return false;
		}

		static void Split (Number n) {
			Number left = new Number ();
			Number right = new Number ();
			left.Value = (int)Math.Floor (n.Value / 2.0);
			right.Value = (int)Math.Ceiling (n.Value / 2.0);
			n.Value = 0;
			n.X = left;
			n.Y = right;
		}

		static long Magnitude (Number n) {
			if (n.X is null && n.Y is null) {
				return n.Value;
			}

			return 3 * Magnitude (n.X) + 2 * Magnitude (n.Y);
		}
	}
}
