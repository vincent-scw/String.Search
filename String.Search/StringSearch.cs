using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace String.Search
{
    public class StringSearch
    {
        private readonly string[] _candidates;
        private readonly ScoreWeights _definition;
        private readonly decimal _threshold;
        public StringSearch(IEnumerable<string> candidates)
        {
            _candidates = candidates.ToArray();
            _definition = new ScoreWeights();
        }

        public StringSearch(IEnumerable<string> candidates, 
            ScoreWeights definition, decimal threshold = ScoreWeights.DefaultScore)
        {
            _candidates = candidates.ToArray();
            _definition = definition;
            _threshold = threshold;
        }

        public (string match, decimal score) Search(string value)
        {
            var valueArray = StringSplitter.SplitSortedLowercase(value);
            int index = -1;
            decimal maxScore = 0;

            for (int i = 0; i < _candidates.Length; i++)
            {
                var score = Compare(StringSplitter.SplitSortedLowercase(_candidates[i]), valueArray);
                if (score > maxScore)
                {
                    maxScore = score;
                    index = i;
                }
            }

            if (maxScore < _threshold)
                return (null, maxScore);

            return (_candidates[index], maxScore);
        }

        private decimal Compare(string[] v, string[] c)
        {
            int iv = 0, ic = 0;
            decimal score = 0;
            while (iv < v.Length && ic < c.Length)
            {
                var diff = v[iv].CompareTo(c[ic]);
                if (diff == 0)
                {
                    var currScore = _definition.GetScore(v[iv]);
                    score += currScore;
                    iv++;
                    ic++;
                }
                else
                {
                    if (diff > 0)
                        ic++;
                    else
                        iv++;
                }
            }

            return score;
        }
    }
}
