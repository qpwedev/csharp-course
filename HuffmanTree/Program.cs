using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1){
                Console.WriteLine("Argument Error");
                return;
            }
            if (!File.Exists(args[0])){
                Console.WriteLine("File Error");
                return;
            }

            var stream = new FileStream(args[0], FileMode.Open);
            var dict = new Dictionary<int,int>();

            int bytee;
            while ((bytee = stream.ReadByte()) != -1){
                if (dict.ContainsKey(bytee)) ++dict[bytee];
                else dict.Add(bytee, 1);
            }

            var keys = dict.Keys;
            var forest = new BinaryHeap(keys.Count());

            int birthTime = 0;
            foreach (var key in dict.Keys){
                forest.Add(new Vertex(dict[key], key, birthTime));
                ++birthTime;
            }
            
            while(forest.Count > 1){
                var left = forest.ExtractMin();
                var right = forest.ExtractMin();
                var center = new Vertex(left.Weight+right.Weight, 0, birthTime, left, right);
                forest.Add(center);
                ++birthTime;
            }

            forest.ExtractMin().inorderTraversal();
        }
    }
}
