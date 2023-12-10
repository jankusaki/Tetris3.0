using System.Collections.Generic;

namespace Tetris.Models;

public class ZShapeBlockFactory : BlockFactory
{
    public override Block CreateBlock()
    {
        List<int[]> blockCoordinates = new List<int[]>();
        blockCoordinates.Add(new int[] {0, 4});
        blockCoordinates.Add(new int[] {0, 5});
        blockCoordinates.Add(new int[] {1, 5});
        blockCoordinates.Add(new int[] {1, 6});
        return new Block(blockCoordinates, BlockEnum.ZShape);
    }
}