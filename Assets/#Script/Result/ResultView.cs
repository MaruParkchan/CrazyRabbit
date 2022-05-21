using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResultView : MonoBehaviour
{
    [SerializeField] GameObject[] player1Cuts;
    [SerializeField] GameObject[] player2Cuts;

    private bool player1Win = false;
    private bool player2Win = false;

    private void Awake()
    {
        WinnerCheck();
    }

    private void WinnerCheck()
    {
        if(PlayerPrefs.GetString("Winner") == "Player1")
        {
            player1Win = true;
        }
        else if(PlayerPrefs.GetString("Winner") == "Player2")
        {
            player2Win = true;
        }
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        int value = 0;
        while (true)
        {

            if (player1Win)
            {
                if (value == 5)
                {
                    Debug.Log("Player1 우승 및 끝");
                    StartCoroutine(GameEnd());
                    yield break;
                }

                player1Cuts[value].SetActive(true);
                yield return new WaitForSeconds(1.0f);
                value++;
            }
            else if (player2Win)
            {
                if (value == 5)
                {
                    Debug.Log("Player2 우승 및 끝");
                    StartCoroutine(GameEnd());
                    yield break;
                }

                player2Cuts[value].SetActive(true);
                yield return new WaitForSeconds(1.0f);
                value++;
            }

            else
                yield break;
        }
    }

    IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("02Intro");
    }
}
