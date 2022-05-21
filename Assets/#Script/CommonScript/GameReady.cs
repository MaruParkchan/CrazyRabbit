using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReady : MonoBehaviour
{
    [SerializeField] private GameObject howToObject; // 게임방법 문구끄기 위함
    [SerializeField] private GameObject countObject; // 카운터 이미지 뜨게 위함
    private KeyCode skipButton = KeyCode.Q;
    private bool isStart = false;
    private bool isGameEnd = false;

    public bool IsStart { get { return isStart; } set { isStart = value; } }

    private void Update()
    {
        InputKey();
    }

    private void InputKey()
    {
        if ( (Input.GetKeyDown(KeyCode.Joystick1Button7)) || (Input.GetKeyDown(KeyCode.Joystick2Button7)) || (Input.GetKeyDown(skipButton)) && isStart == false && isGameEnd == false)
            Skip();
    }

    public void Skip()
    {
        howToObject.SetActive(false);
        countObject.SetActive(true);
    }

    public void StartGame()
    {
        isStart = true;
    }
}