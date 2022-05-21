using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageProgress : MonoBehaviour
{
    [SerializeField] private int [] mapData;

    public int[] MapData
    { 
        get
        {
            return mapData;
        }
    }

    private string[] strData;
    private int stageCount;

    private void GetMapData()
    {
        strData = PlayerPrefs.GetString("Array").Split(',');
        for(int i = 0; i < strData.Length; i++)
            Debug.Log("->" + strData[i]);
        mapData = new int[strData.Length];
        for (int i = 0; i < strData.Length; i++)
        {
            mapData[i] = System.Convert.ToInt32(strData[i]);
        }
    }

}
