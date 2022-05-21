using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4Player : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Game4Data game4Data;

    private KeyCode AKey;
    private KeyCode Bkey;

    private void Awake()
    {
        JoyStickKeySetting();
    }

    private void Update()
    {
        InputKey();
    }

    private void InputKey()
    {
        if (Input.GetKeyDown(AKey))
            game4Data.CountPlus(player);

        else if (Input.GetKeyDown(Bkey))
            game4Data.CountMinus(player);
    }


    private void JoyStickKeySetting()
    {
        if (player == Player.P1)
        {
            AKey = KeyCode.Joystick1Button0;
            Bkey = KeyCode.Joystick1Button1;
        }
        else if (player == Player.P2)
        {
            AKey = KeyCode.Joystick2Button0;
            Bkey = KeyCode.Joystick2Button1;
        }
    }

}
