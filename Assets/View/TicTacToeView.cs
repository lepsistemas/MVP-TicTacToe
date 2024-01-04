using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TicTacToeView : MonoBehaviour, ITicTacToeView
{
    public event Action<int, int> OnCellClicked;
    public event Action OnResetClicked;
    
    public event Action OnExitClicked;

    public Button[] cellButtons;

    public Button resetButton;

    public Button exitButton;

    public TextMeshProUGUI playerInfoText;
    public TextMeshProUGUI winnerInfoText;

    void Start()
    {
        for (int i = 0; i < cellButtons.Length; i++)
        {
            int index = i;
            cellButtons[i].onClick.AddListener(() => OnCellButtonClicked(index));
        }
        resetButton.onClick.AddListener(OnResetButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        OnExitClicked += ExitGame;
    }

    private void OnCellButtonClicked(int cellIndex)
    {
        int x = cellIndex / 3;
        int y = cellIndex % 3;
        OnCellClicked?.Invoke(x, y);
    }

    private void OnResetButtonClicked()
    {
        OnResetClicked?.Invoke();
    }

    private void OnExitButtonClicked()
    {
        OnExitClicked?.Invoke();
    }

    public void UpdateCell(int x, int y, char playerSymbol)
    {
        int cellIndex = x * 3 + y;
        this.cellButtons[cellIndex].GetComponentInChildren<TextMeshProUGUI>().text = playerSymbol.ToString();
    }

    public void UpdatePlayerInfo(string info)
    {
        this.playerInfoText.text = info;
    }

    public void ShowWinner(char winner)
    {
        this.winnerInfoText.text = winner == '\0' ? "It's a draw!" : $"Player {winner} wins!";
    }

    public void ResetBoard()
    {
        foreach (var button in cellButtons)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
        UpdatePlayerInfo("Player X's Turn");
        // Reset any other UI elements, like winner info text
        winnerInfoText.text = "";
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Exit play mode in the editor
        #else
            Application.Quit(); // Quit the application
        #endif
    }
}
