using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
    P1 , P2
}

public class Game1 : GameSetting
{
    private const float iceKeyTime = 0.5f;
    private float iceTimer = 0;
    private const float refleshTime = 1.0f;
    private float refleshTimer = 0;

    [SerializeField] private Player player;
    [SerializeField] private Game1Data game1Data;
    [SerializeField] private GameReady gameReady;
     private KeyCode YKey;
     private KeyCode BKey;
     private KeyCode AKey;
     private KeyCode ZKey;

    [SerializeField] private SpriteRenderer[] bowlObject = new SpriteRenderer[3]; // 밥그릇
    [SerializeField] private GameObject[] rice = new GameObject[3];  // 사료
    private int[] bowlArray = new int[3]; // 밥그릇 데이터 
    private int count = 0;
    private bool isComplete; // 밥그릇 3개 완성 했는가?
    private bool isArrival; // 진행도 100 했는가?
    private bool freezeKey;

    [Header("BOWL")]
    [SerializeField] private Sprite[] colorBowl; // 옐로우 , 레드 , 그린 , 블루 순서 -> index 4
    [Header("Character")]
    [SerializeField] private SpriteRenderer playerRender;
    [SerializeField] private Sprite[] characterSprite; // -> 3 기본 , 울음 , 웃음
    [Header("Effect")]
    [SerializeField] private GameObject effect;
    [SerializeField] private Transform[] effectPoint;
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioSource buttonSound;
    private int effectGauge = 0;
    
    private void Awake()
    {
        JoyStickKeySetting();
    }

    void Update()
    {
        if (game1Data.IsGameEnd == false)
        {
            InputKey();
            RiceOff();
            FreezeTime();
            EffectGaugeUpdate();
        }
    }

    public override void Initialization()
    {
        BowlReflesh();
        RiceReflesh();
    }

    private void InputKey()
    {
        if (!freezeKey && !isComplete && gameReady.IsStart == true)
        {
            if (Input.GetKeyDown(YKey))
            {
                IsKeySame(0);
            }

            else if (Input.GetKeyDown(BKey))
            {
                IsKeySame(1);
            }

            else if (Input.GetKeyDown(AKey))
            {
                IsKeySame(2);
            }

            else if (Input.GetKeyDown(ZKey))
            {
                IsKeySame(3);
            }
        }
    }

    private void BowlReflesh()
    {
        for(int i = 0; i < 3; i++)
        {
            bowlArray[i] = Random.Range(0, 4);
            bowlObject[i].sprite = colorBowl[bowlArray[i]]; // 랜덤으로 들어간 sprite 배치 
        }
    }

    private void RiceOff()
    {
        if(count == 1)
        {
            rice[count - 1].SetActive(false);
        }

        else if(count == 2)
        {
            rice[count - 1].SetActive(false);
        }

        else if (count == 3)
        {
            rice[count - 1].SetActive(false);
        }
    } 

    private void RiceReflesh()
    {
        count = 0;
        for (int i = 0; i < 3; i++)
            rice[i].SetActive(true);
    }

    private void IceKey()
    {
        freezeKey = true;
    } 

    private void IsKeySame(int num)
    {
        if (bowlArray[count] == num)
        {
            count++;
            buttonSound.Play();
            IsCompleteCheck();
        }
        else
            IceKey();
    }

    private void FreezeTime()
    {
        if(freezeKey)
        {
            if (iceKeyTime > iceTimer)
            {
                Debug.Log("키 얼음");
                iceTimer += Time.deltaTime;
                CharacterImage(1);
            }
            else
            {
                Debug.Log("키 풀림");
                iceTimer = 0;
                CharacterImage(0);
                freezeKey = false;
            }
        }
    }

    private void IsCompleteCheck()
    {
        if (count >= 3)
        {
            isComplete = true;
            HowPlayerCheck();
            StartCoroutine(Reflesh());
        }
    }

    private void HowPlayerCheck()
    {
        if (player == Player.P1)
        {
            game1Data.Player1Gauge();
            game1Data.PlayerGaugeLoop("Player1GaugeUpdate");
        }
        else if (player == Player.P2)
        {
            game1Data.Player2Gauge();
            game1Data.PlayerGaugeLoop("Player2GaugeUpdate");
        }
    }

    private void CharacterImage(int value)
    {  
        playerRender.sprite = characterSprite[value];           
    }

    IEnumerator Reflesh()
    {
        effectGauge++;
        Debug.Log("재배치중");
        sound.PlayOneShot(sound.clip);
        CharacterImage(2);
        yield return new WaitForSeconds(refleshTime);
        CharacterImage(0);
        isComplete = false;
        RiceReflesh();
        BowlReflesh();
    }

    private void JoyStickKeySetting()
    {
        if (player == Player.P1)
        {
            YKey = KeyCode.Joystick1Button3;
            BKey = KeyCode.Joystick1Button1;
            AKey = KeyCode.Joystick1Button0;
            ZKey = KeyCode.Joystick1Button2;
        }
        else if (player == Player.P2)
        {
            YKey = KeyCode.Joystick2Button3;
            BKey = KeyCode.Joystick2Button1;
            AKey = KeyCode.Joystick2Button0;
            ZKey = KeyCode.Joystick2Button2;
        }
    }

    private void EffectGaugeUpdate()
    {
        if(effectGauge >= 3)
        {
            GameObject clone = Instantiate(effect);
            clone.transform.position = effectPoint[Random.Range(0,3)].position;
            effectGauge = 0;
        }
    }   
}
