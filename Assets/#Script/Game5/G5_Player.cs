using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G5_Player : MonoBehaviour
{
    //[SerializeField] private string horizontal;
    //[SerializeField] private string vertical;
    [SerializeField] G5_GameManager manager;
    [SerializeField] private Player player;
    [SerializeField] private float speed;
    [SerializeField] private int posValue;
    [SerializeField] AudioSource moveSound;
    private GameReady gameReady;
    private Animator ani;
    private KeyCode YKey;
    private KeyCode BKey;
    private KeyCode AKey;
    private KeyCode XKey;
    private bool isMove = false;

   // [SerializeField] GameObject[] point;

    void Awake()
    {
        //  point = GameObject.FindGameObjectsWithTag("Prop");
        ani = GetComponent<Animator>();
        gameReady = GameObject.Find("GameReady").GetComponent<GameReady>();
        JoyStickKeySetting();
    }

    void Update()
    {
        if(manager.gameStop == false && gameReady.IsStart == true)
        {
            Move();
        }
        PosValueCheck();
    }

    void Move()
    {
        if (Input.GetKeyDown(YKey) && posValue >= 5) // 0 ~ 4이면 불가능 - 위로가는코드
            manager.CheckValue(player, -5);
        else if (Input.GetKeyDown(AKey) && posValue <= 19) // 아래로 내려가는거 19까지 - 아래로가는 코드
            manager.CheckValue(player, 5);
        else if (Input.GetKeyDown(BKey) && (posValue + 1) % 5 != 0)
            manager.CheckValue(player, 1);
        else if (Input.GetKeyDown(XKey) && posValue % 5 != 0)
            manager.CheckValue(player, -1);

        if (Input.GetKeyDown(YKey) || Input.GetKeyDown(AKey) || Input.GetKeyDown(BKey) || Input.GetKeyDown(XKey))
            moveSound.Play();
    }

    void PosValueCheck()
    {
        if(player == Player.P1)
        {
            posValue = manager.Player1Point;
        }
        else if(player == Player.P2)
        {
            posValue = manager.Player2Point;
        }
    }

    //IEnumerator MoveTo(Vector3 dir)
    //{
    //    while(true)
    //    {

    //    }
    //    yield return new WaitForSeconds(0.1f);
    //}

    private void JoyStickKeySetting()
    {
        if (player == Player.P1)
        {
            YKey = KeyCode.Joystick1Button3;
            BKey = KeyCode.Joystick1Button1;
            AKey = KeyCode.Joystick1Button0;
            XKey = KeyCode.Joystick1Button2;
        }
        else if (player == Player.P2)
        {
            YKey = KeyCode.Joystick2Button3;
            BKey = KeyCode.Joystick2Button1;
            AKey = KeyCode.Joystick2Button0;
            XKey = KeyCode.Joystick2Button2;
        }
    }

    public void ResetPosition()
    {
        ani.SetTrigger("Reset");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Prop")
        {
            manager.PlayerDieCheck(player);
            ani.SetTrigger("Die");
            Debug.Log(player + "Player 떨어짐");
        }
    }


}
