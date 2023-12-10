using Tetris.Models;

namespace Tetris.Command;

public class MoveBlockDownCommand : Command
{
    private readonly Block _block;
    public MoveBlockDownCommand(Block block)
    {
        _block = block;
    }
    public override void Execute()
    {
        if (_block.CanMoveDown())
        {
            Game.ClearOldCoordinates(_block);
            _block.MoveDown();
            Game.UpdateBoard(_block);
            Game.PrintBoard();
        }
    }
}