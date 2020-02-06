using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class HeadException : ArgumentException
    {
        public HeadException(string str, Exception inner) : base(str, inner) { }
        public HeadException(string message) : base(message) { }
    }
}
