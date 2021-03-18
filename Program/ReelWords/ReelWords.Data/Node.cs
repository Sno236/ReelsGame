using System;
using System.Collections.Generic;
using System.Text;

namespace ReelWords
{
    public class Node
    {
        public char c;
        public bool isWord;
        public Node[] children;

        public Node(char c)
        {
            this.c = c;
            isWord = false;
            children = new Node[27];
        }
    }
}
