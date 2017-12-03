using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Monopoly_Probabilities
{
    class Program
    {
        public static string[] chanceDeck = { "ATG", "ATI", "ATS", "ANU", "ANR", "---", "---", "B3S", "GTJ", "---", "---", "ATR", "ATB", "---", "---", "---" };
        public static string[] commDeck = { "ATG", "---", "---", "---", "---", "GTJ", "---", "---", "---", "---", "---", "---", "---", "---", "---", "---", "---", };
        public static Random random = new Random();
        public static string NewChance;
        public static string NewComm;
        public static bool detail;
        public static ConsoleColor fcolor;
        public static ConsoleColor bcolor;
        public static int gameCount = 0;
        public static int gameDisplay = 100000;
        public static int totalRollsNum = 30;

        static void Main(string[] args)
        {
            Console.WriteLine("tankstrr Monopoly Roller v1.0");
            Console.WriteLine("======== ======== ====== ====");
            Console.WriteLine("(inspired by https://www.youtube.com/watch?v=ubQXz5RBBtU)");
            Console.WriteLine("");
            Console.WriteLine("This program will simply simulate the dice rolls around a monopoly board,");
            Console.WriteLine("and track how often you will land on each space.  The following has been");
            Console.WriteLine("implemented:");
            Console.WriteLine("");
            Console.WriteLine("1. Each game consists of " + totalRollsNum + " rolls");
            Console.WriteLine("2. 3 doubles will send you to Jail");
            Console.WriteLine("3. Full Chance and Community Chest decks implemented (space movement)");
            Console.WriteLine("4. No financial transactions (this is simply a roll calculator)");
            Console.WriteLine("");
            Console.WriteLine("Notes:");
            Console.WriteLine("a) JAIL and JUST VISITING are counted as the same space");
            Console.WriteLine("b) This program only counts where your turn ends, not what space you land");
            Console.WriteLine("   on (therefore, GO TO JAIL will always be 0, Chance and Community Chest");
            Console.WriteLine("   will be lower than average)");
            Console.WriteLine("");


            int[] spaceCount = new int[40];
            string[] mBoard = new string[]
            {
                "Go",
                "Mediteranean Ave",
                "Community Chest",
                "Baltic Ave",
                "Income Tax",
                "Reading Railroad",
                "Oriental Ave",
                "Chance",
                "Vermont Ave",
                "Connecticut Ave",
                "Jail (Just Visiting)",
                "St. Charles Place",
                "Electric Company",
                "States Ave",
                "Virginia Ave",
                "Pennsylvania Railroad",
                "St. James Place",
                "Community Chest",
                "Tennesee Ave",
                "New Your Ave",
                "Free Parking",
                "Kentucky Ave",
                "Chance",
                "Indiana Ave",
                "Illinois Ave",
                "B & O Railroad",
                "Atlantic Ave",
                "Ventor Ave",
                "Water Works",
                "Marvin Gardens",
                "GO TO JAIL",
                "Pacific Ave",
                "North Carolina Ave",
                "Community Chest",
                "Pennsylvania Avenue",
                "Short Line",
                "Chance",
                "Park Place",
                "Luxury Tax",
                "Boardwalk"
            };

            string[] mForeColor = new string[]
            {
                "Black", //"Go",
                "White", //"Mediteranean Ave",
                "Black", // "Community Chest",
                "White", // "Baltic Ave",
                "Black", // "Income Tax",
                "Black", // "Reading Railroad",
                "Black", // "Oriental Ave",
                "Black", // "Chance",
                "Black", // "Vermont Ave",
                "Black", // "Connecticut Ave",
                "Black", // "Jail (Just Visiting)",
                "White", // "St. Charles Place",
                "Black", // "Electric Company",
                "White", // "States Ave",
                "White", // "Virginia Ave",
                "Black", // "Pennsylvania Railroad",
                "Black", // "St. James Place",
                "Black", // "Community Chest",
                "Black", // "Tennesee Ave",
                "Black", // "New Your Ave",
                "Red", // "Free Parking",
                "White", // "Kentucky Ave",
                "Black", // "Chance",
                "White", // "Indiana Ave",
                "White", // "Illinois Ave",
                "Black", // "B & O Railroad",
                "Black", // "Atlantic Ave",
                "Black", // "Ventor Ave",
                "Black", // "Water Works",
                "Black", // "Marvin Gardens",
                "Blue", // "GO TO JAIL",
                "Black", // "Pacific Ave",
                "Black", // "North Carolina Ave",
                "Black", // "Community Chest",
                "Black", // "Pennsylvania Avenue",
                "Black", // "Short Line",
                "Black", // "Chance",
                "White", // "Park Place",
                "Black", // "Luxury Tax",
                "White" // "Boardwalk"
            };

            string[] mBackColor = new string[]
            {
                "Gray", //"Go",
                "DarkYellow", //"Mediteranean Ave",
                "Gray", // "Community Chest",
                "DarkYellow", // "Baltic Ave",
                "Gray", // "Income Tax",
                "Gray", // "Reading Railroad",
                "Cyan", // "Oriental Ave",
                "Gray", // "Chance",
                "Cyan", // "Vermont Ave",
                "Cyan", // "Connecticut Ave",
                "Gray", // "Jail (Just Visiting)",
                "DarkMagenta", // "St. Charles Place",
                "Gray", // "Electric Company",
                "DarkMagenta", // "States Ave",
                "DarkMagenta", // "Virginia Ave",
                "Gray", // "Pennsylvania Railroad",
                "DarkYellow", // "St. James Place",
                "Gray", // "Community Chest",
                "DarkYellow", // "Tennesee Ave",
                "DarkYellow", // "New Your Ave",
                "Gray", // "Free Parking",
                "Red", // "Kentucky Ave",
                "Gray", // "Chance",
                "Red", // "Indiana Ave",
                "Red", // "Illinois Ave",
                "Gray", // "B & O Railroad",
                "Yellow", // "Atlantic Ave",
                "Yellow", // "Ventor Ave",
                "Gray", // "Water Works",
                "Yellow", // "Marvin Gardens",
                "Gray", // "GO TO JAIL",
                "Green", // "Pacific Ave",
                "Green", // "North Carolina Ave",
                "Gray", // "Community Chest",
                "Green", // "Pennsylvania Avenue",
                "Gray", // "Short Line",
                "Gray", // "Chance",
                "Blue", // "Park Place",
                "Gray", // "Luxury Tax",
                "Blue" // "Boardwalk"
            };

            Console.Write("How Many Games? (blank = 10): ");
            string totalGames = Console.ReadLine();
            int totalGamesNum;
            if (totalGames == "")
            {
                totalGamesNum = 1000000;
                // totalGamesNum = 10;
            }
            else
            {
                totalGamesNum = Convert.ToInt32(totalGames);
            }

            Console.Write("Detailed Printout? (not recommended for more than 10 games) (y/n, blank = n): ");
            string detailedPrint = Console.ReadLine();
            if (detailedPrint == "y")
            {
                detail = true;
            }
            else
            {
                detail = false;
            }

            //Start Stopwatch
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start(); //added this nice stopwatch start routine 

            Console.WriteLine("Working...");
            int doubles = 0;
            int double1 = 0;
            int double2 = 0;
            int double3 = 0;
            int gTotalRolls = 0;
            Random randomObject = new Random();
            for (int h = 1; h <= totalGamesNum; h++)
            {
                if (detail) { Console.WriteLine("* NEW GAME # {0} *", h); }
                int boardSpace = 0;
                InitializeChance();
                InitializeComm();

                for (int i = 1; i <= totalRollsNum; i++)
                {
                    int oldSpace = boardSpace;
                    int dieRoll = randomObject.Next(6) + 1;
                    int dieRoll2 = randomObject.Next(6) + 1;
                    int totalRoll = dieRoll + dieRoll2;
                    gTotalRolls++;
                    boardSpace = boardSpace + totalRoll;

                    if (boardSpace > 39) { boardSpace = boardSpace - 40; }
                    if (detail) { Console.WriteLine("your roll was {0} + {1} = {2,2}, OLD ({3,2}) - NEW ({4,2}) {5,2}", dieRoll, dieRoll2, totalRoll, oldSpace, boardSpace, mBoard[boardSpace]); }

                    if (dieRoll == dieRoll2)
                    {
                        doubles++;
                        if (detail) { Console.WriteLine("* ROLLED DOUBLES {0} *", doubles); }
                    }
                    else
                    {
                        doubles = 0;
                    }

                    switch (doubles)
                    {
                        case 1:
                            double1++;
                            break;
                        case 2:
                            double2++;
                            break;
                        case 3:
                            double3++;
                            boardSpace = 10;
                            doubles = 0;
                            if (detail) { Console.WriteLine("**** 3 DOUBLES - JAIL ****"); }
                            break;
                    }

                    if (boardSpace == 7 || boardSpace == 22 || boardSpace == 36) //Chance
                    {
                        NewChance = "";
                        DrawChance();
                        if (detail) { Console.WriteLine("Your Chance Card: {0} ({1} cards left", NewChance, chanceDeck.Length); }
                        if (NewChance == "ATG")
                        {
                            boardSpace = 0;
                            if (detail) { Console.WriteLine("Advance to GO"); }
                        }
                        if (NewChance == "ATI")
                        {
                            boardSpace = 24;
                            if (detail) { Console.WriteLine("Advance to Illinois Ave"); }
                        }
                        if (NewChance == "ATS")
                        {
                            boardSpace = 11;
                            if (detail) { Console.WriteLine("Advance to St. Charles Place"); }
                        }
                        if (NewChance == "B3S")
                        {
                            boardSpace = boardSpace - 3;
                            if (detail) { Console.WriteLine("Go Back 3 Spaces"); }
                        }
                        if (NewChance == "GTJ")
                        {
                            boardSpace = 10;
                            if (detail) { Console.WriteLine("GO TO JAIL"); }
                        }
                        if (NewChance == "ATR")
                        {
                            boardSpace = 5;
                            if (detail) { Console.WriteLine("Advance to Reading Railroad"); }
                        }
                        if (NewChance == "ATB")
                        {
                            boardSpace = 39;
                            if (detail) { Console.WriteLine("Advance to BoardWalk"); }
                        }
                        if (NewChance == "ANU")
                        {
                            if (boardSpace == 22)
                            {
                                boardSpace = 28;
                                if (detail) { Console.WriteLine("Advance to Nearest Utility"); }
                            }
                            else
                            {
                                boardSpace = 12;
                                if (detail) { Console.WriteLine("Advance to Nearest Utility"); }
                            }
                        }
                        if (NewChance == "ANR")
                        {
                            if (boardSpace == 7)
                            {
                                boardSpace = 15;
                                if (detail) { Console.WriteLine("Advance to Nearest Railroad"); }
                            }
                            if (boardSpace == 22)
                            {
                                boardSpace = 25;
                                if (detail) { Console.WriteLine("Advance to Nearest Railroad"); }
                            }
                            if (boardSpace == 33)
                            {
                                boardSpace = 35;
                                if (detail) { Console.WriteLine("Advance to Nearest Railroad"); }
                            }
                        }

                    }

                    if (boardSpace == 2 || boardSpace == 17 || boardSpace == 33) //Community Chest
                    {
                        NewComm = "";
                        DrawComm();
                        if (detail) { Console.WriteLine("Your Community Chest Card: {0} ({1} cards left", NewComm, commDeck.Length); }
                        if (NewComm == "ATG")
                        {
                            boardSpace = 0;
                            if (detail) { Console.WriteLine("Advance to Go"); }
                        }
                        if (NewComm == "GTJ")
                        {
                            boardSpace = 10;
                            if (detail) { Console.WriteLine("GO TO JAIL"); }
                        }
                    }

                    if (boardSpace == 30)
                    {
                        boardSpace = 10;
                        if (detail) { Console.WriteLine("********** MOVED TO JAIL **********"); }
                    }
                    spaceCount[boardSpace]++;
                }
                if (gameCount == gameDisplay - 1)
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine("* GAME # {0:N0} OVER *", h);
                    gameCount = 0;
                }
                else
                {
                    gameCount++;
                }

                if (detail) { Console.WriteLine(""); }
                if (detail) { Console.WriteLine("* GAME # {0:N0} OVER *", h); }
                if (detail) { Console.ReadKey(); }
                if (detail) { Console.WriteLine(""); }
                if (detail) { Console.WriteLine(""); }
                if (detail) { Console.WriteLine(""); }
            }

            for (int t = 0; t <= 39; t++)
            {
                decimal percent = Decimal.Divide(spaceCount[t], gTotalRolls) * 100;
                int graphLength = Convert.ToInt32(percent * 4);
                string graph = new String('*', graphLength);
                fcolor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), mForeColor[t]);
                bcolor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), mBackColor[t]);
                // Console.WriteLine("{0,2}, {1,12:N0} {2,21}  %{3} {4}", t, spaceCount[t], mBoard[t], percent.ToString("n2"), graph);
                Console.Write("{0,2}, {1,12:N0} ", t, spaceCount[t]);
                Console.ForegroundColor = fcolor;
                Console.BackgroundColor = bcolor;
                Console.Write(" {0,21} ", mBoard[t]);
                Console.ResetColor();
                Console.WriteLine(" %{0} {1}", percent.ToString("n2"), graph);
            }
            Console.WriteLine("1 double : {0:#,0}", double1);
            Console.WriteLine("2 doubles: {0:#,0}", double2);
            Console.WriteLine("3 doubles: {0:#,0}", double3);
            Console.WriteLine("Total Rolls: {0:#,0}", gTotalRolls);
            //Stop Startwatch
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine("", ts);
            Console.WriteLine("Calc Time {0}", ts);
            Console.WriteLine("..press any key to exit");
            Console.ReadKey();

        }

        static void InitializeChance()
        {
            string[] wordArray = new string[] { "ATG", "ATI", "ATS", "ANU", "ANR", "---", "---", "B3S", "GTJ", "---", "---", "ATR", "ATB", "---", "---", "---" };
            if (detail) { Console.Write("**** CHANCE "); }
            Shuffle(wordArray);
            chanceDeck = wordArray;
        }

        static void InitializeComm()
        {
            string[] wordArray = new string[] { "ATG", "---", "---", "---", "---", "GTJ", "---", "---", "---", "---", "---", "---", "---", "---", "---", "---", "---", };
            if (detail) { Console.Write("**** COMMUNITY "); }
            Shuffle(wordArray);
            commDeck = wordArray;
        }

        static void DrawChance()
        {
            string[] wordArray = chanceDeck;
            NewChance = wordArray[0];
            string[] tempDeck = new string[wordArray.Length];
            Array.Copy(wordArray, 1, tempDeck, 0, wordArray.Length - 1);
            Array.Resize(ref tempDeck, tempDeck.Length - 1);
            chanceDeck = tempDeck;
            if (chanceDeck.Length == 0)
            {
                InitializeChance();
            }
        }

        static void DrawComm()
        {
            string[] wordArray = commDeck;
            NewComm = wordArray[0];
            string[] tempDeck = new string[wordArray.Length];
            Array.Copy(wordArray, 1, tempDeck, 0, wordArray.Length - 1);
            Array.Resize(ref tempDeck, tempDeck.Length - 1);
            commDeck = tempDeck;
            if (commDeck.Length == 0)
            {
                InitializeComm();
            }
        }

        static string[] Shuffle(string[] wordArray)
        {
            for (int i = wordArray.Length - 1; i > 0; i--)
            {
                int swapIndex = random.Next(i + 1);
                string temp = wordArray[i];
                wordArray[i] = wordArray[swapIndex];
                wordArray[swapIndex] = temp;
            }
            if (detail) { Console.WriteLine("SHUFFLED ****"); }
            return wordArray;
        }

        static string[] DisplayDeck(string[] wordArray)
        {
            Console.Write("Current Deck: ");
            for (int c = 1; c <= wordArray.Length; c++)
            {
                Console.Write("{0} ", wordArray[c - 1]);
            }
            Console.WriteLine("");
            return wordArray;
        }

    }
}
