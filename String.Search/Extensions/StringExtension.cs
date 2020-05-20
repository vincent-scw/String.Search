using System;
using System.Collections.Generic;
using System.Text;

namespace String.Search.Extensions
{
    public static class StringExtension
    {
        public static IEnumerable<(int position, string value)> Search(this string text, AcFinder acFinder)
        {
            return acFinder.Match(text);
        }

        public static string Replace(this string text, AcFinder acFinder, char replaceWith = '*')
        {
            return acFinder.Replace(text, replaceWith);
        }
    }
}
