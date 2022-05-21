using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestModeChange : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("GameTestMode");
    }
}
