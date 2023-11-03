using System;
using System.Collections.Generic;

namespace Tetris.Models;

static class BlockGenerator
{
    public static Block GenerateRandomBlock()
    {
        BlockEnumeration blockEnumeration = GetRandomBlockEnumeration();
        List<int[]> coordinates;
        
        switch (blockEnumeration)
        {
            case BlockEnumeration.IShape: coordinates = GetCoordinatesOfIShape();
                break;
            case BlockEnumeration.OShape: coordinates = GetCoordinatesOfOShape();
                break;
            case BlockEnumeration.TShape: coordinates = GetCoordinatesOfTShape();
                break;
            case BlockEnumeration.JShape: coordinates = GetCoordinatesOfJShape();
                break;
            case BlockEnumeration.LShape: coordinates = GetCoordinatesOfLShape();
                break;
            case BlockEnumeration.SShape: coordinates = GetCoordinatesOfSShape();
                break;
            case BlockEnumeration.ZShape: coordinates = GetCoordinatesOfZShape();
                break;
            default: return null;
        }

        return new Block(coordinates,blockEnumeration);
        
    }

    static BlockEnumeration GetRandomBlockEnumeration()
    {
        Random random = new Random();
        return (BlockEnumeration)random.Next(1, Enum.GetValues(typeof(BlockEnumeration)).Length-1);
    }

    static List<int[]> GetCoordinatesOfIShape()
    {
        var blockCoordinates = new List<int[]>
        {
            new[] { 0, 3 },
            new[] { 0, 4 },
            new[] { 0, 5 },
            new[] { 0, 6 }
        };

        return blockCoordinates;
    }

    private static List<int[]> GetCoordinatesOfOShape()
    {
        var blockCoordinates = new List<int[]>
        {
            new[] { 0, 4 },
            new[] { 0, 5 },
            new[] { 1, 4 },
            new[] { 1, 5 }
        };

        return blockCoordinates;
    }

    private static List<int[]> GetCoordinatesOfTShape()
    {
        var blockCoordinates = new List<int[]>
        {
            new[] { 0, 4 },
            new[] { 1, 3 },
            new[] { 1, 4 },
            new[] { 1, 5 }
        };

        return blockCoordinates;
    }

    private static List<int[]> GetCoordinatesOfJShape()
    {
        var blockCoordinates = new List<int[]>
        {
            new[] { 0, 3 },
            new[] { 1, 3 },
            new[] { 1, 4 },
            new[] { 1, 5 }
        };

        return blockCoordinates;
    }

    private static List<int[]> GetCoordinatesOfLShape()
    {
        var blockCoordinates = new List<int[]>
        {
            new[] { 0, 5 },
            new[] { 1, 3 },
            new[] { 1, 4 },
            new[] { 1, 5 }
        };

        return blockCoordinates;
    }

    private static List<int[]> GetCoordinatesOfSShape()
    {
        var blockCoordinates = new List<int[]>
        {
            new[] { 1, 3 },
            new[] { 1, 4 },
            new[] { 0, 4 },
            new[] { 0, 5 }
        };

        return blockCoordinates;
    }

    private static List<int[]> GetCoordinatesOfZShape()
    {
        var blockCoordinates = new List<int[]>
        {
            new[] { 0, 3 },
            new[] { 0, 4 },
            new[] { 1, 4 },
            new[] { 1, 5 }
        };

        return blockCoordinates;
    }
}