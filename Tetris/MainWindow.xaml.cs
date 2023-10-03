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

    public enum Tetromino
    {
        IShape = 1,
        OShape = 2,
        TShape = 3,
        JShape = 4,
        LShape = 5,
        SShape = 6,
        ZShape = 7
    }
    public partial class MainWindow : Window
    {
<<<<<<< HEAD
        Game game;
        BlockSpawner blockSpawner;
        public MainWindow()
        {
            game = new Game();
            blockSpawner = new BlockSpawner();
=======
        Models.Game game;
        public MainWindow()
        {

>>>>>>> 3a3904a156186daf541cd3ff37cca32f81855e5d
            InitializeComponent();
            game = new Models.Game(20, 10);
            DrawGameGrid();
            GameLoop();
        }
        public async void GameLoop()
        {
            
            while (game.GetCurrentHeight() < 20)
            {
                blockSpawner.SpawnTetromino(game);
                while (!game.IsReachedBottom())
                {
                    game.TransformCurrentCoordinates();
                    await Task.Delay(50);
                    DrawGameGrid();
                }
            }
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
<<<<<<< HEAD
        {
            int[,] gameGrid = game.GetGameGrid();
            switch (gameGrid[i, j])
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
=======
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

>>>>>>> 3a3904a156186daf541cd3ff37cca32f81855e5d
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
