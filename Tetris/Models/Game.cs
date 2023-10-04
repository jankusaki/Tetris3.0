using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models
{
    internal class Game
    {
        int[,] gameGrid;
        const int rows = 20;
        const int cols = 10;
        List<int[]> currentCoordinates;

        public Game()
        {
            gameGrid = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameGrid[i, j] = 0;
                }
            }
            currentCoordinates = new List<int[]>();
        }
        public int GetCurrentHeight()
        {
            int currentHeight = 0;
            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (gameGrid[i, j] != 0)
                    {
                        currentHeight++;
                        break;
                    }
                }
            }
            return currentHeight;
        }
        public bool IsReachedBottom()
        {
            foreach (var x in currentCoordinates)
            {
                if (x[0] + 1 < 20 && gameGrid[x[0] + 1, x[1]] == 0)
                {
                    return false;
                }
            }
            currentCoordinates.Clear();
            return true;

        }
        public void TransformCurrentCoordinates()
        {
            for (var i = 0; i < currentCoordinates.Count; i++)
            {
                gameGrid[currentCoordinates[i][0] + 1, currentCoordinates[i][1]] = gameGrid[currentCoordinates[i][0], currentCoordinates[i][1]];
                gameGrid[currentCoordinates[i][0], currentCoordinates[i][1]] = 0;
                currentCoordinates[i][0]++;
            }




        }
        public void SpawnBlock(Tetromino shape)
        {
            gameGrid[0, 3] = (int)shape;
            gameGrid[0, 4] = (int)shape;
            gameGrid[0, 5] = (int)shape;
            gameGrid[0, 6] = (int)shape;

            currentCoordinates.Add(new int[2] { 0, 3 });
            currentCoordinates.Add(new int[2] { 0, 4 });
            currentCoordinates.Add(new int[2] { 0, 5 });
            currentCoordinates.Add(new int[2] { 0, 6 });
        }
        public int[,] GetGameGrid()
        {
            return gameGrid;
        }
    }
}
