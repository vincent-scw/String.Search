using System;
using System.Collections.Generic;
using System.Text;

namespace String.Search.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Search in text with given patterns
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="patterns">Patterns</param>
        /// <returns>Search results with position</returns>
        public static IEnumerable<(int position, string value)> Search(this string text, IEnumerable<string> patterns)
        {
            var acMatcher = new AcPatternMatcher(patterns);
            return Search(text, acMatcher);
        }

        /// <summary>
        /// Replace contents in text that match given patterns
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="patterns">Patterns</param>
        /// <param name="replaceWith">Replace content with</param>
        /// <returns>Replaced string</returns>
        public static string Replace(this string text, IEnumerable<string> patterns, char replaceWith = '*')
        {
            var acMatcher = new AcPatternMatcher(patterns);
            return Replace(text, acMatcher, replaceWith);
        }

        /// <summary>
        /// Search in text with given patterns
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="acMachine">Aho-Corasick</param>
        /// <returns>Search results with position</returns>
        public static IEnumerable<(int position, string value)> Search(this string text, AcPatternMatcher acMatcher)
        {
            return acMatcher.Match(text);
        }

        /// <summary>
        /// Replace contents in text that match given patterns
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="acMachine">Aho-Corasick</param>
        /// <param name="replaceWith">Replace content with</param>
        /// <returns>Replaced string</returns>
        public static string Replace(this string text, AcPatternMatcher acMatcher, char replaceWith = '*')
        {
            return acMatcher.Replace(text, replaceWith);
        }

        /// <summary>
        /// Get the distance between two strings, using Damerau-Levenshtein Distance Algorithm
        /// </summary>
        /// <param name="me">string A</param>
        /// <param name="other">string B</param>
        /// <param name="ignoreCase">Case-sensitive?</param>
        /// <returns>Distance</returns>
        public static int DistanceTo(this string me, string other, bool ignoreCase = true)
        {
            if (string.IsNullOrEmpty(me) || string.IsNullOrEmpty(other))
            {
                return Math.Max(me?.Length ?? 0, other?.Length ?? 0);
            }

            if (ignoreCase)
            {
                me = me.ToLower();
                other = other.ToLower();
            }

            int m = me.Length + 1, n = other.Length + 1;
            int[,] matrix = new int[m, n];

            for (var i = 0; i < m; i++) { matrix[i, 0] = i; }
            for (var j = 0; j < n; j++) { matrix[0, j] = j; }

            for (var p = 1; p < m; p++)
            {
                for (var q = 1; q < n; q++)
                {
                    // If the characters at current position are same, then the cost is 0
                    var cost = me[p - 1] == other[q - 1] ? 0 : 1;
                    var insertion = matrix[p, q - 1] + 1;
                    var deletion = matrix[p - 1, q] + 1;
                    var sub = matrix[p - 1, q - 1] + cost;

                    // Get the minimum
                    var distance = Math.Min(insertion, Math.Min(deletion, sub));
                    if (p > 1 && q > 1 && me[p - 1] == other[q - 2] && me[q - 2] == other[q - 1])
                    {
                        distance = Math.Min(distance, matrix[q - 2, p - 2] + cost);
                    }

                    matrix[p, q] = distance;
                }
            }

            return matrix[m - 1, n - 1];
        }
    }
}
