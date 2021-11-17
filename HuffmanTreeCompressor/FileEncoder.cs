using System;
using System.IO;

namespace Huffman
{
    public static class FileEncoder
    {
        public static void EncodeFile(string fileName, string outputFileName)
        {
            try
            {
                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Open(outputFileName, FileMode.Create)))
                    {
                        var HuffmanTree = new HuffmanTree();

                        HuffmanTree.CreateHuffmanTree(fileName);
                        HuffmanTree.CreateEncodingAndPreorderList();

                        var ByteConstuctor = new ByteConstuctor();

                        writer.Write(ByteConstuctor.Header);

                        // Write binary stucture of HuffmanTree
                        foreach (var item in HuffmanTree.PreorderVerteces)
                        {
                            Int64 encodedVertex = ByteConstuctor.EncodeVertex(item);
                            for (int i = 0; i < 8; ++i)
                            {
                                writer.Write((byte)(0xFF & (encodedVertex >> (i * 8))));
                            }
                        }

                        writer.Write(ByteConstuctor.HeaderEnding);

                        // Write encoded file bytes
                        int bytee;
                        while ((bytee = stream.ReadByte()) != -1)
                        {
                            Int64 code = HuffmanTree.EncodeValue((byte)bytee);

                            while (code > 1)
                            {
                                if (ByteConstuctor.AddBit((byte)(code & 0x01)) == 8)
                                {
                                    writer.Write(ByteConstuctor.ClearBuffer());
                                }
                                code >>= 1;
                            }
                        }

                        if (ByteConstuctor.Size > 0)
                        {
                            writer.Write(ByteConstuctor.ClearBuffer());
                        }
                    }
                }
            }
            catch(IOException){
                Console.WriteLine("File Error");
            }
        }
    }
}