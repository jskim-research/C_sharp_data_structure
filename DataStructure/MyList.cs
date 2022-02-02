using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    class MyList<T>
    {
        T[] _data;
        public int Size { get; private set; } // 실제 데이터 크기
        public int Capacity { get; private set; } // 배열 크기

        public MyList(int size = 1)
        {
            if (size <= 0)
            {
                Console.WriteLine("size is automatically set to 1");
                size = 1;
            }
            Size = size;
            Capacity = size;
            _data = new T[size];
        }

        public void Add(T data)
        {
            if (Size >= Capacity)
            {
                Capacity *= 2;
                T[] new_data = new T[Capacity];
                Array.Copy(_data, new_data, Size);
                _data = new_data;
                Console.WriteLine("Capacity increases to " + Capacity.ToString());
            }

            _data[Size - 1] = data;
            Size++;
        }

        public T this[int idx]
        {
            get { return _data[idx]; }
            set { _data[idx] = value; }
        }

    }
}
