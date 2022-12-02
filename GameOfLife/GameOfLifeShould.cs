using NUnit.Framework;

public class GameOfLifeShould
{
    private GameOfLife game;

    [SetUp]
    public void Setup()
    {
        game = new GameOfLife();
    }

    [Test]
    public void Nothing()
    {
        var input =
            "...\n" +
            "...\n" +
            "...\n";

        string output = game.Process(input);

        Assert.AreEqual(input, output);
    }

    [Test]
    public void AcceptInputSize()
    {
        var input =
            "3 3\n" +
            "...\n" +
            "...\n" +
            "...\n";

        var expectedOutput =
            "...\n" +
            "...\n" +
            "...\n";

        string output = game.Process(input);

        Assert.AreEqual(expectedOutput, output);
    }

    
    [Test]
    public void ApplyNextGeneration_DeadCellsBecameAlive()
    {
        var input =
            "**.\n" +
            "*..\n" +
            "...\n";
    
        var expectedOutput =
            "**.\n" +
            "**.\n" +
            "...\n";
    
        string output = game.Process(input);
    
        Assert.AreEqual(expectedOutput, output);
    }
    
    [Test]
    public void ApplyNextGeneration_AliveCellsWithLessThanTwoAliveNeighboursDies()
    {
        var input =
            "...\n" +
            ".*.\n" +
            "...\n";
    
        var expectedOutput =
            "...\n" +
            "...\n" +
            "...\n";
    
        string output = game.Process(input);
    
        Assert.AreEqual(expectedOutput, output);
    }
    
    [Test]
    public void ApplyNextGeneration_AliveCellsWithMoreThanThreeNeighboursDies()
    {
        var input =
            ".*.\n" +
            "***\n" +
            ".*.\n";
    
        var expectedOutput =
            "***\n" +
            "*.*\n" +
            "***\n";
    
        string output = game.Process(input);
    
        Assert.AreEqual(expectedOutput, output);
    }
    
    [Test]
    public void ApplyNextGeneration_AnyLiveCellWithTwoOrThreeLiveNeighboursLIVES()
    {
        var input =
            ".*.\n" +
            "***\n" +
            ".*.\n";
    
        var expectedOutput =
            "***\n" +
            "*.*\n" +
            "***\n";
    
        string output = game.Process(input);
    
        Assert.AreEqual(expectedOutput, output);
    }
}
