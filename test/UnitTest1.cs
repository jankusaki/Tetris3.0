using System.Diagnostics;
using System.Reflection;
using Tetris.Models;
using static Tetris.Models.GameController;

namespace test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CheckIfGeneratesAllBlocksAndDoesNotThrow()
    {
        var subclassTypes = Assembly
            .GetAssembly(typeof(BlockFactory))!
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(BlockFactory)));
        
        var generatedBlockFactoryTypes = new List<Type>();
        for (int i = 0; i < 1000; i++)
        {
            BlockFactory? result = null;
            Assert.DoesNotThrow(() => result = ChooseRandomBlockFactory());
            Assert.IsTrue(subclassTypes.Contains(result.GetType()));
            if (!generatedBlockFactoryTypes.Contains(result.GetType()))
                generatedBlockFactoryTypes.Add(result.GetType());
        }
        Assert.That(generatedBlockFactoryTypes.Count(), Is.EqualTo(subclassTypes.Count()));
    }
    
    [Test]
    public void TestIsGameOverWhenGridIsFull()
    {
        Game.GameGrid = Enumerable.Range(0, Game.BoardHeight)
            .Select(_ => Enumerable.Repeat(0, Game.BoardWidth).ToArray())
            .ToArray();
        for (int i = 0; i < Game.BoardWidth; i++)
        {
            Game.GameGrid[0][i] = (int)BlockEnum.IShape;
        }

        Assert.IsTrue(Game.IsGameOver());
    }
    
    [Test]
    public void TestIsGameOverWhenGridIsEmpty()
    {
        Game.GameGrid = Enumerable.Range(0, Game.BoardHeight)
            .Select(_ => Enumerable.Repeat(0, Game.BoardWidth).ToArray())
            .ToArray();

        Assert.IsFalse(Game.IsGameOver());
    }

    [Test]
    public void TestCanBlockMoveWhenItsAtLeftEdgeOfGrid()
    {
        BlockFactory blockFactory = new IShapeBlockFactory();
        Block block = blockFactory.CreateBlock();
        block.BlockCoordinates = new List<int[]>()
        {
            new int[] {0, 0},
            new int[] {0, 1},
            new int[] {0, 2},
            new int[] {0, 3},
        };
        
        Assert.IsFalse(block.CanMoveLeft());
    }
    
    [Test]
    public void TestCanBlockMoveWhenItsAtRightEdgeOfGrid()
    {
        BlockFactory blockFactory = new IShapeBlockFactory();
        Block block = blockFactory.CreateBlock();
        block.BlockCoordinates = new List<int[]>()
        {
            new int[] {0, Game.BoardWidth - 1},
            new int[] {1, Game.BoardWidth - 1},
            new int[] {2, Game.BoardWidth - 1},
            new int[] {3, Game.BoardWidth - 1},
        };
        
        Assert.IsFalse(block.CanMoveRight());
    }
    
    [Test]
    public void TestCanBlockMoveWhenItsAtBottomEdgeOfGrid()
    {
        BlockFactory blockFactory = new IShapeBlockFactory();
        Block block = blockFactory.CreateBlock();
        block.BlockCoordinates = new List<int[]>()
        {
            new int[] {Game.BoardHeight - 1, 0},
            new int[] {Game.BoardHeight - 1, 1},
            new int[] {Game.BoardHeight - 1, 2},
            new int[] {Game.BoardHeight - 1, 3},
        };
        
        Assert.IsFalse(block.CanMoveDown());
    }
}