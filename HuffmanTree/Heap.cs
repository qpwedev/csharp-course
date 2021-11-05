using System;

namespace Huffman
{
    public class BinaryHeap
    {
        public int Count { get { return count; } }

        Vertex[] vertices;
        int count;

        bool Compare((int, int, int, int) a, (int, int, int, int) b){
            if (a.Item1 < b.Item1) return true;
            else if (a.Item1 > b.Item1) return false;
            else{
                if (a.Item2 < b.Item2) return true;
                else if (a.Item2 > b.Item2) return false;
                else if (a.Item2 == 0){
                    if (a.Item3 < b.Item3) return true;
                    else if (a.Item3 > b.Item3) return false;
                }
                else if (a.Item2 == 1){
                    if (a.Item4 < b.Item4) return true;
                    else if (a.Item4 > b.Item4) return false;
                }
            }

            return true;
        }

        public BinaryHeap(int capacity) {
            vertices = new Vertex[capacity];
            count = 0;
        }

        public void Add(Vertex item) {
            int position = count++;
            vertices[position] = item;
            BubbleUp(position);
        }

        public Vertex ExtractMin(){
            var minVertex = vertices[0];
            Swap(0, count - 1);
            --count;
            BubbleDown(0);
            return minVertex;
        }

        void BubbleUp(int position){
            while ((position > 0) && !Compare(vertices[Parent(position)].GetPriority, vertices[position].GetPriority)){
                int original_parent_pos = Parent(position);
                Swap(position, original_parent_pos);
                position = original_parent_pos;
            }
        }

        void BubbleDown(int position){
            int lchild = LeftChild(position);
            int rchild = RightChild(position);
            int largest = 0;
            if ((lchild < count) && Compare(vertices[lchild].GetPriority, vertices[position].GetPriority)){
                largest = lchild;
            }
            else{
                largest = position;
            }
            if ((rchild < count) && Compare(vertices[rchild].GetPriority, vertices[largest].GetPriority)){
                largest = rchild;
            }
            if (largest != position){
                Swap(position,largest);
                BubbleDown(largest);
            }
        }

        void Swap(int position1, int position2){
            Vertex temp = vertices[position1];
            vertices[position1] = vertices[position2];
            vertices[position2] = temp;
        }

        static int Parent(int position) => (position - 1) / 2;
        static int LeftChild(int position) => 2 * position + 1;
        static int RightChild(int position) => 2 * position + 2;
    }
}