using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace String.Search.Tests
{
    [TestClass]
    public class TrieTests
    {
        [TestMethod]
        public void TrieExists_Should_ReturnExpected()
        {
            var trie = new Trie(new List<string>
            {
                "how",
                "hi",
                "her",
                "hello",
                "so",
                "see"
            });

            Assert.IsTrue(trie.Exists("how"));
            Assert.IsTrue(trie.Exists("hi"));
            Assert.IsTrue(trie.Exists("HER"));
            Assert.IsTrue(trie.Exists("Hello"));
            Assert.IsTrue(trie.Exists("so"));
            Assert.IsTrue(trie.Exists("See"));

            Assert.IsFalse(trie.Exists("HERE"));
            Assert.IsFalse(trie.Exists("he"));
            Assert.IsFalse(trie.Exists("she"));
        }
    }
}
