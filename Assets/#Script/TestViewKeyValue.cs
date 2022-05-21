using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestViewKeyValue : MonoBehaviour
{
    [SerializeField] Text countText;
    [SerializeField] Text level1;
    [SerializeField] Text level2;
    [SerializeField] Text level3;
    [SerializeField] Text level4;
    [SerializeField] Text level5;
    [SerializeField] Text array;
    [SerializeField] Text stage;
    [SerializeField] Text round1;
    [SerializeField] Text round2;
    [SerializeField] Text round3;
    [SerializeField] Text round4;
    [SerializeField] Text round5;
    [SerializeField] Text winCountPlayer1;
    [SerializeField] Text winCountPlayer2;

    private void Awake()
    {
        TextData();
    }

    private void TextData()
    {
        countText.text = "" + PlayerPrefs.GetInt("Count");
        level1.text = "" + PlayerPrefs.GetInt("Level1");
        level2.text = "" + PlayerPrefs.GetInt("Level2");
        level3.text = "" + PlayerPrefs.GetInt("Level3");
        level4.text = "" + PlayerPrefs.GetInt("Level4");
        level5.text = "" + PlayerPrefs.GetInt("Level5");
        array.text = "" + PlayerPrefs.GetString("Array");
        stage.text = "" + PlayerPrefs.GetInt("Stage");
        round1.text = "" + PlayerPrefs.GetString("Round1");
        round2.text = "" + PlayerPrefs.GetString("Round2");
        round3.text = "" + PlayerPrefs.GetString("Round3");
        round4.text = "" + PlayerPrefs.GetString("Round4");
        round5.text = "" + PlayerPrefs.GetString("Round5");
        winCountPlayer1.text = "" + PlayerPrefs.GetInt("Player1WinCount");
        winCountPlayer2.text = "" + PlayerPrefs.GetInt("Player2WinCount");
    }
}
