using System;
using System.Collections.Generic;

namespace TheLocal404
{
    public class IdentifierSentence
    {

        /// <summary>
        /// List of adjectives to use.
        /// </summary>
        private static readonly List<string> adjectives =
            new List<string>
            {
                "cute", "dapper", "large", "small", "long", "short", "thick",
                "narrow", "deep", "flat", "whole", "low", "high", "near", "far",
                "fast", "quick", "slow", "early", "late", "bright", "dark",
                "cloudy", "warm", "cool", "cold", "windy", "noisy", "loud",
                "quiet", "dry", "clear", "hard", "soft", "heavy", "light",
                "strong", "weak", "tidy", "clean", "dirty", "empty", "full",
                "close", "thirsty", "hungry", "fat", "old", "fresh", "dead",
                "healthy", "sweet", "sour", "bitter", "salty", "good", "bad",
                "great", "important", "useful", "expensive", "cheap", "free",
                "difficult", "strong", "weak", "able", "free", "rich", "afraid",
                "brave", "fine", "sad", "proud", "comfortable", "happy", "clever",
                "interesting", "famous", "exciting", "funny", "kind", "polite",
                "fair", "share", "busy", "free", "lazy", "lucky", "careful",
                "safe", "dangerous", "mad"
            };

        /// <summary>
        /// List of proper nouns. Currently animals.
        /// </summary>
        private static readonly List<string> nouns =
            new List<string>
            {
                "rabbits", "badgers", "foxes", "chickens", "bats", "deer",
                "snakes", "hares", "hedgehogs", "platypuses", "moles", "mice",
                "otters", "rats", "squirrels", "stoats", "weasels", "crows",
                "doves", "ducks", "geese", "hawks", "herons", "kingfishers",
                "owls", "peafowl", "pheasants", "pigeons", "robins", "rooks",
                "sparrows", "starlings", "swans", "ants", "bees", "butterflies",
                "dragonflies", "flies", "moths", "spiders", "pikes", "salmons",
                "trouts", "frogs", "newts", "toads", "crabs", "lobsters", "clams",
                "cockles", "mussles", "oysters", "snails", "cattle", "dogs",
                "donkeys", "goats", "horses", "pigs", "sheep", "ferrets",
                "gerbils", "guineapigs", "parrots", "greg", "orcs"
            };

        /// <summary>
        /// Past tense verbs. 
        /// </summary>
        private static readonly List<string> verbs =
            new List<string>
            {
                "sang", "played", "knitted", "floundered", "danced", "played",
                "listened", "ran", "talked", "cuddled", "sat", "kissed", "hugged",
                "whimpered", "hid", "fought", "whispered", "cried", "snuggled",
                "walked", "drove", "loitered", "whimpered", "felt", "jumped",
                "hopped", "went", "married", "engaged", "stomped"
            };

        /// <summary>
        /// Adverbs list.
        /// </summary>
        private static readonly List<string> adverbs =
            new List<string>
            {
                "jovially", "merrily", "cordially", "easily", "loudly"
            };

        private static readonly int adjectiveFactor = 32;
        private static readonly int nounFactor = adjectiveFactor * adjectives.Count;
        private static readonly int verbFactor = nounFactor * nouns.Count;
        private static readonly int adverbFactor = verbFactor * verbs.Count;

        /// <summary>
        /// Returns the numerical value from the sentence.
        /// </summary>
        /// <param name="sentence">The sentence to parse for an Id</param>
        /// <returns></returns>
        public static int Parse(string sentence)
        {
            var splitSentence = sentence.Split(' ');
            int count;

            // If we can't parse the first part we throw exception.
            if (!Int32.TryParse(splitSentence[0], out count))
                throw new Exception("Bad identifier sentence provided.");

            // get the parts of the sentence.
            var adjective = adjectives.IndexOf(splitSentence[1]);
            var noun = nouns.IndexOf(splitSentence[2]);
            var verb = verbs.IndexOf(splitSentence[3]);
            var adverb = adverbs.IndexOf(splitSentence[4]);

            return count +
                    (adjective * adjectiveFactor) +
                    (noun * nounFactor) +
                    (verb * verbFactor) +
                    (adverb * adverbFactor);
        }

        /// <summary>
        /// Returns a randomly generated sentence that can be used to identify 
        /// certain items. 
        /// </summary>
        /// <returns></returns>
        public static string Random()
        {
            // get a random starting value.
            var randomInt = getRandomInt(33) + 2;

            // get a random selection of words to form the sentence.
            var adjective = getRandomItemFromList(adjectives);
            var noun = getRandomItemFromList(nouns);
            var verb = getRandomItemFromList(verbs);
            var adverb = getRandomItemFromList(adverbs);

            // return the new sentence.
            return string.Format("{0} {1} {2} {3} {4}", randomInt, adjective, noun, verb, adverb);
        }

        /// <summary>
        /// Get's a random item from the supplied list.
        /// </summary>
        /// <param name="list">The list to choose a random item from</param>
        /// <returns></returns>
        private static object getRandomItemFromList(List<string> list)
        {
            return list[getRandomInt(list.Count)];
        }

        /// <summary>
        /// Get's a random integer between 0 and the supplied max value.
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        private static int getRandomInt(int max)
        {
            var rnd = new Random();
            return rnd.Next(0, max);
        }
    }
}
