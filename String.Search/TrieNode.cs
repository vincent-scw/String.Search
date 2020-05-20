using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace String.Search
{
    class TrieNode
    {
        public char Current { get; }
        public string Data { get; }
        public bool IsEndingChar { get; set; }
        public IDictionary<char, TrieNode> Children { get; private set; }
        public TrieNode Fail { get; set; }

        public TrieNode(char data, IEnumerable<char> previous)
        {
            Current = data;
            Data = previous == null ? string.Empty : new string(previous.Append(data).ToArray());
            Children = new Dictionary<char, TrieNode>();
        }

        public TrieNode GetOrAppend(char next)
        {
            var lowered = char.ToLower(next);
            var found = Children.TryGetValue(lowered, out TrieNode tnext);
            if (!found)
            {
                tnext = new TrieNode(lowered, Data);
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
