using System.Collections.Generic;

namespace Tetris.Models;

public class LShapeBlockFactory : BlockFactory
{
    public override Block CreateBlock()
    {
        List<int[]> blockCoordinates = new List<int[]>();
        blockCoordinates.Add(new int[] {0, 4});
        blockCoordinates.Add(new int[] {1, 4});
        blockCoordinates.Add(new int[] {2, 4});
        blockCoordinates.Add(new int[] {2, 5});
        return new Block(blockCoordinates, BlockEnum.LShape);
    }
    
}