using System.Collections.Generic;

namespace Tetris.Models;

public class IShapeBlockFactory : BlockFactory
{
    public override Block CreateBlock()
    {
        List<int[]> blockCoordinates = new List<int[]>();
        blockCoordinates.Add(new int[] {0, 4});
        blockCoordinates.Add(new int[] {0, 5});
        blockCoordinates.Add(new int[] {0, 6});
        blockCoordinates.Add(new int[] {0, 7});
        return new Block(blockCoordinates, BlockEnum.IShape);
    }
}