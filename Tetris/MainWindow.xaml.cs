using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using Tetris.Models;

namespace Tetris
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += HandleKeyPressEvent;
            Task.Run(() => GameController.GameLoop(this));
        }
        public void DrawGameGrid()
        {
            GameGrid.Children.Clear();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Rectangle rectangle = new Rectangle
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

        public void ShowGameOverScreen()
        {
            ShowDialog();
        }
        public Brush GetStrokeColor(int i, int j)
        {
            int[][] gameGrid = Game.GameGrid;
            switch (gameGrid[i][j])
            {
                case 1: return Brushes.Cyan;
                case 2: return Brushes.Yellow;
                case 3: return Brushes.Purple;
                case 4: return Brushes.Blue;
                case 5: return Brushes.Orange;
                case 6: return Brushes.Green;
                case 7: return Brushes.Red;
                default: return Brushes.Black;
            }
        }

        public void ShowControls(object sender, RoutedEventArgs e)
        {

        }
        public void ExitApplication(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void HandleKeyPressEvent(object sender, KeyEventArgs e)
        {
            PlayerController.HandleInput(sender, e);
        }
    }
}
