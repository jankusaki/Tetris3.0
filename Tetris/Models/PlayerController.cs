using System;
using System.Threading;
using System.Windows.Input;
using Tetris;
using Tetris.Command;

namespace Tetris.Models;

public static class PlayerController
{
    public static Block block;

    public static void HandleInput(object sender, KeyEventArgs e)
    {
        Command.Command? command;
        switch (e.Key)
        {
            case Key.Left:
                command = new MoveBlockLeftCommand(block);
                break;
            case Key.Right:
                command = new MoveBlockRightCommand(block);
                break;
            case Key.Down:
                command = new MoveBlockDownCommand(block);
                break;
            case Key.Up:
                command = new RotateBlockCommand(block);
                break;
            default:
                return;
        }
        command.Execute();
    }
    
}