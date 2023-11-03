using System;
using System.Collections.Generic;

namespace Tetris.Models;

public class Block
{
    private List<int[]> blockCoordinates;
    private BlockEnumeration blockType;

    public Block(List<int[]> blockCoordinates, BlockEnumeration blockType)
    {
        this.blockCoordinates = blockCoordinates;
        this.blockType = blockType;
    }

    public List<int[]> BlockCoordinates
    {
        get => blockCoordinates;
        set => blockCoordinates = value;
    }

    public BlockEnumeration BlockType
    {
        get => blockType;
    }

    public void MoveDown()
    {
        foreach (int[] coord in blockCoordinates) 
        {
            coord[0]++;
        }
    }

    public void MoveLeft()
    {
        foreach (int[] coord in blockCoordinates) 
        {
            coord[1]--;
        }
    }
    public void MoveRight()
    {
        foreach (int[] coord in blockCoordinates) 
        {
            coord[1]++;
        }
    }
    public bool CanMoveLeft()
    {
        foreach (var coord in blockCoordinates)
        {
            int newY = coord[0];
            int newX = coord[1]-1;
            
            if (newX < 0) return false;
            if (IsCoordinateInList(newX, newY)) continue;

            if (Game.GameGrid[newY][newX] != 0)
            {
                return false;
            }
        }

        return true;
    }
    public bool CanMoveRight()
    {
        foreach (var coord in blockCoordinates)
        {
            int newY = coord[0];
            int newX = coord[1]+1;
            
            if (newX > 9) return false;
            if (IsCoordinateInList(newX, newY)) continue;

            if (Game.GameGrid[newY][newX] != 0)
            {
                return false;
            }
        }

        return true;
    }
    public bool CanMoveDown()
    {
        foreach (var coord in blockCoordinates)
        {
            int newY = coord[0] + 1;
            int newX = coord[1];
            
            if (newY > 19) return false;
            if (IsCoordinateInList(newX, newY)) continue;

            if (Game.GameGrid[newY][newX] != 0)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsCoordinateInList(int newX, int newY)
    {
        foreach (var coordinate in blockCoordinates)
        {
            if (coordinate[0] == newY && coordinate[1] == newX) return true;
        }

        return false;
    }

    public void Rotate()
    {
        int maxRow = -1;
        int minRow = 20;
        int maxCol = -1;
        int minCol = 10;
        foreach (var coord in BlockCoordinates)
        {
            if (coord[0] > maxRow) maxRow = coord[0];
            if (coord[0] < minRow) minRow = coord[0];
            if (coord[1] > maxCol) maxCol = coord[1];
            if (coord[1] < minCol) minCol = coord[1];
        }

        int length = int.Max((maxRow-minRow),(maxCol-minCol))+1;
        
        int[][] matrix = new int[length][];
        for (int i = 0; i < length; i++)
        {
            matrix[i] = new int[length];
        }

        foreach (var coord in BlockCoordinates)
        {
            matrix[coord[0]-minRow][coord[1]-minCol] = 1;
        }

        for (int i = 0; i < length; i++)
        {
            for (int j = i; j < length; j++)
            {
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
            }
        }

        for (int i = 0; i < length; i++)
        {
            Array.Reverse(matrix[i]);
        }

        blockCoordinates.Clear();
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (matrix[i][j] != 0) blockCoordinates.Add(new[]{i+minRow, j+minCol});
            }
        }



    }
    public bool CanRotate()
    {
        int maxRow = -1;
        int minRow = 20;
        int maxCol = -1;
        int minCol = 10;
        foreach (var coord in BlockCoordinates)
        {
            if (coord[0] > maxRow) maxRow = coord[0];
            if (coord[0] < minRow) minRow = coord[0];
            if (coord[1] > maxCol) maxCol = coord[1];
            if (coord[1] < minCol) minCol = coord[1];
        }

  

        int length = int.Max((maxRow-minRow),(maxCol-minCol));
        if (length + minRow > 19 || length + minCol > 9) return false;
        for (int i = minRow; i <= minRow+length; i++)
        {
            for (int j = minCol; j <= minCol+length; j++)
            {
                if (Game.GameGrid[i][j] != 0 && !IsCoordinateInList(j, i)) return false;
            }
        }

        return true;
    }
}