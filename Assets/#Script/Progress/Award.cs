using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Award : MonoBehaviour
{
    [Header("BackGround")]
    [SerializeField] private GameObject round3BG;
    [SerializeField] private GameObject round5BG;

    [Header("Award Object")]
    [SerializeField] private GameObject player1Award;
    [SerializeField] private GameObject player2Award;

    [Header("Game 3 Award ")]
    [SerializeField] private Transform award3Point1;
    [SerializeField] private Transform award3Point2;
    [SerializeField] private Transform award3Point3;

    [Header("Game 5 Award ")]

    [SerializeField] private Transform award5Point1;
    [SerializeField] private Transform award5Point2;
    [SerializeField] private Transform award5Point3;
    [SerializeField] private Transform award5Point4;
    [SerializeField] private Transform award5Point5;

    private void Awake()
    {
        StageCheck();
        CreateAward();
    }

    private void StageCheck() // 3스테이지인지 5스테이지인지 체크
    {
        if(PlayerPrefs.GetInt("Stage") == 3)
        {
            round3BG.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Stage") == 5)
        {
            round5BG.SetActive(true);
        }
    }

    private void CreateAward()
    {
        if(PlayerPrefs.GetInt("Stage") == 3)
        {
            if (PlayerPrefs.GetString("Round1") == "Player1")
            {
                GameObject clone = Instantiate(player1Award);
                clone.transform.localPosition = award3Point1.localPosition;
            }
            else if (PlayerPrefs.GetString("Round1") == "Player2")
            {
                GameObject clone = Instantiate(player2Award);
                clone.transform.localPosition = award3Point1.localPosition;
            }
            if (PlayerPrefs.GetString("Round2") == "Player1")
            {
                GameObject clone = Instantiate(player1Award);
                clone.transform.localPosition = award3Point2.localPosition;
            }
            else if (PlayerPrefs.GetString("Round2") == "Player2")
            {
                GameObject clone = Instantiate(player2Award);
                clone.transform.localPosition = award3Point2.localPosition;
            }
            if (PlayerPrefs.GetString("Round3") == "Player1")
            {
                GameObject clone = Instantiate(player1Award);
                clone.transform.localPosition = award3Point3.localPosition;
            }
            else if (PlayerPrefs.GetString("Round3") == "Player2")
            {
                GameObject clone = Instantiate(player2Award);
                clone.transform.localPosition = award3Point3.localPosition;
            }
        }
        else if (PlayerPrefs.GetInt("Stage") == 5)
        {
            if (PlayerPrefs.GetString("Round1") == "Player1")
            {
                GameObject clone = Instantiate(player1Award);
                clone.transform.localPosition = award5Point1.localPosition;
            }
            else if (PlayerPrefs.GetString("Round1") == "Player2")
            {
                GameObject clone = Instantiate(player2Award);
                clone.transform.localPosition = award5Point1.localPosition;
            }
            if (PlayerPrefs.GetString("Round2") == "Player1")
            {
                GameObject clone = Instantiate(player1Award);
                clone.transform.localPosition = award5Point2.localPosition;
            }
            else if (PlayerPrefs.GetString("Round2") == "Player2")
            {
                GameObject clone = Instantiate(player2Award);
                clone.transform.localPosition = award5Point2.localPosition;
            }
            if (PlayerPrefs.GetString("Round3") == "Player1")
            {
                GameObject clone = Instantiate(player1Award);
                clone.transform.localPosition = award5Point3.localPosition;
            }
            else if (PlayerPrefs.GetString("Round3") == "Player2")
            {
                GameObject clone = Instantiate(player2Award);
                clone.transform.localPosition = award5Point3.localPosition;
            }
            if (PlayerPrefs.GetString("Round4") == "Player1")
            {
                GameObject clone = Instantiate(player1Award);
                clone.transform.localPosition = award5Point4.localPosition;
            }
            else if (PlayerPrefs.GetString("Round4") == "Player2")
            {
                GameObject clone = Instantiate(player2Award);
                clone.transform.localPosition = award5Point4.localPosition;
            }
            if (PlayerPrefs.GetString("Round5") == "Player1")
            {
                GameObject clone = Instantiate(player1Award);
                clone.transform.localPosition = award5Point5.localPosition;
            }
            else if (PlayerPrefs.GetString("Round5") == "Player2")
            {
                GameObject clone = Instantiate(player2Award);
                clone.transform.localPosition = award5Point5.localPosition;
            }
        }
    }

}
