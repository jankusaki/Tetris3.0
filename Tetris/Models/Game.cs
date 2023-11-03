using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Tetris;

namespace Tetris.Models;

public static class Game
{
    public const int BoardHeight = 20;
    public const int BoardWidth = 10;

    public static int[][] GameGrid = Enumerable.Range(0, BoardHeight)
        .Select(_ => Enumerable.Repeat(0, BoardWidth).ToArray())
        .ToArray();


    public static void PrintBoard()
    {
        GameController.UpdateUI();
    }

    public static void UpdateBoard(Block currentBlock)
    {
        foreach (var coord in currentBlock.BlockCoordinates)
        {
            GameGrid[coord[0]][coord[1]] = (int)currentBlock.BlockType;
        }
    }

    public static void ClearRows()
    {
        List<int> fullRows = GetFullRows();
        if (fullRows.Count == 0) return;
        ClearFullRows(fullRows);
        MoveDownRows(fullRows);
    }

    private static void MoveDownRows(List<int> fullRows)
    {
        fullRows.Sort((a, b) => b.CompareTo(a));
        for (int i = fullRows.First(); i >= 0; i--)
        {
            if (i - fullRows.Count < 0) GameGrid[i] = new int[BoardWidth];
            else GameGrid[i] = GameGrid[i - fullRows.Count];
        }
    }


    public static void ClearFullRows(List<int> fullRows)
    {
        foreach (int row in fullRows)
        {
            for (int col = 0; col < BoardWidth; col++)
            {
                GameGrid[row][col] = 0;
            }
        }
    }

    public static List<int> GetFullRows()
    {
        List<int> fullRows = new List<int>();
        for (int i = 0; i < BoardHeight; i++)
        {
            if (IsRowFull(i)) fullRows.Add(i);
        }

        return fullRows;
    }

    public static bool IsRowFull(int row)
    {
        for (int i = 0; i < BoardWidth; i++)
        {
            if (GameGrid[row][i] == 0) return false;
        }

        return true;
    }

    public static void ClearOldCoordinates(Block currentBlock)
    {
        foreach (var coord in currentBlock.BlockCoordinates)
        {
            GameGrid[coord[0]][coord[1]] = 0;
        }
    }

    public static bool IsGameOver()
    {
        foreach (int e in GameGrid[0])
        {
            if (e != 0) return true;
        }

        return false;
    }
}