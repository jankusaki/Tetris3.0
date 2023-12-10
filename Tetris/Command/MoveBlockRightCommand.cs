using Tetris.Models;

namespace Tetris.Command;

public class MoveBlockRightCommand : Command
{
    private readonly Block _block;
    public MoveBlockRightCommand(Block block)
    {
        _block = block;
    }
    public override void Execute()
    {
        if (_block.CanMoveRight())
        {
            Game.ClearOldCoordinates(_block);
            _block.MoveRight();
            Game.UpdateBoard(_block);
            Game.PrintBoard();
        }
    }
    
}