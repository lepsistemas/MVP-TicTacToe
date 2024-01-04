using System;

public interface ITicTacToeView
{
    event Action<int, int> OnCellClicked;
    event Action OnResetClicked;
    event Action OnExitClicked;
    void UpdateCell(int x, int y, char playerSymbol);
    void UpdatePlayerInfo(string info);
    void ShowWinner(char winner);
    void ResetBoard();
    void ExitGame();
}
