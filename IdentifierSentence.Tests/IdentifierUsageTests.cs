using FluentAssertions;
using System;
using Xunit;

namespace TheLocal404.Tests
{
    public class IdentifierUsageTests
    {
        [Fact]
        public void IdentifierCanParseToNumber()
        {
            var knownSentence = "8 mad orcs stomp loudly";

            int parsedId = IdentifierSentence.Parse(knownSentence);

            parsedId.Should().Be(23569896);
        }

        [Fact]
        public void IdentifierCanGenerateRandomSentence()
        {
            var randomSentence = IdentifierSentence.Random();
            Action parsingAction = () => IdentifierSentence.Parse(randomSentence);

            randomSentence.Should().NotBeNullOrEmpty();
            parsingAction.Should().NotThrow();
        }

        [Fact]
        public void ShouldThrowExceptionWithBadSentence()
        {
            var badSentence = "Something Bad Here";
            Action parsingAction = () => IdentifierSentence.Parse(badSentence);

            parsingAction.Should()
                         .Throw<Exception>()
                         .WithMessage("Bad identifier sentence provided.");
        }
    }
}
