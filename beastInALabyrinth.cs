// A beast is in a labyrinth. The labyrinth is represented as a matrix of individual positions. At any moment, the beast is at one particular position and is turned in one of four possible directions (up, down, left and right).

// In each round the beast makes one move. The possible moves are: TurnLeft, TurnRight, MakeStep (one step forward). At the beginning, the beast has a wall to its right. As the beast moves it tries to follow this wall (see the example below).

// The input of the program contains a width and height followed by a map of the labyrinth. Individual characters depict individual positions in the labyrinth: 'X' is a wall and '.' is an empty spot. The characters '^', '>', 'v' and '<' depict the beast turned upward, to the right, downward and to the left, respectively.

// Your program should read the input and then move the beast 20 times. After each move it should print a map of the labyrinth in the same form in which it read it. Write an empty line after each map.

// Beware: The first output is performed after the first move of the beast.


using System;
using System.Collections.Generic;

namespace Program {
    class Beast {

        static char direction = '>';
        static (int, int) currentPos = (0, 0);
        static List<List<char>> field = new List<List<char>>();
        static int prints = 0;

        public static void Main(String[] args) {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            for (int i = 0; i < lenght; i++) { field.Add(new List<char>(Console.ReadLine())); }
            for (int i = 0; i < lenght; i++) {
                for (int j = 0; j < width; j++) {
                    if (field[i][j] == '<') { direction = '<'; currentPos = (i, j); }
                    else if (field[i][j] == '^') { direction = '^'; currentPos = (i, j); }
                    else if (field[i][j] == '>') { direction = '>'; currentPos = (i, j); }
                    else if (field[i][j] == 'v') { direction = 'v'; currentPos = (i, j); }
                }
            }
            while (true) { walkMan(); }
        }

        public static void printField() {
            if (++prints > 20) { Environment.Exit(0); }
            foreach (var item in field) { Console.WriteLine(new string(item.ToArray())); }
            Console.WriteLine();
        }

        public static void walkMan() {
            if (direction == '<') {
                if (field[currentPos.Item1][currentPos.Item2 - 1] == '.' &&
                    field[currentPos.Item1 - 1][currentPos.Item2 - 1] == 'X') {
                    field[currentPos.Item1][currentPos.Item2] = '.';
                    field[currentPos.Item1][currentPos.Item2 - 1] = direction;
                    currentPos = (currentPos.Item1, currentPos.Item2 - 1);
                    printField();
                }
                else if (field[currentPos.Item1][currentPos.Item2 - 1] == 'X') {
                    direction = 'v';
                    field[currentPos.Item1][currentPos.Item2] = direction;
                    printField();

                }
                else if (field[currentPos.Item1][currentPos.Item2 - 1] == '.' &&
                    field[currentPos.Item1 - 1][currentPos.Item2 - 1] == '.') {
                    turnRight();
                }

            }
            else if (direction == '^') {
                if (field[currentPos.Item1 - 1][currentPos.Item2] == '.' &&
                    field[currentPos.Item1 - 1][currentPos.Item2 + 1] == 'X') {
                    field[currentPos.Item1][currentPos.Item2] = '.';
                    field[currentPos.Item1 - 1][currentPos.Item2] = direction;
                    currentPos = (currentPos.Item1 - 1, currentPos.Item2);
                    printField();
                }
                else if (field[currentPos.Item1 - 1][currentPos.Item2] == 'X') {
                    direction = '<';
                    field[currentPos.Item1][currentPos.Item2] = direction;
                    printField();

                }
                else if (field[currentPos.Item1 - 1][currentPos.Item2] == '.' &&
                    field[currentPos.Item1 - 1][currentPos.Item2 + 1] == '.') {
                    turnRight();
                }

            }
            else if (direction == '>') {
                if (field[currentPos.Item1][currentPos.Item2+1] == '.' &&
                    field[currentPos.Item1+1][currentPos.Item2+1] == 'X') {
                    field[currentPos.Item1][currentPos.Item2] = '.';
                    field[currentPos.Item1][currentPos.Item2 + 1] = direction;
                    currentPos = (currentPos.Item1, currentPos.Item2 + 1);
                    printField();
                }
                else if (field[currentPos.Item1][currentPos.Item2 + 1] == 'X') {
                    direction = '^';
                    field[currentPos.Item1][currentPos.Item2] = direction;
                    printField();

                }
                else if (field[currentPos.Item1][currentPos.Item2 + 1] == '.' &&
                    field[currentPos.Item1 + 1][currentPos.Item2 + 1] == '.') {
                    turnRight();
                }
            }
            else if (direction == 'v') {
                if (field[currentPos.Item1 + 1][currentPos.Item2] == '.' &&
                    field[currentPos.Item1 + 1][currentPos.Item2 - 1] == 'X') {
                    field[currentPos.Item1][currentPos.Item2] = '.';
                    field[currentPos.Item1 + 1][currentPos.Item2] = direction;
                    currentPos = (currentPos.Item1 + 1, currentPos.Item2);
                    printField();
                }
                else if (field[currentPos.Item1 + 1][currentPos.Item2] == 'X') {
                    direction = '>';
                    field[currentPos.Item1][currentPos.Item2] = direction;
                    printField();

                }
                else if (field[currentPos.Item1 + 1][currentPos.Item2] == '.' &&
                    field[currentPos.Item1 + 1][currentPos.Item2 - 1] == '.') {
                    turnRight();
                }

            }

        }

        public static void turnRight() {
            if (direction == '<') {
                field[currentPos.Item1][currentPos.Item2] = '.';
                field[currentPos.Item1][currentPos.Item2-1] = '<';
                printField();
                field[currentPos.Item1][currentPos.Item2-1] = '^';
                printField();
                field[currentPos.Item1][currentPos.Item2-1] = '.';
                field[currentPos.Item1-1][currentPos.Item2-1] = '^';
                printField();
                currentPos = (currentPos.Item1 - 1, currentPos.Item2 - 1);
                direction = '^';
            }
            else if (direction == '^') {
                field[currentPos.Item1][currentPos.Item2] = '.';
                field[currentPos.Item1-1][currentPos.Item2] = '^';
                printField();
                field[currentPos.Item1-1][currentPos.Item2] = '>';
                printField();
                field[currentPos.Item1-1][currentPos.Item2] = '.';
                field[currentPos.Item1-1][currentPos.Item2+1] = '>';
                printField();
                currentPos = (currentPos.Item1 - 1, currentPos.Item2 + 1);
                direction = '>';
            }
            else if (direction == '>') {
                field[currentPos.Item1][currentPos.Item2] = '.';
                field[currentPos.Item1][currentPos.Item2+1] = '>';
                printField();
                field[currentPos.Item1][currentPos.Item2+1] = 'v';
                printField();
                field[currentPos.Item1][currentPos.Item2+1] = '.';
                field[currentPos.Item1+1][currentPos.Item2+1] = 'v';
                printField();
                currentPos = (currentPos.Item1 + 1, currentPos.Item2 + 1);
                direction = 'v';

            }
            else if (direction == 'v') {
                field[currentPos.Item1][currentPos.Item2] = '.';
                field[currentPos.Item1+1][currentPos.Item2] = 'v';
                printField();
                field[currentPos.Item1+1][currentPos.Item2] = '<';
                printField();
                field[currentPos.Item1+1][currentPos.Item2] = '.';
                field[currentPos.Item1+1][currentPos.Item2-1] = '<';
                printField();
                currentPos = (currentPos.Item1 + 1, currentPos.Item2 - 1);
                direction = '<';
            }
        }   
    }
}