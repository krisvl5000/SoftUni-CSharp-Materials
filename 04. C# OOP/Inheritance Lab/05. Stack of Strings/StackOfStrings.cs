using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        private Stack<string> stack;

        public StackOfStrings()
        {
            stack = new Stack<string>();
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

        public Stack<string> AddRange()
        {

        }
    }
}
