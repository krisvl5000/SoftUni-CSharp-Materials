using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> elements = new Stack<T>();

        public int Count => elements.Count;

        public void Add(T element)
        {
            elements.Push(element);
        }

        public T Remove()
        {
            return elements.Pop();
        }
    }
}
