// On a chessboard of 8 x 8 squares, a rook is positioned on a certain square and needs to move to a certain position without crossing any occupied square. Determine the minimum number of moves necessary for the rook to reach its destination position.

// Standard input will contain a description of the chessboard in the form of 8 lines, each containing 8 symbols. Each symbol represents one chessboard square:

// '.' - a free square

// 'x' - an occupied square

// 'v' - the starting position of the rook

// 'c' - the ending position of the rook

// The program should write a single integer to standard output - the minimum number of moves the rook must make to reach the destination square. If the rook cannot reach its desti! nation, w rite the number -1.

using System;
using System.Collections.Generic;
using System.Linq;

namespace mySolution {
    class MainClass {
        public static void Main(string[] args) {
            var gameBoard = new List<List<int>>();
            (int, int) startCoord = (-1,-1);
            for (int i = 0; i < 8; i++) {
                string input = Console.ReadLine();
                var gameRow = new List<int>();
                for (int j = 0; j < 8; j++) {

                    if (input[j] == '.') gameRow.Add(0);
                    else if (input[j] == 'v') {
                        gameRow.Add(-1);
                        startCoord = (i, j);
                    }
                    else if (input[j] == 'x') gameRow.Add(-1);
                    else if (input[j] == 'c') gameRow.Add(-2);
                }
                gameBoard.Add(gameRow);
            }
            int answer = BFS(startCoord, gameBoard);
            if (answer == -1) Console.WriteLine(-1);
            else Console.WriteLine(answer-1);
            }

        public static int BFS((int, int) startCoord, List<List<int>> gameDesk) {
            var queue = new List<(int, int)>() { startCoord };
            var newQueue = new List<(int, int)>();
            int distance = 1;
            gameDesk[startCoord.Item1][startCoord.Item2] = distance;

            while (queue.Any()) {

                foreach (var coordinate in queue) {
                    if (gameDesk[coordinate.Item1][coordinate.Item2] == -2) {
                        return distance;
                    }
                    gameDesk[coordinate.Item1][coordinate.Item2] = distance;
                    foreach (var item in SearchPositions(coordinate, gameDesk)) {
                        newQueue.Add(item);
                    }
                }
                queue = newQueue;
                newQueue = new List<(int, int)>();
                distance = ++distance;
            }


            return -1;
        }

        //........

        public static List<(int, int)> SearchPositions((int, int) position, List<List<int>> gameDesk) {
            var listWithPositions = new List<(int, int)> {};
            for (int i = position.Item1 + 1; i < 8; i++) {
                if (gameDesk[i][position.Item2] != -1 & gameDesk[i][position.Item2] <= 0) listWithPositions.Add((i, position.Item2));
                else break;
            }
            for (int j = position.Item1 - 1; j >= 0; j--) {
                if (gameDesk[j][position.Item2] != -1 & gameDesk[j][position.Item2] <= 0) listWithPositions.Add((j, position.Item2));
                else break;
            }
            for (int k = position.Item2 + 1; k < 8; k++) {
                if (gameDesk[position.Item1][k] != -1 & gameDesk[position.Item1][k] <= 0) listWithPositions.Add((position.Item1, k));
                else break;
            }
            for (int l = position.Item2 - 1; l >= 0; l--) {
                if (gameDesk[position.Item1][l] != -1 & gameDesk[position.Item1][l] <= 0) listWithPositions.Add((position.Item1, l));
                else break;
            }

            return listWithPositions;
        }
    }
}