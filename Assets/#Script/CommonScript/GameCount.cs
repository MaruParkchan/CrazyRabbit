using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCount : MonoBehaviour
{
    [SerializeField] private float timer = 1.0f;
    [SerializeField] private GameObject musicSound; // 배경음악 켜기
    [SerializeField] private GameReady gameReady;
    [SerializeField] private GameSetting[] gameSetting;
    [SerializeField] private GameObject[] gameObjectOn; // 킬 오브젝트;

    [SerializeField] private GameObject readyImage;
    [SerializeField] private GameObject goImage;

    private void Awake()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        readyImage.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        readyImage.SetActive(false);
        goImage.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        goImage.SetActive(false);
        musicSound.SetActive(true);
        this.gameObject.SetActive(false);
        for (int i = 0; i < gameSetting.Length; i++)
            gameSetting[i].Initialization();
        for (int i = 0; i < gameObjectOn.Length; i++)
            gameObjectOn[i].SetActive(true);
        gameReady.StartGame();
    }
}
