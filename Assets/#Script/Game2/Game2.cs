using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2 : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Game2Display display;
    [SerializeField] private GameReady gameReady;
    [Header("Character Sprite")]
    [SerializeField] private Sprite[] characterSprite = new Sprite[3];
    [Header("Borad Sprite")]
    [SerializeField] private GameObject boradObject;
    [SerializeField] private SpriteRenderer boradRender;
    [SerializeField] private Sprite[] buttonSprite = new Sprite[4];
    [Header("Effect")]
    [SerializeField] private GameObject sucEffect;

    private SpriteRenderer render;
    private Sprite[] spriteList = new Sprite[3];
    private KeyCode YKey;
    private KeyCode BKey;
    private KeyCode AKey;
    private KeyCode ZKey;

    private float isFreezeTime = 1.5f;
    private bool isFail;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        SpriteChange();
        JoyStickKeySetting();
    }

    private void Start()
    {
        render.sprite = spriteList[0];
    }

    private void Update()
    {
        InputKey();
    }

    private void InputKey()
    {
        if (display.IsReflesh == false && display.IsRight == false && !isFail && gameReady.IsStart)
        {
            if (Input.GetKeyDown(YKey))
            {
                StartCoroutine(IBoradUpdate(buttonSprite[0]));
                display.ClickCheck(player, 1); 
            }
            else if (Input.GetKeyDown(BKey))
            {
                StartCoroutine(IBoradUpdate(buttonSprite[1]));
                display.ClickCheck(player, 2);
            }
            else if (Input.GetKeyDown(AKey))
            {
                StartCoroutine(IBoradUpdate(buttonSprite[2]));
                display.ClickCheck(player, 3);
            }
            else if (Input.GetKeyDown(ZKey))
            {
                StartCoroutine(IBoradUpdate(buttonSprite[3]));
                display.ClickCheck(player, 4);
            }
        }
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

    private void SpriteChange()
    {
        for (int i = 0; i < 3; i++)
        {
            spriteList[i] = characterSprite[i];
        }
    }

    public void Suceess()
    {
        StartCoroutine(ISuccess());
    }

    public void KeyFail()
    {
        StartCoroutine(IKeyFail());
    }

    IEnumerator IKeyFail()
    {
        if (isFail)
            yield break;

        isFail = true;
        render.sprite = spriteList[1];
        yield return new WaitForSeconds(isFreezeTime);
        isFail = false;
        render.sprite = spriteList[0];
    }

    IEnumerator ISuccess()
    {
        sucEffect.SetActive(true);
        render.sprite = spriteList[2];
        yield return new WaitForSeconds(1.5f);
        render.sprite = spriteList[0];
        sucEffect.SetActive(false);
    }

    IEnumerator IBoradUpdate(Sprite sprite)
    {
        boradObject.SetActive(true);
        boradRender.sprite = sprite;
        yield return new WaitForSeconds(isFreezeTime);
        boradRender.sprite = null;
        boradObject.SetActive(false);
    }
}
