using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game2Display : GameSetting
{
    [SerializeField] private int questLimit;
    [SerializeField] private float refleshTimer;
    private int spriteValue = 0;
    [SerializeField] private Game2 player1GameData;
    [SerializeField] private Game2 player2GameData;
    [SerializeField] private Game2Data game2Data;
    [Header("사운드")]
    private AudioSource sound;
    [SerializeField] AudioClip rulet;
    [SerializeField] AudioClip ruletStop;
    [Header("Sprite List")]
    [SerializeField] private Sprite[] yellowSprite = new Sprite[4];
    [SerializeField] private Sprite[] redSprite = new Sprite[4];
    [SerializeField] private Sprite[] greenSprite = new Sprite[4];
    [SerializeField] private Sprite[] blueSprite = new Sprite[4];
    [Header("스코어 텍스트")]
    [SerializeField] private Text player1ScoreText;
    [SerializeField] private Text player2ScoreText;
    private SpriteRenderer spriteRender;
    private bool isReflesh = false;
    public bool IsReflesh { get { return isReflesh; } }
    private bool isRight = false;
    public bool IsRight { get { return isRight; } }
    private int player1WinCount = 0;
    private int player2WinCount = 0;
    private int questCount = 0;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ScoreTextUpdate();
        StandRadnom();

        Debug.Log("P1 -> " + player1WinCount);
        Debug.Log("P2 -> " + player2WinCount);
        Debug.Log("Count -> " + questCount);
    }

    private void Quest()
    {
        spriteValue = Random.Range(1, 5);
        int value = Random.Range(0, 4);
        switch(spriteValue)
        {
            case 1:
                spriteRender.sprite = yellowSprite[value];
                break;
            case 2:
                spriteRender.sprite = redSprite[value];
                break;
            case 3:
                spriteRender.sprite = greenSprite[value];
                break;
            case 4:
                spriteRender.sprite = blueSprite[value];
                break;
        }
    }

    public void ClickCheck(Player player, int value)
    {
        if (isRight)
        { 
            return;
        }

        if (spriteValue == value)
        {
            isRight = true;
            if (player == Player.P1)
            {
                player1GameData.Suceess();
                player1WinCount++;
            }
            else if (player == Player.P2)
            {
                player2GameData.Suceess();
                player2WinCount++;
            }

            if (questCount >= questLimit)
            {
                spriteRender.sprite = null;
                GameResult();
                Debug.Log("게임종료");
                return;
            }
            StartCoroutine(Reflesh());
        }
        else
        {
            if (player == Player.P1)
            {
                player1GameData.KeyFail();
            }
            else if (player == Player.P2)
            {
                player2GameData.KeyFail();
            }
        }
    }

    public void GameResult()
    {
        if (player1WinCount > player2WinCount)
            game2Data.Player1Win();
        else if (player1WinCount < player2WinCount)
            game2Data.Player2Win();
    }

    public override void Initialization()
    {
        StartCoroutine(Reflesh());
    }

    IEnumerator Reflesh()
    {
        if (isReflesh)
            yield break;
        Debug.Log("다음문제...출제중");
        SoundPlay(rulet);
        questCount++;
        isReflesh = true;
        spriteRender.sprite = null;
        yield return new WaitForSeconds(refleshTimer);
        SoundPlay(ruletStop);
        isRight = false;
        isReflesh = false;
        Quest();
    }

    private void StandRadnom()
    {
        if (isReflesh)
        {
            int spriteValue = Random.Range(0, 4);
            int value = Random.Range(0, 4);
            switch (spriteValue)
            {
                case 0:
                    spriteRender.sprite = yellowSprite[value];
                    break;
                case 1:
                    spriteRender.sprite = redSprite[value];
                    break;
                case 2:
                    spriteRender.sprite = greenSprite[value];
                    break;
                case 3:
                    spriteRender.sprite = blueSprite[value];
                    break;
            }
        }
    }

    private void SoundPlay(AudioClip clip)
    {
        sound.Stop();
        sound.clip = clip;
        sound.Play();
    }

    private void ScoreTextUpdate()
    {
        player1ScoreText.text = "" + player1WinCount;
        player2ScoreText.text = "" + player2WinCount;
    }
}