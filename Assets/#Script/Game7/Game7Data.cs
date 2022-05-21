using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game7Data : MonoBehaviour
{
    [SerializeField] private GameEnd gameEnd;
    [SerializeField] private GameClear gameClear;

    [SerializeField] private Game7Spawn player1Game7Spawn;
    [SerializeField] private Game7Spawn player2Game7Spawn;

    [SerializeField] private Text player1ScoreText;
    [SerializeField] private Text player2ScoreText;

    [SerializeField] private TextMeshProUGUI player1ScoreT;
    [SerializeField] private TextMeshProUGUI player2ScoreT;
    [SerializeField] private Animator p1Animator;
    [SerializeField] private Animator p2Animator;

    [SerializeField] private int stageClearScore = 0;
    public bool player1Move = false;
    public bool player2Move = false;

    private int player1Score = 0; // 플레이어1 점수
    private int player2Score = 0; // 플레이어2 점수

    public bool isGameEnd = false; // 게임끝나는 조건 
    [Header("Point")]
    public Transform[] P1LeftPoints = new Transform[4];
    public Transform[] P1RightPoints = new Transform[4];

    public Transform[] P2LeftPoints = new Transform[4];
    public Transform[] P2RightPoints = new Transform[4];

    private void Awake()
    {
        
    }

    void Update()
    {

        ScoreUpdate();
        WinnerCheck();

        //if (Input.GetKeyDown(KeyCode.C))
        //    Player1_EnemyMoveAndSpawn();

        //if (Input.GetKeyDown(KeyCode.V))
        //    Player2_EnemyMoveAndSpawn();
    }

    private void WinnerCheck()
    {
        if (isGameEnd == false)
        {
            if (player1Score >= stageClearScore)
            {
                isGameEnd = true;
                gameEnd.Player1Win();
                gameEnd.EndSysytem();
            }
            else if (player2Score >= stageClearScore)
            {
                isGameEnd = true;
                gameEnd.Player2Win();
                gameEnd.EndSysytem();
            }
        }
    }
    public void EnemyMoveAndSpawn(Player player) // 적 움직이고 생성코드
    {
        if (player == Player.P1)
        {
            Move(player1Game7Spawn, "P1EnemySpawn");
        }
        else if(player == Player.P2)
        {
            Move(player2Game7Spawn, "P2EnemySpawn");
        }
    }

    private void Move(Game7Spawn spawn, string spawnName)
    {
        spawn.SpawnEnemy();

        Game7Enemy[] clone = GameObject.Find(spawnName).GetComponentsInChildren<Game7Enemy>();

        for (int i = 0; i < clone.Length; i++)
            clone[i].EnemyMove();
    }


    public void Player1ScoreGet(int score) // player1 점수획득
    {
        player1Score += score;
        p1Animator.SetTrigger("IsTrigger");
    }

    public void Player2ScoreGet(int score) // player2 점수획득
    {
        player2Score += score;
        p2Animator.SetTrigger("IsTrigger");
    }

    private void ScoreUpdate() // 점수 업데이트 함수
    {
        if (player1Score <= 0)
            player1Score = 0;

        if (player2Score <= 0)
            player2Score = 0;

        player1ScoreText.text = "" + player1Score;
        player2ScoreText.text = "" + player2Score;

        player1ScoreT.text = player1Score.ToString();
        player2ScoreT.text = player2Score.ToString();
    }

}
