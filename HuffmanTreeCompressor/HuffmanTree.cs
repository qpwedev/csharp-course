using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Huffman
{
    public class HuffmanTree
    {
        private Vertex Root { get; set; }
        private Int64[] VertecesEncoding = new Int64[256];
        public List<Vertex> PreorderVerteces = new List<Vertex>();

        public void CreateEncodingAndPreorderList() => PreorderTraversal(Root, 1);

        public Int64 EncodeValue(int value) => VertecesEncoding[value];

        private void PreorderTraversal(Vertex vertex, Int64 code)
        {
            PreorderVerteces.Add(vertex);

            if (vertex.Left != null)
            {
                PreorderTraversal(vertex.Left, (code << 1));
            }

            if (vertex.Right != null)
            {
                PreorderTraversal(vertex.Right, (code << 1) + 1);
            }

            if (vertex.Left == null && vertex.Right == null)
            {
                Int64 reversedCode = 1;
                while (code > 1)
                {
                    reversedCode = (reversedCode << 1) + (code & 0x1);
                    code >>= 1;
                }
                VertecesEncoding[vertex.Value] = reversedCode;
            }
        }

        public void CreateHuffmanTree(string fileName)
        {
            try
            {

                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    int[] byteCounter = new int[256];

                    int bytee;
                    int uniqueCounter = 0;
                    while ((bytee = stream.ReadByte()) != -1)
                    {
                        if (byteCounter[bytee] == 0)
                        {
                            ++uniqueCounter;
                        }

                        ++byteCounter[bytee];
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
            catch
            {
                Console.WriteLine("File Error");
            }
        }
    }
}