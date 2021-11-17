using System.IO;
using System;

namespace Huffman
{
    public class HuffmanTree
    {
        public Vertex Root { get; set; }

        public void PreorderTraversal(Vertex vertex)
        {
            if (vertex.IsLeaf) Console.Write($"*{vertex.Value}:{vertex.Weight} ");
            else Console.Write($"{vertex.Weight} ");

            if (vertex.Left != null)
            {
                PreorderTraversal(vertex.Left);
            }

            if (vertex.Right != null)
            {
                PreorderTraversal(vertex.Right);
            }
        }

        public void CreateHuffmanTree(string fileName)
        {
            int[] byteCounter = new int[256];
            int bytee;
            int uniqueCounter = 0;
            try
            {
                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    while ((bytee = stream.ReadByte()) != -1)
                    {
                        if (byteCounter[bytee] == 0)
                        {
                            ++uniqueCounter;
                        }

                        ++byteCounter[bytee];
                    }
                }

            }
            catch (IOException)
            {
                Console.WriteLine("File Error");
            }

            var forest = new BinaryHeap(uniqueCounter);
            int birthTime = 0;

            for (int i = 0; i < 256; ++i)
            {
                if (byteCounter[i] != 0)
                {
                    forest.Add(new Vertex(byteCounter[i], i, birthTime));
                    ++birthTime;
                }
            }

            while (forest.Count > 1)
            {
                var left = forest.ExtractMin();
                var right = forest.ExtractMin();
                var center = new Vertex(left.Weight + right.Weight, 0, birthTime, left, right);
                forest.Add(center);
                ++birthTime;
            }

            Root = forest.ExtractMin();
        }
    }
}