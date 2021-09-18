// The program's input will contain a single integer greater than 1 and less than 2^31 (i.e. within the range of a value of type longint). Decompose this number into its prime factors and write the result to a single line of standard output. Separate the prime factors by spaces. If the input number is itself prime, simply copy it to the output. Write out the individual prime factors in order from smallest to largest.

using System;
using System.Collections.Generic;

namespace Sample{
    class MainClass{
        public static void Main(string[] args){
            //Console.ForegroundColor = ConsoleColor.Green;
            primeFactorization(long.Parse(Console.ReadLine()));
        }

        public static void primeFactorization(long number) {
            List<long> factors = new List<long>();
            long primeFactor = 2;

            while (number > 1) {
                if (number % primeFactor == 0) {
                    number /= primeFactor;
                    factors.Add(primeFactor);
                }
                else {
                    primeFactor += 1;
                }
            }
            Console.WriteLine(string.Join(" ", factors.ToArray()));
        }
    }
}
