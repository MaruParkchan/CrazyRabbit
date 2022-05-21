using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Data : MonoBehaviour
{
    private bool isGameEnd = false;
    public bool IsGameEnd { get { return isGameEnd; } }

    [SerializeField] private GameEnd gameEnd;
    private bool player1Win = false;
    private bool player2Win = false;

    private void Update()
    {
        IsArrival();
    }

    private void IsArrival()
    {
        if (isGameEnd)
        {
            return;
        }

        if (player1Win || player2Win)
        {
            isGameEnd = true;
            WinnerCheck();
        }
    }

    public void Player1Win()
    {
        player1Win = true;
    }

    public void Player2Win()
    {
        player2Win = true;
    }

    private void WinnerCheck() // 동시에 할시 P1이 승리하게 되는 시스템
    {
        if (player1Win)
        {
            Debug.Log("1p 승리");
            gameEnd.Player1Win();
        }
        else if (player2Win)
        {
            Debug.Log("2p 승리");
            gameEnd.Player2Win();
        }
        gameEnd.EndSysytem();
    }
}
