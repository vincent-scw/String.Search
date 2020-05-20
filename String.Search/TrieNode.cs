using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace String.Search
{
    class TrieNode
    {
        private readonly char data;
        public bool IsEndingChar { get; private set; }
        public IDictionary<char, TrieNode> Children { get; private set; }

        public TrieNode(char data)
        {
            this.data = data;
            Children = new Dictionary<char, TrieNode>();
        }

        public void SetEnding()
        {
            IsEndingChar = true;
        }

        public TrieNode GetOrAppend(char next)
        {
            var lowered = char.ToLower(next);
            var found = Children.TryGetValue(lowered, out TrieNode tnext);
            if (!found)
            {
                tnext = new TrieNode(lowered);
                Children.Add(lowered, tnext);
            }

            return tnext;
        }

        public TrieNode Find(char next)
        {
            var lowered = char.ToLower(next);
            Children.TryGetValue(lowered, out TrieNode tnext);
            return tnext;
        }
    }
}
