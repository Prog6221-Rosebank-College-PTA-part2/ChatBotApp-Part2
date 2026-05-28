using System;
public static class ChatbotUI
{
    public static void DisplayAsciiLogo()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
  ╔══════════════════════════════════════════════════════════╗
  ║                                                          ║
  ║    ██████╗██╗   ██╗██████╗ ███████╗██████╗              ║
  ║   ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗             ║
  ║   ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝             ║
  ║   ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗             ║
  ║   ╚██████╗   ██║   ██████╔╝███████╗██║  ██║             ║
  ║    ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝             ║
  ║                                                          ║
  ║          🔒 Cybersecurity Awareness Bot 🔒               ║
  ║       Keeping You Safe in the Digital World              ║
  ║                                                          ║
  ╚══════════════════════════════════════════════════════════╝
        ");
        Console.ResetColor();
    }

    public static void DisplayDivider()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("  " + new string('─', 58));
        Console.ResetColor();
    }

    public static void DisplayBotMessage(string message)
    {
        SimulateTyping("  🤖 Bot: " + message, ConsoleColor.Green);
    }

    public static void DisplayUserPrompt(string name)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"\n  👤 {name}: ");
        Console.ResetColor();
    }

    public static void DisplaySectionHeader(string title)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"  ══ {title} ══");
        Console.ResetColor();
    }

    private static void SimulateTyping(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine();
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(18); // typing effect delay
        }
        Console.WriteLine();
        Console.ResetColor();
    }
}



