using System;
using System.IO;

namespace Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Argument Error");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("File Error");
                return;
            }

            var fileName = args[0];

            var HuffmanTree = new HuffmanTree();
            HuffmanTree.CreateHuffmanTree(fileName);
            HuffmanTree.PreorderTraversal(HuffmanTree.Root);
        }
    }
}
