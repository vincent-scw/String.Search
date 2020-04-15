using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace String.Search.Tests
{
    [TestClass]
    public class StringSearchTestscs
    {
        private List<Candidate> _candidates;
        [TestInitialize]
        public void Init()
        {
            _candidates = new List<Candidate>
            {
                new Candidate("_20 FT 20' STANDARD CONTAINER"),
                new Candidate("_40 FT 40' STANDARD CONTAINER"),
                new Candidate("_40 HC 40' HIGH CUBE CONTAINER"),
                new Candidate("_45 GP 45' GENERAL PURPOSE CONTAINER"),
                new Candidate("_45 HC 45' HIGH CUBE CONTAINER"),
                new Candidate("_20 DR 20' DRY REEFER CONTAINER"),
                new Candidate("_20 FC 20' FLEXIBAG CONTAINER"),
                new Candidate("_20 FG 20' FOOD GRADE CONTAINER"),
                new Candidate("_20 FR 20' FLAT RACK CONTAINER"),
                new Candidate("_20 GH 20' GARMENT ON HANGER CONTAINER"),
                new Candidate("_20 HC 20' HIGH CUBE CONTAINER"),
                new Candidate("_20 HD 20' H/D REEFER CONTAINER"),
                new Candidate("_20 IT 20' ISO TANK"),
                new Candidate("_20 OT 20' OPEN TOP CONTAINER"),
                new Candidate("_20 PF 20' PLATFORMS"),
                new Candidate("_20 RF 20' REEFER CONTAINER"),
                new Candidate("_20 RH 20' HIGH CUBE REEFER CONTAINER"),
                new Candidate("_20 SL 20' SLIDING OPEN CONTAINER")
            };
        }

        [TestMethod]
        public void Search_FromCandidates_ShouldAsExpected()
        {
            var ss = new StringSearch(_candidates);
            var result = ss.Search("40' High Cube Dry");

            Assert.AreEqual("_40 HC 40' HIGH CUBE CONTAINER", result);
        }

        [TestMethod]
        public void Search_NoMatches_ShouldReturnNull()
        {
            var ss = new StringSearch(_candidates);
            var result = ss.Search("ABC");
            
            Assert.IsNull(result);
        }
    }                           
}                               
                                
                                
                                