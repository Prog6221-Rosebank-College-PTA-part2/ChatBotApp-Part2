
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace ChatbotApp
{
    public class MainForm : Form
    {
        private RichTextBox chatDisplay;

        private TextBox inputBox;

        private Button sendButton;

        private Button helpButton;

        public MainForm()
        {
            BuildUI();

         //   PlayGreeting();

            ShowWelcome();
        }

        private void BuildUI()
        {
            // Form settings
            Text = "🔒 Cybersecurity Awareness Bot";

            Size = new Size(800, 600);

            StartPosition =
                FormStartPosition.CenterScreen;

            BackColor = Color.FromArgb(13, 17, 23);

            // Chat display
            chatDisplay = new RichTextBox
            {
                Dock = DockStyle.Fill,

                BackColor = Color.Black,

                ForeColor = Color.White,

                Font = new Font("Segoe UI", 10),

                ReadOnly = true
            };

            // Bottom panel
            Panel bottomPanel = new Panel
            {
                Dock = DockStyle.Bottom,

                Height = 60,

                BackColor = Color.FromArgb(22, 27, 34)
            };

            // Input box
            inputBox = new TextBox
            {
                Width = 500,

                Location = new Point(10, 15),

                Font = new Font("Segoe UI", 10)
            };

            // Press Enter to send
            inputBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;

                    ProcessInput();
                }
            };

            // Send button
            sendButton = new Button
            {
                Text = "Send ➤",

                Width = 100,

                Height = 35,

                Location = new Point(520, 12),

                BackColor = Color.Green,

                ForeColor = Color.White,

                FlatStyle = FlatStyle.Flat
            };

            sendButton.Click += (s, e) =>
            {
                ProcessInput();
            };

            // Help button
            helpButton = new Button
            {
                Text = "Help",

                Width = 100,

                Height = 35,

                Location = new Point(630, 12),

                BackColor = Color.DodgerBlue,

                ForeColor = Color.White,

                FlatStyle = FlatStyle.Flat
            };

            helpButton.Click += (s, e) =>
            {
                HelpForm help = new HelpForm();

                help.OnTopicSelected += (topic) =>
                {
                    inputBox.Text = topic;

                    ProcessInput();
                };

                help.ShowDialog();
            };

            // Add controls
            bottomPanel.Controls.Add(inputBox);

            bottomPanel.Controls.Add(sendButton);

            bottomPanel.Controls.Add(helpButton);

            Controls.Add(chatDisplay);

            Controls.Add(bottomPanel);
        }

        // Welcome message
        private void ShowWelcome()
        {
            string welcome =
                "Hello " + MemoryStore.UserName +
                "! Welcome to the Cybersecurity Awareness Bot.\n" +
                "Ask me about passwords, phishing, privacy, malware or 2FA.";

            AppendMessage("🤖 Bot", welcome);
        }

        // Process user input
        private void ProcessInput()
        {
            string input = inputBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            // Show user message
            AppendMessage(
                MemoryStore.UserName,
                input
            );

            // Detect sentiment
            var mood =
                SentimentDetector.Detect(input);

            // Get handler
            var handler =
                SentimentDetector.GetHandler(mood);

            // Get response
            string response =
                ResponseEngine.GetResponse(
                    input,
                    handler
                );

            // Show response
            AppendMessage(
                "🤖 Bot",
                response
            );

            // Save history
            MemoryStore.ConversationHistory.Add(
                MemoryStore.UserName + ": " + input
            );

            MemoryStore.ConversationHistory.Add(
                "Bot: " + response
            );

            inputBox.Clear();
        }

        // Display messages
        private void AppendMessage(
            string sender,
            string message)
        {
            chatDisplay.SelectionColor =
                Color.LimeGreen;

            chatDisplay.AppendText(
                sender + ":\n"
            );

            chatDisplay.SelectionColor =
                Color.White;

            chatDisplay.AppendText(
                message + "\n\n"
            );

            chatDisplay.ScrollToCaret();
        }

       /* private void PlayGreeting()
        {
            try
            {
                string path =
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "Greeting.wav"
                    );

                if (File.Exists(path))
                {
                    SoundPlayer player =
                        new SoundPlayer(path);

                    player.Load();

                    player.Play();
                }
                else
                {
                    MessageBox.Show(
                        "\"voice greetings first" + path
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Audio Error:\n" + ex.Message
                );*/
            }
        }
    
