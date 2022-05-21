using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VsCode : MonoBehaviour
{
 
    public void FirstStage() // 처음스테이지
    {
        SceneManager.LoadScene("Game" + PlayerPrefs.GetInt("Level1"));
    }
}
