using System;
using System.Linq;
using System.Reflection;
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
            BlockFactory blockFactory = ChooseRandomBlockFactory();
            Block block = blockFactory.CreateBlock();
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

    }

    public static BlockFactory ChooseRandomBlockFactory()
    {   
        Random random = new Random();
        int numberOfBlockFactoryTypes = Assembly
            .GetAssembly(typeof(BlockFactory))!
            .GetTypes().Count(t => t.IsSubclassOf(typeof(BlockFactory)));
        
        int randomNumber = random.Next(0, numberOfBlockFactoryTypes);
        switch (randomNumber)
        {
            case 0: return new IShapeBlockFactory();
            case 1: return new JShapeBlockFactory();
            case 2: return new LShapeBlockFactory();
            case 3: return new OShapeBlockFactory();
            case 4: return new SShapeBlockFactory();
            case 5: return new TShapeBlockFactory();
            case 6: return new ZShapeBlockFactory();
            default: throw new Exception("Invalid random number");
        }
    }
    public static void UpdateUI()
    {
        window.Dispatcher.Invoke(() => 
            window.DrawGameGrid()
        );
    }

    public static void PauseGame()
    {
    }
}