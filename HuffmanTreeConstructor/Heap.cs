namespace Huffman
{
    public class BinaryHeap
    {
        public int Count { get { return count; } }

        private Vertex[] vertices;
        private int count;

        private bool Compare(Vertex v1, Vertex v2)
        {
            if (v1.Weight < v2.Weight) return true;
            else if (v1.Weight > v2.Weight) return false;
            else
            {
                if (v1.IsLeaf && !v2.IsLeaf) return true;
                else if (!v1.IsLeaf && v2.IsLeaf) return false;
                else if (v1.IsLeaf)
                {
                    if (v1.Value < v2.Value) return true;
                    else if (v1.Value > v2.Value) return false;
                }
                else if (!v1.IsLeaf)
                {
                    if (v1.BirthTime < v2.BirthTime) return true;
                    else if (v1.BirthTime > v2.BirthTime) return false;
                }
            }

            return true;
        }

        public BinaryHeap(int capacity)
        {
            vertices = new Vertex[capacity];
            count = 0;
        }

        public void Add(Vertex item)
        {
            int position = count++;
            vertices[position] = item;
            BubbleUp(position);
        }

        public Vertex ExtractMin()
        {
            var minVertex = vertices[0];
            Swap(0, count - 1);
            --count;
            BubbleDown(0);
            return minVertex;
        }

        private void BubbleUp(int position)
        {
            while ((position > 0) && !Compare(vertices[Parent(position)], vertices[position]))
            {
                int original_parent_pos = Parent(position);
                Swap(position, original_parent_pos);
                position = original_parent_pos;
            }
        }

        private void BubbleDown(int position)
        {
            int lchild = LeftChild(position);
            int rchild = RightChild(position);
            int largest = 0;
            if ((lchild < count) && Compare(vertices[lchild], vertices[position]))
            {
                largest = lchild;
            }
            else
            {
                largest = position;
            }
            if ((rchild < count) && Compare(vertices[rchild], vertices[largest]))
            {
                largest = rchild;
            }
            if (largest != position)
            {
                Swap(position, largest);
                BubbleDown(largest);
            }
        }

        private void Swap(int position1, int position2)
        {
            Vertex temp = vertices[position1];
            vertices[position1] = vertices[position2];
            vertices[position2] = temp;
        }

        private static int Parent(int position) => (position - 1) / 2;
        private static int LeftChild(int position) => 2 * position + 1;
        private static int RightChild(int position) => 2 * position + 2;
    }
}