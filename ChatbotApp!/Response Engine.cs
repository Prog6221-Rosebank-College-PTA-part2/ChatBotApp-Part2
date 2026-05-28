using System;
using System.Collections.Generic;

namespace ChatbotApp
{
    public static class ResponseEngine
    {
        public static string LastTopic = string.Empty;

        public static Random RandomPicker =
            new Random();

        public static string[] FollowUpWords =
        {
            "tell me more",
            "more",
            "continue",
            "go on"
        };

        public static Dictionary<string[], string[]>
            Responses =
            new Dictionary<string[], string[]>()
        {
            {
                new string[]
                {
                    "password",
                    "passwords"
                },

                new string[]
                {
                    "Use strong passwords with symbols and numbers.",
                    "Never reuse passwords across websites.",
                    "Use a password manager."
                }
            },

            {
                new string[]
                {
                    "phishing",
                    "scam",
                    "fake email"
                },

                new string[]
                {
                    "Do not click suspicious links.",
                    "Always check the sender email address.",
                    "Scammers pretend to be trusted companies."
                }
            },

            {
                new string[]
                {
                    "privacy",
                    "data"
                },

                new string[]
                {
                    "Review your privacy settings regularly.",
                    "Avoid sharing too much personal information online.",
                    "Use a VPN on public Wi-Fi."
                }
            },

            {
                new string[]
                {
                    "malware",
                    "virus"
                },

                new string[]
                {
                    "Install antivirus software.",
                    "Never open suspicious attachments.",
                    "Keep backups of important files."
                }
            },

            {
                new string[]
                {
                    "2fa",
                    "mfa"
                },

                new string[]
                {
                    "Enable 2FA on all important accounts.",
                    "Authenticator apps are safer than SMS codes.",
                    "2FA adds extra security to your accounts."
                }
            }
        };

        public static string CleanInput(string input)
        {
            return input.ToLower().Trim();
        }

        public static string GetMoreOnTopic(string topic)
        {
            foreach (var pair in Responses)
            {
                foreach (string key in pair.Key)
                {
                    if (key == topic)
                    {
                        int randomIndex =
                            RandomPicker.Next(pair.Value.Length);

                        return pair.Value[randomIndex];
                    }
                }
            }

            return "I do not have more information.";
        }

        public static string FindResponse(string input)
        {
            foreach (string followUp in FollowUpWords)
            {
                if (input.Contains(followUp)
                    && LastTopic != string.Empty)
                {
                    return GetMoreOnTopic(LastTopic);
                }
            }

            foreach (var pair in Responses)
            {
                foreach (string keyword in pair.Key)
                {
                    if (input.Contains(keyword))
                    {
                        LastTopic = keyword;

                        MemoryStore.Remember(keyword);

                        int randomIndex =
                            RandomPicker.Next(pair.Value.Length);

                        string response =
                            pair.Value[randomIndex];

                        string recall =
                            MemoryStore.Recall();

                        if (recall != string.Empty
                            && RandomPicker.Next(3) == 0)
                        {
                            response += "\n\n" + recall;
                        }

                        return response;
                    }
                }
            }

            return "Try asking about passwords, phishing, privacy, malware or 2FA.";
        }

       
        public static string GetResponse(
            string input,
            SentimentDetector.SentimentResponseHandler handler)
        {
            string cleaned = CleanInput(input);

            string response = FindResponse(cleaned);

            return handler(response);
        }
    }
}