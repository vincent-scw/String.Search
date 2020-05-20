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
            var acFinder = new AcAutoMachine(patterns);
            return acFinder.Match(text);
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
            var acFinder = new AcAutoMachine(patterns);
            return acFinder.Replace(text, replaceWith);
        }
    }
}
