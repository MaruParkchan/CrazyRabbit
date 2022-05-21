using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestModeSelect : MonoBehaviour
{
    public string sceneNamge;


    public void SceneChange()
    {
        SceneManager.LoadScene(sceneNamge);
    }
}
