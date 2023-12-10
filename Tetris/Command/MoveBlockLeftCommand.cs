using Tetris.Models;

namespace Tetris.Command;

public class MoveBlockLeftCommand : Command
{
    private readonly Block _block;
    public MoveBlockLeftCommand(Block block)
    {
        _block = block;
    }
    public override void Execute()
    {
        if (_block.CanMoveLeft())
        {
            Game.ClearOldCoordinates(_block);
            _block.MoveLeft();
            Game.UpdateBoard(_block);
            Game.PrintBoard();
        }
    }
    
}