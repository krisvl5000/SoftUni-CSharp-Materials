using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ObjectList<T>
    {
        private int currentIndex;
        private T[] data;

        public ObjectList(int capacity)
        {
            this.data = new T[capacity];
        }

        public void Add(T value)
        {
            this.data[this.currentIndex] = value;
            this.currentIndex++;
        }

        public T Get(int index)
        {
            return this.data[index];
        }
    }
}
