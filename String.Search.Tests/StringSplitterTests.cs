using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace String.Search.Tests
{
    [TestClass]
    public class StringSplitterTests
    {
        [TestMethod]
        public void Split_ShouldReturnWords()
        {
            var words = StringSplitter.Split("HeIsA20-YearOldBoy.");

            Assert.AreEqual("He", words[0]);
            Assert.AreEqual("Is", words[1]);
            Assert.AreEqual("A", words[2]);
            Assert.AreEqual("20", words[3]);
            Assert.AreEqual("Year", words[4]);
            Assert.AreEqual("Old", words[5]);
            Assert.AreEqual("Boy", words[6]);
        }

        [TestMethod]
        public void Split_ContinusCapitalLetters_ShouldAsExpected()
        {
            var words = StringSplitter.Split("An AAA Game");

            Assert.AreEqual("An", words[0]);
            Assert.AreEqual("AAA", words[1]);
            Assert.AreEqual("Game", words[2]);
        }

        [TestMethod]
        public void Split_WithSpace_ShouldReturnWords()
        {
            var words = StringSplitter.Split("He is a 20-year old boy.");
            
            Assert.AreEqual("He", words[0]);
            Assert.AreEqual("is", words[1]);
            Assert.AreEqual("a", words[2]);
            Assert.AreEqual("20", words[3]);
            Assert.AreEqual("year", words[4]);
            Assert.AreEqual("old", words[5]);
            Assert.AreEqual("boy", words[6]);
        }

        [TestMethod]
        public void Split_Combined_ShouldAsExpected()
        {
            var words = StringSplitter.Split("_20 AAA copiesSold.");

            Assert.AreEqual("20", words[0]);
            Assert.AreEqual("AAA", words[1]);
            Assert.AreEqual("copies", words[2]);
            Assert.AreEqual("Sold", words[3]);
        }
    }
}
