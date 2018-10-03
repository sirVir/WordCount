using System;
using System.Collections.Generic;

namespace WordCount
{
    public class Trie
    {
        public readonly static int A_INDEX = Convert.ToByte('a');
        public const int CHAR_COUNT = 26;

        private Node root = new Node();

        public void Insert(char[] charArray)
        {
            Node node = root;

            foreach (char character in charArray)
            {
                node = Insert(character, node);
            }

            node.IsWord = true;
            node.Count++;
        }


        public IEnumerable<(string, int)> Traverse()
        {
            return Traverse(root, "");
        }

        // could be optimized to use char arrays of max word length instead of copying string,
        // left for readability
        private IEnumerable<(string, int)> Traverse(Node node, string prefix)
        {
            if (node.IsWord == true)
            {
                yield return (prefix, node.Count);
            }

            for (int i = 0; i < CHAR_COUNT; i++)
            {
                if (node.Children[i] != null)
                {
                    string newPrefix = prefix + ((char)(i + A_INDEX));
                    foreach (var res in Traverse(node.Children[i], newPrefix))
                        yield return res;
                }
            }
        }

        /// <summary>
        /// Inserts a new character into a child of the given node and returns the child;
        /// </summary>
        private Node Insert(char character, Node node)
        {
            if (node.Contains(character))
            {
                return node.GetChild(character);
            }

            else
            {
                int index = Convert.ToByte(character) - A_INDEX;
                Node treeNode = new Node();
                node.Children[index] = treeNode;
                return treeNode;
            }
        }
    }

    public class Node
    {
        public bool IsWord { get; set; }
        public int Count { get; set; }

        // lazily initialize children for the node tree
        private Node[] _children;
        public Node[] Children
        {
            get
            {
                if (_children == null)
                {
                    _children = new Node[Trie.CHAR_COUNT];
                }
                return _children;
            }
        }

        public bool Contains(char character)
        {
            int number = Convert.ToByte(character) - Trie.A_INDEX;

            if (number > Trie.CHAR_COUNT)
                throw new ArgumentException($"Char {character} is out of range for  ASCII Alphabet Characters", "character");

            return (Children[number] != null);
        }

        public Node GetChild(char character)
        {
            int number = Convert.ToByte(character) - Trie.A_INDEX;
            return Children[number];
        }
    }
}
