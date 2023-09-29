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
        public MainWindow()
        {
            InitializeComponent();
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
                        Fill = Brushes.Black
                    };
                    Grid.SetRow(rectangle, i);
                    Grid.SetColumn(rectangle, j);
                    //aksljdflkajsdf
                    GameGrid.Children.Add(rectangle);
                }
            }

        }
        public void StartGame(object sender, RoutedEventArgs e)
        {
            Models.Game game = new Models.Game();
            game.Start();

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
