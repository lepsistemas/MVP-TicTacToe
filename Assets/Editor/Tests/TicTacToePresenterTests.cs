using NUnit.Framework;
using Moq;

public class TicTacToePresenterTests
{
    private TicTacToePresenter presenter;
    private Mock<ITicTacToeView> viewMock;
    private TicTacToeModel model;

    [SetUp]
    public void Setup()
    {
        viewMock = new Mock<ITicTacToeView>();
        model = new TicTacToeModel();
        presenter = new TicTacToePresenter(viewMock.Object, model);
    }

    [Test]
    public void Should_Update_Player_Info_In_View()
    {
        var expectedInfo = "Player X's Turn";
        viewMock.Setup(view => view.UpdatePlayerInfo(It.IsAny<string>()));

        presenter.UpdatePlayerInfo();

        viewMock.Verify(view => view.UpdatePlayerInfo(expectedInfo), Times.Exactly(2));
    }

    // Other tests for the Presenter can be added here
}
