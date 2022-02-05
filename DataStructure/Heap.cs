using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DataStructure
{
    class HeapNode<T> : IComparable<HeapNode<T>>
    {
        public int Weight { get; set; } = 0;
        public T Data { get; set; }
        public int CompareTo(HeapNode<T> other)
        {
            if (Weight == other.Weight) return 0;
            return Weight > other.Weight ? 1 : -1;
        }
    }

    class Heap<T> where T: IComparable<T>
    {
        List<T> _heap = new List<T>();
        int last_idx = 0;
        public int Size { get { return last_idx; } }

        public void Push(T data)
        {
            if (last_idx >= Size)
                _heap.Add(data);
            else
                _heap[last_idx] = data;

            int idx = last_idx;

            while (idx != 0)
            {
                if (_heap[(idx - 1) / 2].CompareTo(_heap[idx]) <= 0) // 부모가 자식보다 값이 작은 경우 (부모가 가장 커야한다는 룰 위반)
                {
                    T temp = _heap[(idx - 1) / 2];
                    _heap[(idx - 1) / 2] = _heap[idx];
                    _heap[idx] = temp;
                    idx = (idx - 1) / 2;
                }
                else
                    break;
            }

            last_idx++;
        }

        public T Pop()
        {
            if (Size <= 0) return default(T);

            T result = _heap[0];
            int idx = 0, largest = 0, left = 0, right = 0;
            _heap[0] = _heap[last_idx-1];
            last_idx--;

            while (true)
            {
                largest = idx;
                left = idx * 2 + 1;
                right = idx * 2 + 2;

                if (left < last_idx && _heap[left].CompareTo(_heap[largest]) >= 0) // left가 부모보다 큰 경우
                    largest = left;
                if (right < last_idx && _heap[right].CompareTo(_heap[largest]) >= 0) // right가 부모보다 큰 경우
                    largest = right;

                if (largest == idx) break;

                T temp = _heap[idx];
                _heap[idx] = _heap[largest];
                _heap[largest] = temp;

                idx = largest;
            }
            

            return result;
        }
    }
}
