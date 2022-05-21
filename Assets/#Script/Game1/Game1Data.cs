using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game1Data : MonoBehaviour
{
    [SerializeField] private Slider player1;
    [SerializeField] private Slider player2;
    [SerializeField] private int gameEndValue;
    private const int plusGaugeValue = 7;
    private int Player1GaugeValue = 0;
    private int Player2GaugeValue = 0;
    private int player1Gauge;
    private int player2Gauge;
    private bool isGameEnd = false;
    public bool IsGameEnd { get { return isGameEnd; } }

    [SerializeField] private GameEnd gameEnd;

    private void Awake()
    {
        player1.value = Player1GaugeValue;
        player2.value = Player2GaugeValue;
    }

    private void Update()
    {
        GaugeUpdate();
        IsArrival();
    }

    private void GaugeUpdate()
    {
        player1.value = player1Gauge;
        player2.value = player2Gauge;
    }
    public void Player1Gauge()
    {
        Player1GaugeValue += plusGaugeValue;
    }

    public void Player2Gauge()
    {
        Player2GaugeValue += plusGaugeValue;
    }

    private void IsArrival()
    {
        if (isGameEnd)
        {
            return;
        }

        if((Player1GaugeValue >= gameEndValue || Player2GaugeValue >= gameEndValue) && !isGameEnd)
        {
            isGameEnd = true;
            WinnerCheck();
        }
    }

    private void WinnerCheck() // 동시에 할시 P1이 승리하게 되는 시스템
    {
        if (Player1GaugeValue >= gameEndValue)
        {
            Debug.Log("1p 승리");
            gameEnd.Player1Win();
        }
        else if (Player2GaugeValue >= gameEndValue)
        {
            Debug.Log("2p 승리");
            gameEnd.Player2Win();
        }
        gameEnd.EndSysytem();
    }

    public void PlayerGaugeLoop(string gaugeUpdate)
    {
        StartCoroutine(gaugeUpdate);
    }

    private IEnumerator Player1GaugeUpdate()
    {
        while (true)
        {
            if (player1Gauge > Player1GaugeValue)
                yield break;

            yield return new WaitForSeconds(0.05f);
            player1Gauge++;
        }
    }

    private IEnumerator Player2GaugeUpdate()
    {
        while (true)
        {
            if (player2Gauge > Player2GaugeValue)
                yield break;

            yield return new WaitForSeconds(0.05f);
            player2Gauge++;
        }
    }

}
