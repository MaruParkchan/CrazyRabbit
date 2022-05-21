using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameObject gameEndObject;
    [SerializeField] private GameObject player1Winner;
    [SerializeField] private GameObject player2Winner;
    [SerializeField] private GameObject winEffect;
    [SerializeField] private GameObject gameSound;
    [SerializeField] private GameObject[] offObject;

    private GameClear gameClear;

    private bool p1_Win = false;
    public bool P1_Win { get { return p1_Win; } }
    private bool p2_Win = false;
    public bool P2_Win { get { return p2_Win; } }

    public void Player1Win() => p1_Win = true;
    public void Player2Win() => p2_Win = true;

    private void Awake()
    {
        gameClear = GameObject.Find("GameClearSystem").GetComponent<GameClear>();    
    }

    public void EndSysytem()
    {
        StartCoroutine(GameEndSystem());
    }

    public void WinnerCheck()
    {
        if (p1_Win)
            player1Winner.SetActive(true);
        else if (p2_Win)
            player2Winner.SetActive(true);

        gameClear.WinnerDataSave(p1_Win, p2_Win);
        winEffect.SetActive(true);
    }

    private void ObjectOff()
    {
        for (int i = 0; i < offObject.Length; i++)
            offObject[i].SetActive(false);
    }

    IEnumerator GameEndSystem()
    {
        gameSound.SetActive(false);
        gameEndObject.SetActive(true);
        ObjectOff();
        yield return new WaitForSeconds(2.0f);
        gameEndObject.SetActive(false);
        WinnerCheck();
    }
    // Data 저장 / 누가이겼는지. 현재 스테이지 저장 , 
    // if(카운트 현재 계산 다음 스테이지인지 마지막인지 현재게임이 이것도 계산하는 코드 여기에다가 
    
}
