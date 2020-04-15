using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("String.Search.Tests")]

namespace String.Search
{    
    static class StringSplitter
    {
        public static string[] Split(string source)
        {
            // Remove special characters
            var splited = Regex.Split(source, @"[^A-Za-z0-9]");
            var ret = splited.SelectMany(s =>
            {
                if (string.IsNullOrEmpty(s))
                {
                    return new string[] { };
                }
                // And space if necessary
                var replaced = Regex.Replace(s, @"((?<=[a-z])[A-Z]|(?<!^)[A-Z](?=[a-z])|(?<![\d])[\d])", " $1");
                return replaced.Trim().Split(' ');
            });

            return ret.ToArray();
        }
    }
}
