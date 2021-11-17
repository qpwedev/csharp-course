namespace Huffman
{
    public class Vertex
    {
        public Vertex Left { get; set; }
        public Vertex Right { get; set; }
        public int Weight { get; set; }
        public bool IsLeaf { get { return (this.Left == null && this.Right == null) ? true : false; } }
        public int Value { get; set; }
        public int BirthTime { get; set; }

        public Vertex(int weight, int value, int birthTime, Vertex left = null, Vertex right = null)
        {
            this.Value = value;
            this.BirthTime = birthTime;
            this.Weight = weight;
            this.Left = left;
            this.Right = right;
        }
    }
}
