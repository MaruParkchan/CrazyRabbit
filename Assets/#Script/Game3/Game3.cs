using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3 : Movement
{
    [SerializeField] private GameEnd gameEnd;
    [SerializeField] private Game3Data game3Data;
    [SerializeField] private GameReady gameReady;
    [SerializeField] private float baseSpeed = 5.0f;
    [SerializeField] private float slowSpeed = 2.5f;
    [SerializeField] private Player player;
    [SerializeField] private string horizontal;
    [SerializeField] private string vertical;
    [SerializeField] private CircleCollider2D col;
    private Rigidbody2D rigid;

    [SerializeField] private AnimatorOverrideController animatorOverridController;
    [Header("Character1Clip")]
    [SerializeField] private AnimationClip standClip1;
    [SerializeField] private AnimationClip rightClip1;
    [SerializeField] private AnimationClip leftClip1;
    [SerializeField] private AnimationClip noneClip1;

    private Animator animator;
    private AudioSource sound;
    private bool isClick = false;
    private KeyCode AKey;
    private bool isSton;

    private void Awake()
    {
        Set_Speed(baseSpeed);
        JoyStickKeySetting();
        col.enabled = false;
        sound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        ClipSetting();
    }

    private void Update()
    {
        if (!isSton)
        {
            if (gameReady.IsStart && (gameEnd.P1_Win == false && gameEnd.P2_Win == false))
            {
                Move(horizontal, vertical, rigid);
                InputKey();
            }
            AnimationUpdate();
        }
    }

    private void InputKey()
    {
        if(Input.GetKeyDown(AKey))
        {
            StartCoroutine(OnCollider());
        }
    }

    private void JoyStickKeySetting()
    {
        if (player == Player.P1)
        {
            AKey = KeyCode.Joystick1Button0;;
        }
        else if (player == Player.P2)
        {
            AKey = KeyCode.Joystick2Button0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Item" && (gameEnd.P1_Win == false && gameEnd.P2_Win == false))
        {
            Destroy(col.gameObject);
            if(player == Player.P1)
            {
                game3Data.Player1Get();
                sound.Play();
            }
            else if (player == Player.P2)
            {
                game3Data.Player2Get();
                sound.Play();
              //Destroy(col.gameObject);
            }
        }

        if(col.transform.tag == "Water")
        {
            Debug.Log("충돌");
            Set_Speed(slowSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Water")
        {
            Debug.Log("충돌해제");
            Set_Speed(baseSpeed);
        }

        if(col.transform.tag == "Bomb")
        {
            Debug.Log("충돌");
            StopCoroutine(Stun());
            StartCoroutine(Stun());
        }
    }

    private void AnimationUpdate()
    {
        if (xPos > 0.1f)
            animator.Play("Right");
        else if (xPos < -0.1f)
            animator.Play("Left");
        else if (xPos == 0 && yPos > 0.1f || yPos < -0.1f)
            animator.Play("Stand");
        else if (xPos == 0 && yPos == 0)
            animator.Play("None");
    }

    private void ClipSetting()
    {
        animatorOverridController["Stand"] = standClip1;
        animatorOverridController["Right"] = rightClip1;
        animatorOverridController["Left"] = leftClip1;
        animatorOverridController["None"] = noneClip1;
           
        animator.runtimeAnimatorController = animatorOverridController;
    }

    IEnumerator OnCollider()
    {
        col.enabled = true;
        yield return new WaitForSeconds(0.05f);
        col.enabled = false;
    }

    IEnumerator Stun()
    {
        isSton = true;
        yield return new WaitForSeconds(1.1f);
        isSton = false;
    }
}
