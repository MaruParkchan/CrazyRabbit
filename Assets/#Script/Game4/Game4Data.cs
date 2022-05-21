using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WallPoint
{
    Left, Right
}
public class Game4Data : MonoBehaviour
{
    [SerializeField] private Game4SpawnManager game4Spawn;
    [SerializeField] private GameEnd gameEnd;
    [SerializeField] private GameObject questPanelObject;
    [SerializeField] private Text countDownText;
    [SerializeField] private GameObject leftTextUI;
    [SerializeField] private GameObject rightTextUI;
    [SerializeField] private Text player1CountText;
    [SerializeField] private Text player2CountText;
    [SerializeField] private Text resultCountText;
    [SerializeField] private GameObject drawObject;
    [SerializeField] private float questViewTime; // 물고기 좌우 사라지고 문제나올시간
    [SerializeField] private float countTimer; // 카운트 시간 
    [SerializeField] private int leftCount; // 왼쪽으로 간 수
    [SerializeField] private int rightCount; // 오른쪽으로 간 수
    [SerializeField] private GameObject waterDrop; // 물방울;

    [Header("Sound")]
    [SerializeField] AudioSource buttonAudio;
    [SerializeField] AudioClip clip; 

    private int player1Count;
    private int player2Count;
    private bool isCountStart; // 카운트 버튼 누를수있게 하는것
    private bool isGameEnd; // 게임 종료 체크 
    private int value; // 왼쪽 오른쪽 문제구별

    private void Start()
    {
        resultCountText.text = "";
        questPanelObject.SetActive(false);
        drawObject.SetActive(false);
        waterDrop.SetActive(false);
        StartCoroutine(StageStart());
    }
    private void Update()
    {
        player1CountText.text = "" + player1Count;
        player2CountText.text = "" + player2Count;
    }
    private void QuestCheck()
    {
        value = Random.Range(0, 2); // 0 ,1 
        
        if(value == 0)
        {
            leftTextUI.SetActive(true);
        }
        else
        {
            rightTextUI.SetActive(true);
        }
        isCountStart = true;
    } // 질문 던지기 
     
    public void CountPlus(Player player)
    {
        if (!isCountStart)
            return;

        if (player == Player.P1)
        {
            player1Count++;
        }

        else if (player == Player.P2)
        {
            player2Count++;
        }

        buttonAudio.PlayOneShot(clip);
    } // 플러스
    public void CountMinus(Player player)
    {
        if (!isCountStart)
            return;

        if (player == Player.P1)
        {
            if (player1Count <= 0)
                return;

            player1Count--;
        }

        else if (player == Player.P2)
        {
            if (player2Count <= 0)
                return;

            player2Count--;
        }
        buttonAudio.PlayOneShot(clip);
    } // 마이너스

    public void FishCountCheck(WallPoint wallPoint)
    {
        if(wallPoint == WallPoint.Left)
        {
            leftCount++;
        }
        else if (wallPoint == WallPoint.Right)
        {
            rightCount++;
        }
    } // 물고기 왼쪽 오른쪽 체크

    public void FishLeftCountPlus()
    {
        leftCount++;
    }

    public void FishRightCountPlus()
    {
        rightCount++;
    }

    private int ValueCheck(int count, int playerValue)
    {
        return Mathf.Abs(count - playerValue);
    } // 절대값으로 수 판단

    private void GameDraw()
    {
        drawObject.SetActive(true);
        StartCoroutine(ReStartGame());   
    } // 게임 무승부

    private void DrawResetData()
    {
        player1Count = 0;
        player2Count = 0;
        leftCount = 0;
        rightCount = 0;
        resultCountText.text = "";
        countDownText.text = "";
    } // 데이터 초기화

    IEnumerator StageStart() // 1번 물고기 생성후
    {
        drawObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        Debug.Log("생성1");
        game4Spawn.FishReSpawn();
        yield return new WaitForSeconds(questViewTime); // 물고기 오른쪽 왼쪽 지나간후 텍스트 나올시간
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown() // 2번 n초동안 카운트 올리게하게함 
    {
        Debug.Log("카운트다운 시작 2");
        waterDrop.SetActive(true);
        float countValue = countTimer + 1.0f;
        questPanelObject.SetActive(true);
        QuestCheck();
        while (true)
        {
            if(countValue <= 0)
            {
                countValue = 0;
                StartCoroutine(CorrectCheck());
                isCountStart = false;
                yield break;
            }
            countValue -= Time.deltaTime;
            countDownText.text = "" + (int)countValue;
            yield return null;
        }
    }

    IEnumerator CorrectCheck() // 플레이어가 누른 수 체크
    {
        Debug.Log("체크 시작 3");
        waterDrop.SetActive(false);
        questPanelObject.SetActive(false);
        leftTextUI.SetActive(false);
        rightTextUI.SetActive(false);
        yield return new WaitForSeconds(1.0f);

        int player1Value = 0;
        int player2Value = 0;

        if (value == 0)
        {
            resultCountText.text = "" + leftCount;
            player1Value = ValueCheck(leftCount, player1Count);
            player2Value = ValueCheck(leftCount, player2Count);

            if(player1Value == player2Value) // 무승부 게임재시작
            {
                GameDraw();
                yield break;
            }

            StartCoroutine(WinnerCheck(player1Value, player2Value));
        }
        else
        {
            resultCountText.text = "" + rightCount;
            player1Value = ValueCheck(rightCount, player1Count);
            player2Value = ValueCheck(rightCount, player2Count);

            if (player1Value == player2Value) // 무승부 게임재시작
            {
                GameDraw();
                yield break;
            }

            StartCoroutine(WinnerCheck(player1Value, player2Value));
        }
    }

    IEnumerator ReStartGame()
    {
        Debug.Log("게임을 재시작합니다 ");
        yield return new WaitForSeconds(4.0f);
        DrawResetData();
        game4Spawn.FishPlus(10);
        StartCoroutine(StageStart());
    } // 무승부라 다시 게임 시작

    IEnumerator WinnerCheck(int player1, int player2)
    {

        yield return new WaitForSeconds(2.0f);
        resultCountText.text = "";
        if (player1 < player2)
        {
            gameEnd.Player1Win();
            gameEnd.EndSysytem();
        }
        else if (player1 > player2)
        {
            gameEnd.Player2Win();
            gameEnd.EndSysytem();
        }
    } // 게임승자 체크


}
