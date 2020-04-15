using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace String.Search
{
    public class StringSearch
    {
        private readonly Candidate[] _candidates;
        public StringSearch(IEnumerable<Candidate> candidates)
        {
            _candidates = candidates.ToArray();
        }

        public string Search(string value)
        {
            var valueArray = StringSplitter.SplitSortedLowercase(value);
            int index = -1;
            decimal maxScore = 0;

            for (int i = 0; i < _candidates.Length; i++)
            {
                var score = Compare(StringSplitter.SplitSortedLowercase(_candidates[i].Value), valueArray);
                if (score > maxScore)
                {
                    maxScore = score;
                    index = i;
                }
            }

            if (index < 0)
                return null;

            return _candidates[index].Value;
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
                    score++;
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
