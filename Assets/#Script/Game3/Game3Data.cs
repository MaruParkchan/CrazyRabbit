using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game3Data : MonoBehaviour
{
    private int player1GetCount;
    public int Player1WinCount { get { return player1GetCount; } }
    private int player2GetCount;
    public int Player2GetCount { get { return player2GetCount; } }

    [SerializeField] private GameEnd gameEnd;
    [SerializeField] private Text player1Count;
    [SerializeField] private Text player2Count;
    [SerializeField] private int winLimitCount;

    private bool isGameEnd; 

    private void Update()
    {
        DisPlayCountText();
        GameResult();
    }

    public void Player1Get()
    {
        player1GetCount++;
    }

    public void Player2Get()
    {
        player2GetCount++;
    }

    public void PlayerCountPlus(Player player)
    {

    }

    public void GameResult()
    {
        if (isGameEnd)
            return;

        if (player1GetCount > winLimitCount)
        {
            gameEnd.Player1Win();
            gameEnd.EndSysytem();
            isGameEnd = true;
        }
        else if (player2GetCount > winLimitCount)
        {
            gameEnd.Player2Win();
            gameEnd.EndSysytem();
            isGameEnd = true;
        }
    }

    private void DisPlayCountText()
    {
        player1Count.text = "" + player1GetCount;
        player2Count.text = "" + player2GetCount;
    }
}
