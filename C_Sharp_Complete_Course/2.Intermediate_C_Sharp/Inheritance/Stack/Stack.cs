using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOperations
{
    public class Stack
    {
        object[] stack = new object[1024];
        int top = -1;
        public void push(object value)
        {
            stack[++top] = value;
        }
        public object pop()
        {
            
            if (top == -1)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            else
            {
                object popElement=stack[top];
                top--;
                return popElement;
            }
        }
        public void clear()
        {
            top = -1;
        }
    }
}
