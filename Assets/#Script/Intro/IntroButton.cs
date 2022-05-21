using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroButton : SceneChange
{
    [SerializeField] private Image[] buttonImage = null;
    [SerializeField] private Color buttonBaseColor;
    [SerializeField] private Color buttonChangeColor;
    [SerializeField] private int buttonNumber = 0;

    private KeyCode upKey = KeyCode.UpArrow;
    private KeyCode downKey = KeyCode.DownArrow;
    private KeyCode clcikKey = KeyCode.Space;

    private KeyCode YKey;
    private KeyCode BKey;
    private KeyCode AKey;
    private KeyCode XKey;
    private bool isGameStart = false;
    [Header("Button List")]
    [SerializeField] private GameObject startObject;
    [SerializeField] private GameObject creditObject;

    private void Start()
    {
        buttonImage[buttonNumber].color = buttonChangeColor;
        JoyStickKeySetting();
    }

    private void Update()
    {
        if (!isGameStart) //   GameStart 버튼을 안누를시 
            InputKey();
    }

    private void InputKey()
    {
        if(Input.GetKeyDown(upKey) || Input.GetKeyDown(YKey))
            ButtonNumberValue(false);

        if (Input.GetKeyDown(downKey) || Input.GetKeyDown(AKey))
            ButtonNumberValue(true);

        if (Input.GetKeyDown(clcikKey) || Input.GetKeyDown(BKey) || Input.GetKeyDown(XKey))
        {
            ButtonClickEvent();
        }
    }

    private void ButtonNumberValue(bool isDown)
    {
        if (isDown)
            buttonNumber++;
        else
            buttonNumber--;    // +- 판별

        if (buttonNumber > buttonImage.Length -1)  // 범위 값 안넘어가게 판별
        {
            buttonNumber = buttonImage.Length -1;
            return;
        }

        else if( buttonNumber < 0)
        {
            buttonNumber = 0;
            return;
        }

        ButtonColorActivation(); // 버튼 색깔 넣기
    }

    private void ButtonColorActivation()
    {
        #region
        //if(buttonNumber == 0)
        //{
        //    buttonImage[0].color = buttonChangeColor;
        //    buttonImage[1].color = buttonBaseColor;
        //    buttonImage[2].color = buttonBaseColor;
        //}

        //if (buttonNumber == 1)
        //{
        //    buttonImage[0].color = buttonBaseColor;
        //    buttonImage[1].color = buttonChangeColor;
        //    buttonImage[2].color = buttonBaseColor;
        //}

        //if (buttonNumber == 2)
        //{
        //    buttonImage[0].color = buttonBaseColor;
        //    buttonImage[1].color = buttonBaseColor;
        //    buttonImage[2].color = buttonChangeColor;
        //}
        #endregion 원시적인방법

        for (int i = 0; i < buttonImage.Length; i++)
        {
            if (i == buttonNumber)
            {
                buttonImage[i].color = buttonChangeColor;
            }

            if(i != buttonNumber)
            {
                buttonImage[i].color = buttonBaseColor;
            }
        }
    }

    private void ButtonClickEvent()
    {
        switch(buttonNumber)
        {
            case 0:
                ButtonStart();
                break;

            case 1:
                ButtonCredit();
                break;

            case 2:
                ButtonExit();
                break;
        }
    }

    private void ButtonStart() // GameStart Button
    {
        Debug.Log("게임시작");
        startObject.SetActive(true);
        isGameStart = true;
    }

    private void ButtonCredit() // Development
    {
        Debug.Log("개발자문구");
    }

    private void ButtonExit() // Game Quit
    {
        Debug.Log("게임종료");
        Application.Quit();
    }

    private void JoyStickKeySetting()
    {
        YKey = KeyCode.Joystick1Button3;
        BKey = KeyCode.Joystick1Button1;
        AKey = KeyCode.Joystick1Button0;
        XKey = KeyCode.Joystick1Button2;

    }

    #region


    #endregion
}
