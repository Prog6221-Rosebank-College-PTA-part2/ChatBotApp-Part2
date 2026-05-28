using System;

namespace ChatbotApp
{
    public static class SentimentDetector
    {
        public enum Sentiment
        {
            Neutral,
            Worried,
            Frustrated,
            Curious
        }

        public delegate string SentimentResponseHandler(
            string botResponse);

        public static string[] WorriedWords =
        {
            "worried",
            "scared",
            "afraid",
            "unsafe"
        };

        public static string[] FrustratedWords =
        {
            "frustrated",
            "angry",
            "confused",
            "stuck"
        };

        public static string[] CuriousWords =
        {
            "curious",
            "interested",
            "tell me",
            "how does"
        };

        public static Sentiment Detect(string input)
        {
            string lower = input.ToLower();

            foreach (string word in WorriedWords)
            {
                if (lower.Contains(word))
                    return Sentiment.Worried;
            }

            foreach (string word in FrustratedWords)
            {
                if (lower.Contains(word))
                    return Sentiment.Frustrated;
            }

            foreach (string word in CuriousWords)
            {
                if (lower.Contains(word))
                    return Sentiment.Curious;
            }

            return Sentiment.Neutral;
        }

        public static SentimentResponseHandler GetHandler(
            Sentiment mood)
        {
            if (mood == Sentiment.Worried)
            {
                return delegate (string response)
                {
                    return "I understand your concern.\n"
                        + response;
                };
            }

            if (mood == Sentiment.Frustrated)
            {
                return delegate (string response)
                {
                    return "I am sorry you are frustrated.\n"
                        + response;
                };
            }

            if (mood == Sentiment.Curious)
            {
                return delegate (string response)
                {
                    return "Great question!\n"
                        + response;
                };
            }

            return delegate (string response)
            {
                return response;
            };
        }
    }
}