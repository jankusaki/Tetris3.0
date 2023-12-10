using Tetris.Models;

namespace Tetris.Command;

public class RotateBlockCommand : Command
{
    private readonly Block _block;
    public RotateBlockCommand(Block block)
    {
        _block = block;
    }
    public override void Execute()
    {
        if (_block.CanRotate())
        {
            Game.ClearOldCoordinates(_block);
            _block.Rotate();
            Game.UpdateBoard(_block);
            Game.PrintBoard();
        }
    }
    
}