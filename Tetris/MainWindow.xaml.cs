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

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Models.Game game;
        public MainWindow()
        {

            InitializeComponent();
            game = new Models.Game(20, 10);
            DrawGameGrid();
        }
        public void DrawGameGrid()
        {

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    
                    
                    Rectangle rectangle = new Rectangle()
                    {
                        Stroke = Brushes.White,
                        StrokeThickness = 1,
                        Fill = GetStrokeColor(i, j)
                    };
                    Grid.SetRow(rectangle, i);
                    Grid.SetColumn(rectangle, j);
                    GameGrid.Children.Add(rectangle);
                }
            }

        }
        public Brush GetStrokeColor(int i, int j)
        {
            switch (game.GetGameBoardUnit(i, j))
            {
                case 0: return Brushes.Cyan;
                case 1: return Brushes.Blue;
                case 2: return Brushes.Orange;
                case 3: return Brushes.Yellow;
                case 4: return Brushes.Green;
                case 5: return Brushes.Red;
                case 6: return Brushes.Purple;
                default: return Brushes.Black;
            }
        }
        public void StartGame(object sender, RoutedEventArgs e)
        {
            game.SpawnBlock();
            DrawGameGrid();

        }
        public void ShowControls(object sender, RoutedEventArgs e)
        {

        }
        public void ExitApplication(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
