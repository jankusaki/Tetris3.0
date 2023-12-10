using System.Collections.Generic;

namespace Tetris.Models;

public class SShapeBlockFactory : BlockFactory
{
    public override Block CreateBlock()
    {
        List<int[]> blockCoordinates = new List<int[]>();
        blockCoordinates.Add(new int[] {0, 4});
        blockCoordinates.Add(new int[] {0, 5});
        blockCoordinates.Add(new int[] {1, 3});
        blockCoordinates.Add(new int[] {1, 4});
        return new Block(blockCoordinates, BlockEnum.SShape);
    }
}