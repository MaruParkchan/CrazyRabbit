using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChoice : MonoBehaviour
{
    [Header("1P")]
    [SerializeField] GameObject[] p1Image = null;
    [Header("2P")]
    [SerializeField] GameObject[] p2Image = null;

    [Header("READY")]
    [SerializeField] GameObject p1Ready = null;
    [SerializeField] GameObject p2Ready = null;
    [SerializeField] GameObject gameStartImage = null;    
    // 1p
    private KeyCode player1_LeftKey = KeyCode.Z;
    private KeyCode player1_RightKey = KeyCode.X;
    private KeyCode player1_StartKey = KeyCode.C;
    // 2p
    private KeyCode player2_LeftKey = KeyCode.I;
    private KeyCode player2_RightKey = KeyCode.O;
    private KeyCode player2_StartKey = KeyCode.P;

    private int player1Number = 0;
    private int player2Number = 0;

    private bool player1Ready = false;
    private bool player2Ready = false;
    private bool gameStart = false;

    private void Awake()
    {
        IsImageOnOff(player1Number, p1Image);
        IsImageOnOff(player2Number, p2Image);
    }
    private void Update()
    {
        ReadyCheck();
        InputKey();
        GameStartMode();
    }
    public void InputKey()
    {
        if (!player1Ready)
        {
            IsImageOnOff(player1Number, p1Image);

            if (Input.GetKeyDown(player1_LeftKey))
            {
                player1Number = 0;
            }
            else if (Input.GetKeyDown(player1_RightKey))
            {
                player1Number = 1;
            }
            else if (Input.GetKeyDown(player1_StartKey))
            {
                p1Ready.SetActive(true);
                player1Ready = true;
                PlayerPrefs.SetInt("Player1", player1Number);
            }
        }
        ///
        ///
        if (!player2Ready)
        {
            IsImageOnOff(player2Number, p2Image);

            if (Input.GetKeyDown(player2_LeftKey))
            {
                player2Number = 0;
            }
            if (Input.GetKeyDown(player2_RightKey))
            {
                player2Number = 1;
            }
            if (Input.GetKeyDown(player2_StartKey))
            {
                p2Ready.SetActive(true);
                player2Ready = true;
                PlayerPrefs.SetInt("Player2", player2Number);
            }
        }
    }
    private void ReadyCheck()
    {
        if (player1Ready && player2Ready)
            gameStart = true;
    }

    private void GameStartMode()
    {
        if(gameStart)
        {
            gameStartImage.SetActive(true);
        }
    }

    private void IsImageOnOff(int playerNum, GameObject[] clone)
    {
        for(int i = 0; i < clone.Length; i++)
        {
            if (i == playerNum)
            {
                clone[i].SetActive(true);
            }
            if(i != playerNum)
            {
                clone[i].SetActive(false);
            }
        }
    }
}
