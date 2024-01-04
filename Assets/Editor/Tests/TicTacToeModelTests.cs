using NUnit.Framework;

public class TicTacToeModelTests
{
    private TicTacToeModel model;

    [SetUp]
    public void Setup()
    {
        model = new TicTacToeModel();
    }

    [Test]
    public void Should_Return_True_For_A_Valid_Move()
    {
        bool result = model.MakeMove(0, 0);

        Assert.IsTrue(result);
    }

    [Test]
    public void Should_Return_False_For_An_Invalid_Move()
    {
        model.MakeMove(0, 0); // First move

        bool result = model.MakeMove(0, 0);

        Assert.IsFalse(result);
    }

    [Test]
    public void Should_Have_Winner_In_Horizontal_Line()
    {
        model.MakeMove(0, 0); // X
        model.MakeMove(1, 0); // O
        model.MakeMove(0, 1); // X
        model.MakeMove(1, 1); // O

        bool result = model.MakeMove(0, 2);

        Assert.IsTrue(result);
    }

    public void Should_Have_Winner_In_Vertical_Line()
    {
        model.MakeMove(0, 0); // X
        model.MakeMove(0, 1); // O
        model.MakeMove(1, 0); // X
        model.MakeMove(1, 1); // O

        bool result = model.MakeMove(2, 0);

        Assert.IsTrue(result);
    }

    // Other tests for the Model can be added here
}
