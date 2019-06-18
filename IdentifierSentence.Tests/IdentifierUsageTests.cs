using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheLocal404.Tests
{
    [TestClass]
    public class IdentifierUsageTests
    {
        [TestMethod]
        public void IdentifierCanParseToNumber()
        {
            var knownSentence = "8 mad orcs stomp loudly";

            int parsedId = IdentifierSentence.Parse(knownSentence);

            Assert.AreEqual(23569896, parsedId);
        }

        [TestMethod]
        public void IdentifierCanGenerateRandomSentence()
        {
            var randomSentence = IdentifierSentence.Random();
            Assert.AreNotEqual(string.Empty, randomSentence);

            IdentifierSentence.Parse(randomSentence);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Exception not thrown")]
        public void ShouldThrowExceptionWithBadSentence()
        {
            var badSentence = "Something Bad Here";
            IdentifierSentence.Parse(badSentence);
        }
    }
}
