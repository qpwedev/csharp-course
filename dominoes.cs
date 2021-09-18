// Write a program that finds a longest row that can be built from a given domino-stones and prints its length. Dominoes contain always two numbers. Mind the fact that we do not prescribe which number is the left one and which the right one.

// Dominoes are labeled by (pair of) numbers 1..38, maximum number of dominoes is 16.

// On the input, there are several numbers of this form: First number k tells us number of dominoes. It is followed by 2k where each consecutive pair describes numbers on particular domino-stone.

using System;
using System.Collections.Generic;
using System.Linq;

namespace mySolution {
    class MainClass {
        public static int biggest = 0;

        public static void Main(string[] args) {
            var dominoes = new List<(int, int)>();
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            while (input.Count < int.Parse(input[0]) * 2 + 1)
                input.AddRange(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList());

            for (int i = 1; i < int.Parse(input[0]) * 2; i += 2) dominoes.Add((int.Parse(input[i]), int.Parse(input[i + 1])));
            
            SearchTheBestWay(new List<(int, int)>(), dominoes);
            Console.WriteLine(biggest);
        }

        public static void SearchTheBestWay(List<(int, int)> current, List<(int, int)> unused) {
            if (current.Count > biggest) biggest = current.Count;
            if (unused.Count == 0) return;

            foreach (var domino in unused) {
                var new_unused = new List<(int, int)>(unused);
                new_unused.Remove(domino);

                var new_current1 = new List<(int,int)>(current);
                new_current1.Add(domino);
                if (new_current1.Count <= 1 || new_current1[new_current1.Count - 2].Item2 == domino.Item1) SearchTheBestWay(new_current1, new_unused);

                var new_current2 = new List<(int, int)>(current);
                new_current2.Add((domino.Item2, domino.Item1));
                if (new_current2.Count <= 1 || new_current2[new_current2.Count - 2].Item2 == domino.Item2) SearchTheBestWay(new_current2, new_unused);
            }
        }
    }
}