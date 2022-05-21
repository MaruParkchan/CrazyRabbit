using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChoice : MonoBehaviour
{
    [SerializeField] private GameObject startImage;
    private Animator ani;
    private KeyCode rightKey = KeyCode.RightArrow;
    private KeyCode leftKey = KeyCode.LeftArrow;
    private KeyCode startKey = KeyCode.Space;
    // private KeyCode startKey = KeyCode.;
    private KeyCode YKey;
    private KeyCode BKey;
    private KeyCode AKey;
    private KeyCode XKey;
    private int stageNumber = 0;
    private bool isStart = false;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        JoyStickKeySetting();
    }

    private void Update()
    {
        if (!isStart)
            ButtonArrow();
    }

    private void ButtonArrow()
    {

        if (Input.GetKeyDown(rightKey) || (Input.GetKeyDown(BKey)))
        {
            stageNumber = 1;
        }

        else if (Input.GetKeyDown(leftKey) || (Input.GetKeyDown(XKey)))
        {
            stageNumber = 0;
        }

        else if (Input.GetKeyDown(startKey) || (Input.GetKeyDown(KeyCode.Joystick1Button7)))
        {
            StageCount();
            startImage.SetActive(true);
            isStart = true;
        }
        ani.SetInteger("StageValue", stageNumber);
    }

    private void Value()
    {
        ani.SetInteger("StageValue", stageNumber);
    }

    private void StageCount()
    {
        if(stageNumber == 0)
        {
            PlayerPrefs.SetInt("Stage", 3);
        }
        else if(stageNumber == 1)
        {
            PlayerPrefs.SetInt("Stage", 5);
        }
    }

    private void JoyStickKeySetting()
    {
        YKey = KeyCode.Joystick1Button3;
        BKey = KeyCode.Joystick1Button1;
        AKey = KeyCode.Joystick1Button0;
        XKey = KeyCode.Joystick1Button2;
    }
}
