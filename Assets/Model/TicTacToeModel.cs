public class TicTacToeModel
{
    private char[,] board = new char[3, 3];
    public char CurrentPlayer { get; private set; } = 'X';
    private bool gameOver = false;

    public TicTacToeModel()
    {
        ResetBoard();
    }

    public bool MakeMove(int x, int y)
    {
        if (board[x, y] == '\0' && !gameOver)
        {
            board[x, y] = CurrentPlayer;
            gameOver = CheckForWinner(x, y);
            if (!gameOver) 
            {
                SwitchPlayer();
            }
            return true;
        }
        return false;
    }

    private void SwitchPlayer()
    {
        CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
    }

    private bool CheckForWinner(int x, int y)
    {
        // Check row
        if (board[x, 0] == CurrentPlayer && board[x, 1] == CurrentPlayer && board[x, 2] == CurrentPlayer)
        return true;

        // Check column
        if (board[0, y] == CurrentPlayer && board[1, y] == CurrentPlayer && board[2, y] == CurrentPlayer)
            return true;

        // Check diagonals
        if (x == y && board[0, 0] == CurrentPlayer && board[1, 1] == CurrentPlayer && board[2, 2] == CurrentPlayer)
            return true;

        if (x + y == 2 && board[0, 2] == CurrentPlayer && board[1, 1] == CurrentPlayer && board[2, 0] == CurrentPlayer)
            return true;

        return false;
    }

    public bool IsGameOver(out bool isDraw)
    {
        isDraw = false;

        if (gameOver)
        {
            // Game over due to a win
            return true;
        }

        if (IsBoardFull())
        {
            // Game over due to a draw
            isDraw = true;
            return true;
        }

        return false;
    }

    private bool IsBoardFull()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == '\0')
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void ResetBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = '\0';
            }
        }
        CurrentPlayer = 'X';
        gameOver = false;
    }

    public char GetCurrentPlayerSymbol()
    {
        return CurrentPlayer;
    }

}
