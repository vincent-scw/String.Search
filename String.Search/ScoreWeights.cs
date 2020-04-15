using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace String.Search
{
    public sealed class ScoreWeights
    {
        public const decimal DefaultScore = 1;

        private IDictionary<string, decimal> _def;

        public bool HasDefinition => _def.Any();

        public ScoreWeights()
        {
            _def = new Dictionary<string, decimal>();
        }

        public void Add(params (string key, decimal score)[] def)
        {
            foreach (var item in def)
            {
                _def.Add(item.key.ToLower(), item.score);
            }
        }

        public decimal GetScore(string key)
        {
            var lowKey = key.ToLower();
            return _def.ContainsKey(lowKey) ? _def[lowKey] : DefaultScore;
        }
    }
}
