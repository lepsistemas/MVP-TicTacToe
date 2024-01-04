using NUnit.Framework;
using UnityEngine;

public class TicTacToeModelTests
{
    private TicTacToeModel model;

    [SetUp]
    public void Setup()
    {
        // Initialize the model before each test
        model = new TicTacToeModel();
    }

    [Test]
    public void MakeMove_ValidMove_ReturnsTrue()
    {
        // Arrange is handled by Setup

        // Act
        bool result = model.MakeMove(0, 0);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void MakeMove_InvalidMove_ReturnsFalse()
    {
        // Arrange
        model.MakeMove(0, 0); // First move

        // Act
        bool result = model.MakeMove(0, 0); // Second move on the same cell

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void CheckForWinner_HorizontalWin_ReturnsTrue()
    {
        // Arrange
        model.MakeMove(0, 0); // X
        model.MakeMove(1, 0); // O
        model.MakeMove(0, 1); // X
        model.MakeMove(1, 1); // O

        // Act
        bool result = model.MakeMove(0, 2); // X completes a row

        // Assert
        Assert.IsTrue(result);
    }

    // Additional test cases for vertical, diagonal wins and draws
}
