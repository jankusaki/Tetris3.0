using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Tetris.Models;

public static class GameController
{
    public static bool GameOver;
    public static MainWindow window;
    public static void GameLoop(MainWindow mainWindow)
    {
        window = mainWindow;
        Game.PrintBoard();
        do
        {
            Block block = BlockGenerator.GenerateRandomBlock();
            Game.UpdateBoard(block);
            Game.PrintBoard();
            PlayerController.block = block;
            
            Thread.Sleep(1500);
            while (block.CanMoveDown())
            {
                Game.ClearOldCoordinates(block);
                block.MoveDown();
                Game.UpdateBoard(block);
                Game.PrintBoard();
                Thread.Sleep(1500);
            }
            if (Game.IsGameOver()) GameOver = true;
            Game.ClearRows();
        } while (!GameOver);
        Game.PrintBoard();
        window.Dispatcher.Invoke(() =>
            window.ShowGameOverScreen());

    }

    public static void UpdateUI()
    {
        window.Dispatcher.Invoke(() => 
            window.DrawGameGrid()
        );
    }
}