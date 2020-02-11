using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToe.Common;

namespace TicTacToe.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;
        private IBot _bot;

        public MainWindow()
        {
            this._bot = new MinMaxBot();
            this._game = new Game();

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            try
            {
                this._game.Mark(row, column);
                button.Content = "X";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (this._game.IsOver)
            {
                if (this._game.IsXWin)
                {
                    MessageBox.Show("You won!");
                }
                else
                {
                    MessageBox.Show("You tied!");
                }
            }
            else
            {
                Tuple<int, int> move = this._bot.GetMove(this._game.Copy());

                this._game.Mark(move.Item1, move.Item2);

                Button oButton = this._squaresGrid.Children
                  .Cast<UIElement>()
                  .First(item => Grid.GetRow(item) == move.Item1 && Grid.GetColumn(item) == move.Item2) as Button;
                oButton.Content = "O";

                if (this._game.IsOWin)
                {
                    MessageBox.Show("You lost!");
                }

            }
        }
    }
}
