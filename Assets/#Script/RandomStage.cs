using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RandomStage : MonoBehaviour
{
    [SerializeField] private int stageCount = 18; // -> stage 개수 // 1 ~ count수 입력할시  그 해당스테이지까지
    [SerializeField] private int[] array;
    private int stageValue = 0; // 3게임 5게임 판별
    private string[] strData;
    private int[] mapData;

    private void Awake()
    {
        stageValue = PlayerPrefs.GetInt("Stage");
        array = new int[stageValue];
    }
    void Start()
    {
        StageRadnom();

    }
    private void StageRadnom()
    {
        for(int i = 0; i < array.Length; i++)
        {
            array[i] = Random.Range(1, stageCount + 1);
            for (int j = 0; j < i; j++)
            {
                if (array[i] == array[j])
                    i--;
            }
        }
        string tmp = "";
        for(int i = 0; i < array.Length; i++)
        {
            tmp += array[i];
            if(i < array.Length -1 )
                tmp += ",";
        }
        PlayerPrefs.SetString("Array", tmp);

        Debug.Log(PlayerPrefs.GetString("Array"));

        GetMapData();

    }

    private void GetMapData() // Array있는 키값을 , 을 빼고 저장 
    {
        strData = PlayerPrefs.GetString("Array").Split(',');
        for (int i = 0; i < strData.Length; i++)
            Debug.Log("->" + strData[i]);
        mapData = new int[strData.Length];
        for (int i = 0; i < strData.Length; i++)
        {
            mapData[i] = System.Convert.ToInt32(strData[i]);
        }
        StageDataSave();
    }

    private void StageDataSave() // PlayerPrefs에 Level 스테이지 1,2,3,4,5 로 저장하기 
    {
        if (stageValue == 3)
        {
            for (int i = 1; i <= 3; i++)
            {
                PlayerPrefs.SetInt("Level" + i, mapData[i - 1]);
                Debug.Log("현재 Level " + i + " 저장된값은 -> " + PlayerPrefs.GetInt("Level" + i) + " 입니다. ");
            }

        }
        else if (stageValue == 5)
        {
            for (int i = 1; i <= 5; i++)
            {
                PlayerPrefs.SetInt("Level" + i, mapData[i-1]);
                Debug.Log("현재 Level " + i + " 저장된값은 -> " + PlayerPrefs.GetInt("Level" + i) + " 입니다. ");
            }           
        }
        PlayerPrefs.SetInt("Player1WinCount", 0);
        PlayerPrefs.SetInt("Player2WinCount", 0);



    }
}
