using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G5_GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] point;
    [SerializeField] Image[] uiPropImage;
    [SerializeField] Sprite[] uiSprite;
    [SerializeField] GameObject[] player1Hp;
    [SerializeField] GameObject[] player2Hp;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] G5_Player G5_Player1;
    [SerializeField] G5_Player G5_Player2;
    private GameReady gameReady;
    private GameEnd gameEnd;
    private int player1Point = 0;
    public int Player1Point
    {
        get { return player1Point; }
    }
    private int player2Point = 0;
    public int Player2Point
    {
        get { return player2Point; }
    }
    [SerializeField] private int[] array = new int[3];

    private int player1Life = 3;
    private int player2Life = 3;
    private bool player1Die = false;
    private bool player2Die = false;
    [HideInInspector]
    private bool gameStart;
    public bool gameStop = false;
    public bool resume = false; // 중복 못하게 코루틴
    private int count;
    public float timer = 3;

    private void Awake()
    {
   //     point = GameObject.FindGameObjectsWithTag("Prop");
        gameReady = GameObject.Find("GameReady").GetComponent<GameReady>();
        gameEnd = GameObject.Find("GameEnd").GetComponent<GameEnd>();
        Player1RandomPositionValue();
        Player2RandomPositionValue();
        player1.transform.position = point[player1Point].transform.position;
        player2.transform.position = point[player2Point].transform.position;
    }

    private void Start()
    {
        PropSpriteChange();
    }

    private void Update()
    {
        if(gameReady.IsStart == true && gameStart == false)
        {
            StartCoroutine(GameExcute());
            gameStart = true;
        }
        PlayerHpImageUpdate();
        player1.transform.position = point[player1Point].transform.position;
        player2.transform.position = point[player2Point].transform.position;
    }

    public void CheckValue(Player player, int value) // 이동할때 좌표 체크
    {
        if(player == Player.P1)
        {
            if(player2Point != player1Point + value)
            {
                player1Point += value;
                player1.transform.position = point[player1Point].transform.position;
            }
        }
        else if (player == Player.P2)
        {
            if (player1Point != player2Point + value)
            {
                player2Point += value;
                player2.transform.position = point[player2Point].transform.position;
            }
        }
    }

    public void PlayerDieCheck(Player player)
    {
        if(player == Player.P1)
        {
            player1Die = true;
            player1Life--;
        }
        else if (player == Player.P2)
        {
            player2Die = true;
            player2Life--;
        }
        gameStop = true;
        StopExcutePropSystem();
    }

    private void PlayerHpImageUpdate()
    {
        #region Player1 Life Check
        if (player1Life == 0)
        {
            player1Hp[0].SetActive(false);
            player1Hp[1].SetActive(false);
            player1Hp[2].SetActive(false);
        }
        else if (player1Life == 1)
        {
            player1Hp[0].SetActive(true);
            player1Hp[1].SetActive(false);
            player1Hp[2].SetActive(false);
        }
        else if (player1Life == 2)
        {
            player1Hp[0].SetActive(true);
            player1Hp[1].SetActive(true);
            player1Hp[2].SetActive(false);
        }
        else if(player1Life == 3)
        {
            player1Hp[0].SetActive(true);
            player1Hp[1].SetActive(true);
            player1Hp[2].SetActive(true);
        }
        #endregion

        #region Player2 Life Check
        if (player2Life == 0)
        {
            player2Hp[0].SetActive(false);
            player2Hp[1].SetActive(false);
            player2Hp[2].SetActive(false);
        }
        else if (player2Life == 1)
        {
            player2Hp[0].SetActive(true);
            player2Hp[1].SetActive(false);
            player2Hp[2].SetActive(false);
        }
        else if (player2Life == 2)
        {
            player2Hp[0].SetActive(true);
            player2Hp[1].SetActive(true);
            player2Hp[2].SetActive(false);
        }
        else if (player2Life == 3)
        {
            player2Hp[0].SetActive(true);
            player2Hp[1].SetActive(true);
            player2Hp[2].SetActive(true);
        }
        #endregion
    }

    private void PropSpriteChange()  // 발판 초기화
    {
        PropReset();
        Change(); // UI 발판도 초기화
        UIPanelPropImageReset(); // UI Image 발판도 초기화
    }

    private void PropReset()// 발판초기화
    {
        for (int i = 0; i < point.Length; i++) // 발판초기화
        {
            int a = Random.Range(0, 4);
            point[i].GetComponent<G5_Prop>().ValueReset(a); // 발판에 번호주기
            point[i].GetComponent<G5_Prop>().Setting(); // 애니메이션 셋팅 
        }
    }

    IEnumerator GameExcute() // 재시작 
    {
        Debug.Log("재시작중");
        PropSpriteChange();
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(PropExcute());
    }

    IEnumerator PropExcute()
    {
        while (true)
        {
            if (gameStop)
                yield break;


            yield return new WaitForSeconds(1.5f);

            if (gameStop)
                yield break;

            if (count == 3)
            {                     
                StartCoroutine(GameExcute());
                count = 0;
                yield break;
            }
            
            PropReset();
            uiPropImage[count].sprite = uiSprite[array[count] + 1];

            yield return new WaitForSeconds(1.0f); // 발판 띄운후에 대기시간
            for (int i = 0; i < point.Length; i++)
            {
                for(int j = 0; j < count + 1; j++)
                {
                    if (point[i].GetComponent<G5_Prop>().PropValue == array[j])
                        point[i].GetComponent<G5_Prop>().AnimationUpdate(array[j]);
                }
            }
            count++;
        }
    }

    IEnumerator PlayerDie()
    {
        StopCoroutine(PropExcute());
        Debug.Log("죽은거 체크");
        if (resume)
            yield break;

        yield return new WaitForSeconds(2.5f);

        if(player1Life == 0 && player2Life == 0)
        {
            player1Life++;
            player2Life++;
            Player1RandomPositionValue();
            Player2RandomPositionValue();
            G5_Player1.ResetPosition();
            G5_Player2.ResetPosition();
            StartCoroutine(PropExcute());
            yield break;
        }

        if(player1Life == 0)
        {
            gameEnd.EndSysytem();
            G5_Player2.ResetPosition();
            gameEnd.Player2Win();
            yield break;
        }
        else if(player2Life == 0)
        {
            gameEnd.EndSysytem();
            G5_Player1.ResetPosition();
            gameEnd.Player1Win();
            yield break;
        }

        if(player1Die == true)
        {
            Debug.Log("Player1 재생");
            Player1RandomPositionValue();
            G5_Player1.ResetPosition();
            player1Die = false;
            gameStop = false;
            StartCoroutine(PropExcute());
        }
        else if (player2Die == true)
        {
            Debug.Log("Player2 재생");
            Player2RandomPositionValue();
            G5_Player2.ResetPosition();
            player2Die = false;
            gameStop = false;
            StartCoroutine(PropExcute());
        }
    }

    private void Player1RandomPositionValue()
    {
        int limit = 1;

        for(int i = 0; i < limit; i++)
        {
            int value = Random.Range(0, point.Length);
            if (player2Point == value)
                limit--;
            else
            {
                player1Point = value;
            }
        }
    }
    private void Player2RandomPositionValue()
    {
        int limit = 1;

        for (int i = 0; i < limit; i++)
        {
            int value = Random.Range(0, point.Length);
            if (player1Point == value)
                limit--;
            else
            {
                player2Point = value;
            }
        }
    }
    private void StopExcutePropSystem()
    {
        resume = true;
        resume = false;
        StartCoroutine(PlayerDie());
    }

    

    private void UIPanelPropImageReset()
    {
        for (int i = 0; i < uiPropImage.Length; i++)
            uiPropImage[i].sprite = uiSprite[0];
    }

    private void Change() // 미리 배치된 숫자 ( 발판 나오는순서 )
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Random.Range(0, 4);
            for (int j = 0; j < i; j++)
            {
                if (array[i] == array[j])
                    i--;
            }
        }
    }
}
