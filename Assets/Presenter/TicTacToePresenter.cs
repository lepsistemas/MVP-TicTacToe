public class TicTacToePresenter
{
    
    private TicTacToeModel model;
    private ITicTacToeView view;

    public TicTacToePresenter(ITicTacToeView view, TicTacToeModel model) {
        this.view = view;
        this.model = model;
        this.view.OnCellClicked += HandleCellClicked;
        this.view.OnResetClicked += ResetBoard;
        UpdatePlayerInfo();
    }

    public void HandleCellClicked(int x, int y) {
        char currentPlayerSymbol = model.GetCurrentPlayerSymbol();
        if (model.MakeMove(x, y)) {
            view.UpdateCell(x, y, currentPlayerSymbol);
            if (model.IsGameOver(out bool isDraw)) {
                if (isDraw)
                {
                    view.ShowWinner('\0');
                }
                else
                {
                    view.ShowWinner(model.CurrentPlayer);
                }
            } else {
                UpdatePlayerInfo();
            }
        }
    }

    public void UpdatePlayerInfo() {
        string info = model.CurrentPlayer == 'X' ? "Player X's Turn" : "Player O's Turn";
        view.UpdatePlayerInfo(info);
    }

    public void ResetBoard()
    {
        model.ResetBoard();
        view.ResetBoard();
    }

}
