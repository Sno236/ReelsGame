using System;

namespace ReelWords
{
    public class Trie
    {
        Node root;
        public Trie()
        {
            root = new Node('^');
        }
        public bool Search(string word)
        {
            Node node = GetNode(word);
            return (node != null && node.isWord);
        }

        public void Insert(string word)
        {
            Node current = root;
            int index = 0;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (c == '\'')
                {
                    index = 26;
                }
                else
                {
                    index = c - 'a';
                }
                if (current.children[index] == null)
                {
                    current.children[index] = new Node(c);
                }
                current = current.children[index];
            }
            current.isWord = true;
        }

        public void Delete(string s)
        {
            throw new NotImplementedException();
        }

        private Node GetNode(string word)
        {
            Node current = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (current.children[c - 'a'] == null)
                {
                    return null;
                }
                current = current.children[c - 'a'];
            }
            return current;
        }
    }

}