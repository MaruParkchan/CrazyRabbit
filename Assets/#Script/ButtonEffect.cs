using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerType
{
    P1,P2
}
public class ButtonEffect : MonoBehaviour
{
    private KeyCode YKey;
    private KeyCode BKey;
    private KeyCode AKey;
    private KeyCode XKey;

    [SerializeField] private PlayerType playerType;
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private SpriteRenderer[] spriteRender;
    [SerializeField] private GameReady gameReady;
    [SerializeField] private GameEnd gameEnd;


    private void Awake()
    {
        CheckKeyCode();
    }

    private void Update()
    {
        if (gameReady.IsStart == true && gameEnd.P1_Win == false && gameEnd.P2_Win == false)
            InputKey();
    }

    private void InputKey()
    {
        if (Input.GetKeyDown(YKey))
            spriteRender[0].sprite = sprite[0];
        else if(Input.GetKeyUp(YKey))
            spriteRender[0].sprite = sprite[1];

        if (Input.GetKeyDown(BKey))
            spriteRender[1].sprite = sprite[2];
        else if (Input.GetKeyUp(BKey))
            spriteRender[1].sprite = sprite[3];

        if (Input.GetKeyDown(AKey))
            spriteRender[2].sprite = sprite[4];
        else if (Input.GetKeyUp(AKey))
            spriteRender[2].sprite = sprite[5];

        if (Input.GetKeyDown(XKey))
            spriteRender[3].sprite = sprite[6];
        else if (Input.GetKeyUp(XKey))
            spriteRender[3].sprite = sprite[7];
    }

    private void CheckKeyCode()
    {
        if(PlayerType.P1 == playerType)
        {
            YKey = KeyCode.Joystick1Button3;
            BKey = KeyCode.Joystick1Button1;
            AKey = KeyCode.Joystick1Button0;
            XKey = KeyCode.Joystick1Button2;
        }
        else if(PlayerType.P2 == playerType)
        {
            YKey = KeyCode.Joystick2Button3;
            BKey = KeyCode.Joystick2Button1;
            AKey = KeyCode.Joystick2Button0;
            XKey = KeyCode.Joystick2Button2;
        }
    }

}
