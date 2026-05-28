using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChatbotApp
{
    public class NameForm : Form
    {
        public delegate void NameSubmittedHandler(string name);

        public event NameSubmittedHandler? OnNameSubmitted;

        private TextBox nameBox;
        private Button startButton;

        public NameForm()
        {
            BuildUI();
        }

        private void BuildUI()
        {
            Text = "Cybersecurity Bot";
            Size = new Size(420, 220);
            BackColor = Color.FromArgb(22, 27, 34);
            StartPosition = FormStartPosition.CenterScreen;

            Label title = new Label
            {
                Text = "🔒 Cybersecurity Awareness Bot",
                ForeColor = Color.LimeGreen,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Location = new Point(20, 20),
                Size = new Size(360, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label prompt = new Label
            {
                Text = "Enter your name:",
                ForeColor = Color.Lime,
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, 70),
                Size = new Size(300, 25)
            };

            nameBox = new TextBox
            {
                Location = new Point(20, 100),
                Size = new Size(240, 30),
                BackColor = Color.LimeGreen,
                ForeColor = Color.White
            };

            startButton = new Button
            {
                Text = "Start ➤",
                Location = new Point(270, 98),
                Size = new Size(100, 34),
                BackColor = Color.Green,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            startButton.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(nameBox.Text))
                {
                    MessageBox.Show(
                        "Please enter your name."
                    );

                    return;
                }

                OnNameSubmitted?.Invoke(
                    nameBox.Text.Trim()
                );

                Hide();
            };

            Controls.Add(title);
            Controls.Add(prompt);
            Controls.Add(nameBox);
            Controls.Add(startButton);
        }
    }
}