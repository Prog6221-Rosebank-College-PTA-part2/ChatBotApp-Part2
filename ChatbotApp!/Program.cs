
using System;
using System.Windows.Forms;
using Sound;

namespace ChatbotApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);
            //play greeting sound
            Audio.PlayGreeting("Greetings.wav");


            NameForm nameForm = new NameForm();

            // Receive name from NameForm
            nameForm.OnNameSubmitted += (name) =>
            {
                MemoryStore.UserName = name;

                nameForm.Hide();

                MainForm main = new MainForm();
                

                // Close application properly
                main.FormClosed += (s, e) =>
                {
                    Application.Exit();
                };

                main.Show();
            };
           

            Application.Run(nameForm);
        }
    }
}