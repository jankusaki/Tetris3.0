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
                case (int) BlockEnum.IShape: return Brushes.Cyan;
                case (int) BlockEnum.JShape: return Brushes.Blue;
                case (int) BlockEnum.LShape: return Brushes.Orange;
                case (int) BlockEnum.OShape: return Brushes.Yellow;
                case (int) BlockEnum.SShape: return Brushes.Green;
                case (int) BlockEnum.TShape: return Brushes.Purple;
                case (int) BlockEnum.ZShape: return Brushes.Red;
                default: return Brushes.Black;
            }
        }
        public void ExitApplication(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void HandleKeyPressEvent(object sender, KeyEventArgs e)
        {
            PlayerController.HandleInput(sender, e);
        }

        private void PauseGame(object sender, RoutedEventArgs e)
        {
            GameController.PauseGame();
        }
    }
}
