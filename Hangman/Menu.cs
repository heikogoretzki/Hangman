using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Hangman
{
    class Menu
    {
        public static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("#####################");
                Console.WriteLine("###               ###");
                Console.WriteLine("### H A N G M A N ###");
                Console.WriteLine("###               ###");
                Console.WriteLine("#####################");

                Console.WriteLine();

                Console.WriteLine("Wähle eine Aktion aus:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] - Spiel starten");
                Console.WriteLine("[2] - Beenden");
                Console.ResetColor();

                Console.WriteLine();

                Console.Write("Aktion: ");

                //int action = Convert.ToInt32(Console.ReadLine());
                string choice = Console.ReadLine();
                int action;
                bool check = false;
                
                check = Int32.TryParse(choice, out action); // Prüfen ob int möglich
                
                bool end = false;

                switch (action)
                {
                    case 1:
                        HangmanMethods.StartGame();
                        break;

                    case 2:
                        end = true;
                        break;
                }

                if (end)
                {
                    break;
                }

                Console.Clear();
            }
        }
    }
}
