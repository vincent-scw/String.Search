using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace String.Search.Tests
{
    [TestClass]
    public class StringSearchTestscs
    {
        private List<string> _candidates;
        [TestInitialize]
        public void Init()
        {
            _candidates = new List<string>
            {
                "_20 FT 20' STANDARD CONTAINER",
                "_40 FT 40' STANDARD CONTAINER",
                "_40 HC 40' HIGH CUBE CONTAINER",
                "_45 GP 45' GENERAL PURPOSE CONTAINER",
                "_45 HC 45' HIGH CUBE CONTAINER",
                "_20 DR 20' DRY REEFER CONTAINER",
                "_20 FC 20' FLEXIBAG CONTAINER",
                "_20 FG 20' FOOD GRADE CONTAINER",
                "_20 FR 20' FLAT RACK CONTAINER",
                "_20 GH 20' GARMENT ON HANGER CONTAINER",
            };
        }

        [TestMethod]
        public void Search_FromCandidates_ShouldAsExpected()
        {
            var ss = new StringSearch(_candidates);
            var result = ss.Search("40' High Cube Dry");

            Assert.AreEqual(("_40 HC 40' HIGH CUBE CONTAINER", 3), result);
        }

        [TestMethod]
        public void Search_NoMatches_ShouldReturnNull()
        {
            var ss = new StringSearch(_candidates);
            var result = ss.Search("ABC");
            
            Assert.AreEqual((null, 0), result);
        }

        [TestMethod]
        public void Search_WithWeights_ShouldAsExpected()
        {
            var weights = new ScoreWeights();
            weights.Add(
                ("container", 0.1m),
                ("STANDARD", 0.3m)
            );
            var ss = new StringSearch(_candidates, weights);
            var result = ss.Search("25' STANDARD CONTAINER");

            Assert.AreEqual((null, 0.4m), result);
        }
    }                           
}                               
                                
                                
                                