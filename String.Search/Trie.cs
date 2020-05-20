using System;
using System.Collections.Generic;
using System.Text;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("String.Search.Tests")]

namespace String.Search
{
    class Trie
    {
        private readonly TrieNode root = new TrieNode('~'); // Any meaningless char is OK here

        public Trie()
        { }

        public Trie(IEnumerable<string> terms)
        {
            foreach (var term in terms)
            {
                Insert(term);
            }
        }

        public void Insert(char[] term)
        {
            var p = root;
            foreach (var c in term)
            {
                p = p.GetOrAppend(c);
            }
            p.SetEnding();
        }

        public void Insert(string term)
        {
            Insert(term.ToCharArray());
        }

        public bool Exists(char[] pattern)
        {
            var p = root;
            foreach (var c in pattern)
            {
                p = p.Find(c);
                if (p == null)
                {
                    // Not found
                    return false;
                }
            }

            return p.IsEndingChar;
        }

        public bool Exists(string pattern)
        {
            return Exists(pattern.ToCharArray());
        }
    }
}
