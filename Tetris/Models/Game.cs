using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tetris.Models
{
    public enum BlockType
    {
<<<<<<< HEAD
        int[,] gameGrid;
        const int rows = 20;
        const int cols = 10;
        List<int[]> currentCoordinates;
=======
        IShape,
        JShape,
        LShape,
        OShape,
        SShape,
        ZShape,
        TShape
    }

    public class Game
    {

        const int spawnHeight = 0;

        List<int[]> currentCoordinates;

        public int currentHeight;
        public int score;
        public int[,] gameBoard;
        public Game(int rows, int columns)
        {
            currentCoordinates = new List<int[]>();
            score = 0;
            currentHeight = 0;
            gameBoard = new int[rows + spawnHeight, columns];
            for (int i = 0; i < rows + spawnHeight; i++) 
            {
                for (int j = 0; j < columns; j++)
                {
                    gameBoard[i,j] = 8;
                }
            }

        }

        public void GameLoop()
        {
            SpawnBlock();

            while (!IsBoardFull())
            {

            }
        }

        public void ChangeCurrentCoordinates(BlockType blockType)
        {
>>>>>>> 3a3904a156186daf541cd3ff37cca32f81855e5d

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
        public void UpdateGameGrid(BlockType blockType)
        {
            foreach (var coord in currentCoordinates)
            {
                gameBoard[coord[0], coord[1]] = (int)blockType;
            }

        }
        public void SpawnBlock()
        {
            currentCoordinates.Clear();
            Random r = new Random();
            Array values = Enum.GetValues(typeof(BlockType));
            BlockType newBlock = (BlockType) values.GetValue(r.Next(values.Length));
            
            switch((int)newBlock)
            {
                case 0:
                    currentCoordinates.Add(new int[2] { 0, 3 });
                    currentCoordinates.Add(new int[2] { 0, 4 });
                    currentCoordinates.Add(new int[2] { 0, 5 });
                    currentCoordinates.Add(new int[2] { 0, 6 });

                    break;
                case 1:
                    break;
                default:
                    break;

            }
            UpdateGameGrid(newBlock);
        }
        public bool IsBoardFull()
        {
            if (currentHeight <= gameBoard.Length - spawnHeight)
            {
                return false;
            } 
            else
            {
                return true;
            }

        }

        public int GetGameBoardUnit(int x, int y)
        {
            return gameBoard[x + spawnHeight, y];
        }

    }
}
