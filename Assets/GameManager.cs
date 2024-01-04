using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    void Start()
    {
        var view = GetComponent<TicTacToeView>();
        if (view != null)
        {
            var model = new TicTacToeModel();
            new TicTacToePresenter(view, model);
        }
        else
        {
            Debug.LogError("TicTacToeView component not found on the GameObject.");
        }
    }
}
