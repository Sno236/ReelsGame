using System;
using System.IO;
using System.Linq;

namespace ReelWords
{
    class Program
    {

        static void Main(string[] args)
        {
            bool playing = true;
            string word;
            int score = 0;

            Random r = new Random();
            ReelValidator val = new ReelValidator();
            val.Initialize();

            Console.WriteLine("Press enter to start...");

            while (playing)
            {                
                // TODO:  Run game logic here using the user input string
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    var options = Helper.GetRandomRow(Helper.InitialReel, r.Next(0,5));
                    Console.WriteLine("Your options are : ");
                    Array.ForEach(options, Console.Write);

                    bool isValid = true;
                    do
                    {
                        Console.WriteLine("\n Enter your input word.. ");
                        word = Console.ReadLine();
                        foreach (char w in word)
                        {
                            if (!Array.Exists(options, x => x.Equals(w)))
                            {
                                isValid = false;
                                Console.WriteLine("Invalid input, please try again");
                            }
                            else
                            {
                                isValid = true;
                                score += Helper.Scores.Where(x=>x.Key == w).Select(x => x.Value).FirstOrDefault();
                            }
                        }
                    } while (!isValid);


                    if (val.SearchTrie(word))
                    {
                        Console.WriteLine("Good Job! Your score is {0}" ,score);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please try again!");
                    }

                }
            }
        }


    }
}