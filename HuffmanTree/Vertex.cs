using System;

namespace Huffman
{
    public class Vertex
    {
        public Vertex Left { get; set; }
        public Vertex Right { get; set; }
        public int Weight { get; set; }
        public int IsLeaf { get{ return (this.Left == null && this.Right == null) ? 0 : 1; } }
        public int Value { get; set; }
        public int BirthTime { get; set; }
        public (int, int, int, int) GetPriority { get { return (Weight, IsLeaf, Value, BirthTime); }}
        public Vertex(int weight, int value, int birthTime, Vertex left=null, Vertex right=null){
            this.Value = value;
            this.BirthTime = birthTime;
            this.Weight = weight;
            this.Left = left;
            this.Right = right;
        }

        public void inorderTraversal(){
            if (this.IsLeaf == 0) Console.Write($"*{this.Value}:{this.Weight} ");
            else Console.Write($"{this.Weight} ");

            if (this.Left != null) this.Left.inorderTraversal();
            if (this.Right != null) this.Right.inorderTraversal();
        }
    }
}
