using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Common;

namespace TicTacToe.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
@"Choose bots to play with. 
-""Human Bot"" to play.
-""Min Max Bot"" to play a good robot
-""Cheat Bot"" to crash the game in 2 turns.
-""First Bot"" to play a bot who chooses the first open square.
-""Random Bot"" to fight a random bot.");
            IBot xBot = null;
            Game game = new Game();
            IBot oBot = null;
            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "Human Bot":
                        xBot = new HumanBot();
                        break;
                    case "Cheat Bot":
                        xBot = new CheatBot();
                        break;
                    case "Min Max Bot":
                        xBot = new MinMaxBot();
                        break;
                    case "First Bot":
                        xBot = new FirstBot();
                        break;
                    case "Random Bot":
                        xBot = new RandomBot();
                        break;
                    default:
                        Console.WriteLine("Please pick a type of bot");
                        break;
                }
            } while (xBot == null);
            Console.WriteLine("Now choose the other player.");
            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "Human Bot":
                        oBot = new HumanBot();
                        break;
                    case "Cheat Bot":
                        oBot = new CheatBot();
                        break;
                    case "Min Max Bot":
                        oBot = new MinMaxBot();
                        break;
                    case "First Bot":
                        oBot = new FirstBot();
                        break;
                    case "Random Bot":
                        oBot = new RandomBot();
                        break;
                    default:
                        Console.WriteLine("Please pick a type of bot");
                        break;
                }
            } while (oBot == null);



            Console.WriteLine($"{xBot.Name} (X) vs. {oBot.Name} (O)");

            while (!game.IsOver)
            {
                // Make a copy of the game and give it to the bot. This allows the bot to do
                // whatever it wants to the copy without messing up our official game.
                Game botGame = game.Copy();

                IBot bot = game.IsXTurn ? xBot : oBot;
                Tuple<int, int> move = bot.GetMove(botGame);
                game.Mark(move.Item1, move.Item2);

                Console.WriteLine($"{bot.Name} selected ({move.Item1}, {move.Item2})");

                Console.WriteLine(game.Board.ToString());
            }

            if (game.IsXWin)
            {
                Console.WriteLine($"{xBot.Name} wins!");
            }
            else if (game.IsOWin)
            {
                Console.WriteLine($"{oBot.Name} wins!");
            }
            else if (game.IsTie)
            {
                Console.WriteLine($"Game is a tie!");
            }
            else
            {
                Console.WriteLine("How did we get here?");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
