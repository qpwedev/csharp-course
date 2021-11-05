using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace csharp{
    class Program{
        static void Main(string[] args){
            if (args.Length != 1){
                Console.WriteLine("Argument Error");
                return;
            }

            StreamReader inputFile;
            try {
                inputFile = new StreamReader(args[0]);
            } 
            catch {
                Console.WriteLine("File Error");
                return;
            }
            
            processWords(inputFile);
        }

        static void processWords(StreamReader inputFile){
            var wordCounter = new SortedDictionary<string, int>();
            var separators = new char[] { ' ', '\t', '\n' };
            string line;

            while ((line = inputFile.ReadLine()) != null) {
                foreach (string word in line.Split(separators, StringSplitOptions.RemoveEmptyEntries)){
                    if (wordCounter.ContainsKey(word)){
                        ++wordCounter[word];
                    } 
                    else {
                        wordCounter.Add(word, 1);
                    }
                }
            }

            foreach (var pair in wordCounter){
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }
        }
    }
}