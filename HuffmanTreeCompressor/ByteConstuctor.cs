using System.Linq;
using System;
using System.Collections.Generic;

namespace Huffman
{
    public class ByteConstuctor
    {
        public byte[] Header = { 0x7B, 0x68, 0x75, 0x7C, 0x6D, 0x7D, 0x66, 0x66 };
        public Int64 HeaderEnding = 0;
        public int Size { get; set; }
        private byte ActualByte { get; set; }
        public int AddBit(byte bit)
        {
            ActualByte |= (byte)(bit << Size++);
            return Size;
        }
        public byte ClearBuffer()
        {
            byte returnByte = ActualByte;
            ActualByte = 0;
            Size = 0;
            return returnByte;
        }

        public Int64 EncodeVertex(Vertex vertex)
        {
            return (vertex.IsLeaf ? 1 : 0) + ((vertex.Weight & 0x7FFFFFFFFFFFFF) << 1) + ((vertex.IsLeaf ? (Int64)vertex.Value : 0) << 56);
        }
    }
}