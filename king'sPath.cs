// Write a program finding a shortest path with a chess king on a chessboard 8x8 where several squares cannot be accessed (by the king).

// Input is given in this ordering:

// Number of obstacles
// Coordinates of the obstacles (pairs of numbers 1.. 8)
// Coordinates of the starting square
// Coordinates of the end square.
// Number of the obstacles is on a separate line, obstacles are described each on a separate line (i.e., one pair of numbers on a line). On a line the numbers are separated by the space-character.

// Output is either -1 (if the king cannot reach the end-square) or number of steps that the king has to perform.

using System;
using System.Collections.Generic;
using System.Linq;

namespace mySolution {
    class MainClass {
        public static void Main(string[] args) {
            int[,] gameDesk = new int[8, 8];
            int num = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < num; i++) {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                gameDesk[int.Parse(input[0]) - 1, int.Parse(input[1]) - 1] = -1;

                
            }

            string[] start = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] finish = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            (int, int) startCoord = (int.Parse(start[0]) - 1, int.Parse(start[1]) - 1);

            if (startCoord.Item1 < 0 | startCoord.Item1 > 7 | startCoord.Item2 < 0 | startCoord.Item2 > 7 |
                int.Parse(finish[0]) < 0 | int.Parse(finish[0]) > 8 | int.Parse(finish[1]) < 0 | int.Parse(finish[1]) > 7) {
                Console.WriteLine(-1);

            }
            else {
                gameDesk[int.Parse(finish[0]) - 1, int.Parse(finish[1]) - 1] = -2;
                Console.WriteLine(BFS(startCoord, gameDesk));
            }


        }

        public static int BFS((int, int) startCoord, int[,] gameDesk) {
            var queue = new List<(int, int)>() { startCoord };
            var newQueue = new List<(int, int)>();
            int distance = -1;

            while (queue.Any()) {

                foreach (var coordinate in queue) {
                    if (gameDesk[coordinate.Item1, coordinate.Item2] == -2) {
                        return distance;
                    }
                    newQueue = newQueue.Concat(SearchPositions(coordinate, gameDesk)).ToList();
                    gameDesk[coordinate.Item1, coordinate.Item2] = distance;
                }
                queue = newQueue;
                newQueue = new List<(int, int)>();
                distance = distance == -1 ? 1 : ++distance;
            }


            return -1;
        }

        public static List<(int, int)> SearchPositions((int, int) position, int[,] gameDesk) {
            var listWithPositions = new List<(int, int)> {
                (position.Item1 - 1, position.Item2 - 1),
                (position.Item1 - 1, position.Item2),
                (position.Item1 - 1, position.Item2 + 1),
                (position.Item1, position.Item2 + 1),
                (position.Item1, position.Item2 - 1),
                (position.Item1 + 1, position.Item2 - 1),
                (position.Item1 + 1, position.Item2),
                (position.Item1 + 1, position.Item2 + 1),
                };

            var listWithValidPositions = new List<(int, int)>();

            foreach (var pos in listWithPositions) {
                if (8 > pos.Item1 & pos.Item1 >= 0 & 8 > pos.Item2 & pos.Item2 >= 0) {
                    if (gameDesk[pos.Item1, pos.Item2] == -2 | gameDesk[pos.Item1, pos.Item2] == 0) {
                        listWithValidPositions.Add(pos);
                    }
                }
            }

            return listWithValidPositions;
        }
    }
}
