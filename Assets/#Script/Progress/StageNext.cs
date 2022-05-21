using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageNext : MonoBehaviour
{
    bool isResultOn = false;

    private void Awake()
    {
        StartCoroutine(NextStageLoop());
    }

    public void StageCheck()
    {
        WinnerCheck();
        if (isResultOn)
            return;

        if (PlayerPrefs.GetInt("Stage") == 3)
        {
            if (PlayerPrefs.GetInt("Count") == 0)
            {
                PlayerPrefs.SetInt("Count", PlayerPrefs.GetInt("Count") + 1);
                SceneManager.LoadScene("Game" + PlayerPrefs.GetInt("Level2"));
            }
            else if (PlayerPrefs.GetInt("Count") == 1)
            {
                PlayerPrefs.SetInt("Count", PlayerPrefs.GetInt("Count") + 1);
                SceneManager.LoadScene("Game" + PlayerPrefs.GetInt("Level3"));
            }
            else if (PlayerPrefs.GetInt("Count") == 2)
            {
                SceneManager.LoadScene("Result");
            }
        }
        else if (PlayerPrefs.GetInt("Stage") == 5)
        {
            if (PlayerPrefs.GetInt("Count") == 0)
            {
                PlayerPrefs.SetInt("Count", PlayerPrefs.GetInt("Count") + 1);
                SceneManager.LoadScene("Game" + PlayerPrefs.GetInt("Level2"));
            }
            else if (PlayerPrefs.GetInt("Count") == 1)
            {
                PlayerPrefs.SetInt("Count", PlayerPrefs.GetInt("Count") + 1);
                SceneManager.LoadScene("Game" + PlayerPrefs.GetInt("Level3"));
            }
            else if (PlayerPrefs.GetInt("Count") == 2)
            {
                PlayerPrefs.SetInt("Count", PlayerPrefs.GetInt("Count") + 1);
                SceneManager.LoadScene("Game" + PlayerPrefs.GetInt("Level4"));
            }
            else if (PlayerPrefs.GetInt("Count") == 3)
            {
                PlayerPrefs.SetInt("Count", PlayerPrefs.GetInt("Count") + 1);
                SceneManager.LoadScene("Game" + PlayerPrefs.GetInt("Level5"));
            }
            else if (PlayerPrefs.GetInt("Count") == 4)
            {
                SceneManager.LoadScene("Result");
            }
        }
    }

    public void NextStage() // 다음스테이지 이동
    {
        if (PlayerPrefs.GetInt("Count") == 0)
        {
            SceneManager.LoadScene("Game" + PlayerPrefs.GetInt("Level1"));
        }
    }

    public void FirstStage() // 처음스테이지
    {
        SceneManager.LoadScene("Game" + PlayerPrefs.GetInt("Level1"));
    }

    private void WinnerCheck()
    {
        if (PlayerPrefs.GetInt("Stage") == 3)
        {
            if (PlayerPrefs.GetInt("Player1WinCount") >= 2)
            {
                PlayerPrefs.SetString("Winner", "Player1");
                isResultOn = true;
                SceneManager.LoadScene("Result");
            }
            else if (PlayerPrefs.GetInt("Player2WinCount") >= 2)
            {
                PlayerPrefs.SetString("Winner", "Player2");
                isResultOn = true;
                SceneManager.LoadScene("Result");
            }
        }
        else if (PlayerPrefs.GetInt("Stage") == 5)
        {
            if (PlayerPrefs.GetInt("Player1WinCount") >= 3)
            {
                PlayerPrefs.SetString("Winner", "Player1");
                isResultOn = true;
                SceneManager.LoadScene("Result");
            }
            else if (PlayerPrefs.GetInt("Player2WinCount") >= 3)
            {
                PlayerPrefs.SetString("Winner", "Player2");
                isResultOn = true;
                SceneManager.LoadScene("Result");
            }
        }
    }

    IEnumerator NextStageLoop()
    {
        yield return new WaitForSeconds(2.0f);
        StageCheck();

    }
}
