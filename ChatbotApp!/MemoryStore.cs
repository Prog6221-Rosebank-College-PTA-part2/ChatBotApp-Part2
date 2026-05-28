using System.Collections.Generic;

namespace ChatbotApp
{
    public static class MemoryStore
    {
        // Stores user name
        public static string UserName = string.Empty;

        // Stores favourite topic
        public static string FavouriteTopic = string.Empty;

        // Stores conversation history
        public static List<string> ConversationHistory =
            new List<string>();

        // Save topic
        public static void Remember(string topic)
        {
            FavouriteTopic = topic;
        }

        // Recall topic
        public static string Recall()
        {
            if (FavouriteTopic != string.Empty)
            {
                return "Since you are interested in "
                    + FavouriteTopic
                    + ", remember to review your security settings.";
            }

            return string.Empty;
        }
    }
}