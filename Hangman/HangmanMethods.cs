using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class HangmanMethods
    {
        public static void StartGame()
        {
            string[] words = new string[1]
            {
                "Apfelsaft",
                /*"Suppe",
                "Kuchen",
                "Dampfschiff",
                "Auto",
                "Fahrrad",
                "Dozent",
                "Supernatural",
                "Anwendungsentwicklung",*/
            };

            Random rnd = new Random();
            int index = rnd.Next(0, words.Length);
            string word = words[index].ToLower();
            GameLoop(word);
        }

        static void GameLoop(string word)
        {
            int lives = 6;
            string hiddenWord = "";

            for (int i = 0; i < word.Length; i++)
            {
                hiddenWord += "_";
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Gesuchtes Wort: " + hiddenWord);
                Console.Write("Noch übrige Versuche: ");

                for (int i = 0; i < lives; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.Write("Buchstabe: ");
                char character = Convert.ToChar(Console.ReadLine().ToLower());

                bool foundCharacterInWord = false;

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == character)
                    {
                        foundCharacterInWord = true;
                        break;
                    }
                }

                string tempHiddenWord = hiddenWord;
                hiddenWord = "";

                if (foundCharacterInWord)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == character)
                        {
                            hiddenWord += character;
                        }
                        else if (tempHiddenWord[i] != '_')
                        {
                            hiddenWord += tempHiddenWord[i];
                        }
                        else
                        {
                            hiddenWord += '_';
                        }
                    }

                    if (hiddenWord == word)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("G E W O N N E N !");
                        Console.WriteLine("Das Word war: " + word);
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        hiddenWord = tempHiddenWord;

                        if (lives > 0)
                        {
                            lives -= 1;
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("L O S E R !");
                            Console.ReadKey();
                            Console.ResetColor();
                            break;
                        }
                    }
                }
            }
        }
    }
}
