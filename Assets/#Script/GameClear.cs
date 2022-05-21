using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    private string nextScene = "StageProgress";

    private void NextGame()
    {
        StartCoroutine(NextScene());
    }

    public void WinnerDataSave(bool player1Win, bool player2Win)
    {
        Debug.Log("PPP - Count값 ->" + PlayerPrefs.GetInt("Count"));
        if(PlayerPrefs.GetInt("Count") == 0)
        {
            if (player1Win)
            {
                PlayerPrefs.SetString("Round1", "Player1");
                PlayerPrefs.SetInt("Player1WinCount", 1 ); // 카운트 증가 
            }
            else if (player2Win)
            {
                PlayerPrefs.SetString("Round1", "Player2");
                PlayerPrefs.SetInt("Player2WinCount", 1); // 카운트 증가 
            }
        }

        else if (PlayerPrefs.GetInt("Count") == 1)
        {
            if (player1Win)
            {
                PlayerPrefs.SetString("Round2", "Player1");
                PlayerPrefs.SetInt("Player1WinCount", PlayerPrefs.GetInt("Player1WinCount") + 1);
            }
            else if (player2Win)
            {
                PlayerPrefs.SetString("Round2", "Player2");
                PlayerPrefs.SetInt("Player2WinCount", PlayerPrefs.GetInt("Player2WinCount") + 1);
            }
        }

        else if (PlayerPrefs.GetInt("Count") == 2)
        {
            if (player1Win)
            {
                PlayerPrefs.SetString("Round3", "Player1");
                PlayerPrefs.SetInt("Player1WinCount", PlayerPrefs.GetInt("Player1WinCount") + 1);
            }
            else if (player2Win)
            {
                PlayerPrefs.SetString("Round3", "Player2");
                PlayerPrefs.SetInt("Player2WinCount", PlayerPrefs.GetInt("Player2WinCount") + 1);
            }
        }

        else if (PlayerPrefs.GetInt("Count") == 3)
        {
            if (player1Win)
            {
                PlayerPrefs.SetString("Round4", "Player1");
                PlayerPrefs.SetInt("Player1WinCount", PlayerPrefs.GetInt("Player1WinCount") + 1);
            }
            else if (player2Win)
            {
                PlayerPrefs.SetString("Round4", "Player2");
                PlayerPrefs.SetInt("Player2WinCount", PlayerPrefs.GetInt("Player2WinCount") + 1);
            }
        }

        else if (PlayerPrefs.GetInt("Count") == 4)
        {
            if (player1Win)
            {
                PlayerPrefs.SetString("Round5", "Player1");
                PlayerPrefs.SetInt("Player1WinCount", PlayerPrefs.GetInt("Player1WinCount") + 1);
            }
            else if (player2Win)
            {
                PlayerPrefs.SetString("Round5", "Player2");
                PlayerPrefs.SetInt("Player2WinCount", PlayerPrefs.GetInt("Player2WinCount") + 1);
            }
        }

     //   PlayerPrefs.SetInt("Count", PlayerPrefs.GetInt("Count") + 1); // 카운트 증가
        NextGame(); // 씬전환

    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(7.0f);
        SceneManager.LoadScene(nextScene);
    }

    // Game
}
