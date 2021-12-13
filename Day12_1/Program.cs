using System;
using System.Collections.Generic;
using System.IO;

namespace Day12_1 {
	class Program {

		private static int totalPaths = 0;

		static void Main (string[] args) {

			string[] data = File.ReadAllLines ("data.txt");

			List<(string p1, string p2)> paths = new ();

			for (int i = 0; i < data.Length; i++) {
				string[] split = data[i].Split ('-');
				paths.Add ((split[0], split[1]));
				paths.Add ((split[1], split[0]));
			}
			ExplorePath (paths, new List<(string, string)> { ("", "start") });
			Console.WriteLine (totalPaths);
		}

		static void ExplorePath (List<(string p1, string p2)> paths, List<(string p1, string p2)> path) {
			if (path.Count != 0 && path[^1].p2 == "end") {
				totalPaths++;
				PrintPath (path);
				return;
			}
			string nodeToSearch = path[^1].p2;
			List<(string p1, string p2)> newPaths = GetPathsFromNode (paths, nodeToSearch);
			for (int i = 0; i < newPaths.Count; i++) {
				if (WillIntersect (path, newPaths[i]))
					continue;

				path.Add (newPaths[i]);
				ExplorePath (paths, path);
				path.RemoveAt (path.Count - 1);
			}

		}

		static bool WillIntersect (List<(string p1, string p2)> path, (string p1, string p2) line) {
			if (line.p2.ToUpper () == line.p2)
				return false;
			for (int i = 0; i < path.Count; i++) {
				if (path[i].p1 == line.p2)
					return true;
			}
			return false;
		}

		static List<(string, string)> GetPathsFromNode (List<(string p1, string p2)> paths, string node) {

			List<(string, string)> toReturn = new List<(string, string)> ();

			for (int i = 0; i < paths.Count; i++) {
				if (paths[i].p1 == node)
					toReturn.Add (paths[i]);
			}

			return toReturn;
		}

		static void PrintPath (List<(string p1, string p2)> path) {
			foreach (var p in path)
				Console.Write (p.p2 + ",");
			Console.WriteLine ();
		}
	}
}
