using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChatbotApp
{
    public class HelpForm : Form
    {
        public delegate void TopicSelectedHandler(
            string topic);

        public event TopicSelectedHandler?
            OnTopicSelected;

        public HelpForm()
        {
            BuildUI();
        }

        private void BuildUI()
        {
            Text = "Help";
            Size = new Size(400, 450);

            BackColor = Color.FromArgb(22, 27, 34);
           // BackColor = Color.;

            FlowLayoutPanel panel =
                new FlowLayoutPanel();

            panel.Dock = DockStyle.Fill;

            string[] topics =
            {
                "password",
                "phishing",
                "privacy",
                "malware",
                "2fa"
            };

            foreach (string topic in topics)
            {
                Button btn = new Button();

                btn.Text = topic;

                btn.Width = 300;

                btn.Height = 50;

                btn.BackColor =
                    Color.WhiteSmoke;

                btn.ForeColor = Color.LimeGreen;

                btn.FlatStyle = FlatStyle.Flat;

                btn.Click += (s, e) =>
                {
                    OnTopicSelected?.Invoke(topic);

                    Close();
                };

                panel.Controls.Add(btn);
            }

            Controls.Add(panel);
        }
    }
}