using System;
using System.Media;
using System.Threading;
namespace Chatbot
{
    class Chatbot
    {
        static void Main()
        {

            // ASCII Logo Header
            Console.WriteLine(@"   ________  ______  __________     _____ ______________  ______  ____________  __   ___ _       _____    ____  _______   __________________    ____  ____  ______
  / ____/\ \/ / __ )/ ____/ __ \   / ___// ____/ ____/ / / / __ \/  _/_  __/\ \/ /  /   | |     / /   |  / __ \/ ____/ | / / ____/ ___/ ___/   / __ )/ __ \/_  __/
 / /      \  / __  / __/ / /_/ /   \__ \/ __/ / /   / / / / /_/ // /  / /    \  /  / /| | | /| / / /| | / /_/ / __/ /  |/ / __/  \__ \\__ \   / __  / / / / / /   
/ /___    / / /_/ / /___/ _, _/   ___/ / /___/ /___/ /_/ / _, _// /  / /     / /  / ___ | |/ |/ / ___ |/ _, _/ /___/ /|  / /___ ___/ /__/ /  / /_/ / /_/ / / /    
\____/   /_/_____/_____/_/ |_|   /____/_____/\____/\____/_/ |_/___/ /_/     /_/  /_/  |_|__/|__/_/  |_/_/ |_/_____/_/ |_/_____//____/____/  /_____/\____/ /_/     
                                                                                                                                                                  
                          ===================================================================================================================
                                                                                                                                                                                  ");

            // WAV file
            string audioPath = @"Cyber Security Awareness Bot Welcome audio (1).wav";

            // SoundPlayer object
            SoundPlayer player = new SoundPlayer(audioPath);

            try
            {
                player.Load();        // Audio file load 
                player.PlaySync();    // Audio file play

                Console.WriteLine("Audio finished playing.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // Ask user for name
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nEnter your name: ");
            Console.ResetColor();

            string userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "User";
            }


            // Welcome message and instructions
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
╔══════════════════════════════════════════════════════════╗
║                                                          ║
║          WELCOME TO CYBER SECURITY AWARENESS             ║
║                                                          ║
╚══════════════════════════════════════════════════════════╝
");
            Console.ResetColor();

            TypeText($"Hello, {userName}! 👋");
            TypeText("I am your Cyber Security Assistant.");
            TypeText("Type 'exit' anytime to quit.\n");

            Divider();

            // CHAT LOOP
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\n{userName}: ");
                Console.ResetColor();

                string input = Console.ReadLine();

                // INVALID INPUT (empty)
                if (string.IsNullOrWhiteSpace(input))
                {
                    BotResponse("⚠️ You entered nothing. Please type something.");
                    continue;
                }

                input = input.ToLower();

                // EXIT
                if (input == "exit")
                {
                    BotResponse("Stay safe online! Goodbye 👋");
                    break;
                }

                Divider();

                // RESPONSES
                if (input.Contains("how are you"))
                {
                    BotResponse($"I'm operating at full capacity, {userName}! 🔐");
                }
                else if (input.Contains("purpose"))
                {
                    BotResponse("My purpose is to help you stay safe online and learn cybersecurity best practices.");
                }
                else if (input.Contains("what can i ask") || input.Contains("help"))
                {
                    BotResponse("You can ask me about:\n" +
                                "• Password safety \n" +
                                "• Phishing attacks \n" +
                                "• Malware \n" +
                                "• Safe browsing ");
                }
                else
                {
                    // DEFAULT RESPONSE
                    BotResponse("I don't quite understand that. Could you rephrase?");
                }

                Divider();
            }
        }

        // BOT RESPONSE WITH COLOR + TYPING EFFECT
        static void BotResponse(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Bot: ");
            Console.ResetColor();

            TypeText(message);
        }

        // TYPING EFFECT
        static void TypeText(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(20); // adjust speed here
            }
            Console.WriteLine();
        }

        // DIVIDER LINE
        static void Divider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n----------------------------------------------------------");
            Console.ResetColor();
        }






    }
}