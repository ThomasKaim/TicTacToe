using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Common
{
    public class HumanBot : IBot
    {
        public string Name => "Human";

        public string Description => "Human controlled";

        public Tuple<int, int> GetMove(Game game)
        {
            Console.WriteLine($"{this.Name} turn ({(game.IsXTurn ? 'X' : 'O')}):");

            while (true)
            {
                try
                {
                    // Get input from user.
                    string[] parts = Console.ReadLine().Split(' ');
                    int row = int.Parse(parts[0]);
                    int column = int.Parse(parts[1]);

                    // Try to mark our copy of the board to confirm it's a valid move.
                    game.Mark(row, column);

                    // If we got here (no exceptions), return the move.
                    return Tuple.Create(row, column);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Bad move: {e.Message}");
                }
            }
        }
    }
}
