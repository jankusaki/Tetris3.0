using System;
using System.Threading;
using System.Windows.Input;
using Tetris;

namespace Tetris.Models;

public static class PlayerController
{
    public static Block block;

    public static void HandleInput(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Left:
                MoveBlockIfPossible(block.CanMoveLeft, block.MoveLeft);
                break;

            case Key.Right:
                MoveBlockIfPossible(block.CanMoveRight, block.MoveRight);
                break;

            case Key.Down:
                MoveBlockIfPossible(block.CanMoveDown, block.MoveDown);
                break;
            case Key.Up:
                MoveBlockIfPossible(block.CanRotate, block.Rotate);
                break;
            default:
                return;
        }
        Game.UpdateBoard(block);
        Game.PrintBoard();
    }
    
    private static void MoveBlockIfPossible(Func<bool> canMove, Action moveAction)
    {
        if (canMove())
        {
            Game.ClearOldCoordinates(block);
            moveAction();
            Game.UpdateBoard(block);
            Game.PrintBoard();
        }
    }
}