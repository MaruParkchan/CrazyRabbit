using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G6_MapChoice : MonoBehaviour
{
    [SerializeField] private GameObject[] mapList;  // 1,2,3 3개있음
    [SerializeField] private GameObject[] canvasMaps; // 1,2,3 3개 / 캔버스 미니맵표시 
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

  //  [SerializeField] private Transform[] pos; // 0 ,1 -> map1   // 2,3 -> map2 // 4,5 -> map3

    private int value;
    
    private void Awake()
    {
        value = Random.Range(0, 3);
    }

    private void Start()
    {
        mapList[value].SetActive(true);
        canvasMaps[value].SetActive(true);
        Pos();
    }

    private void Pos()
    {
        if(value == 0)
        {
            player1.transform.position = mapList[0].transform.Find("Player1").GetComponent<Transform>().localPosition + new Vector3(0,0,-1);
            player2.transform.position = mapList[0].transform.Find("Player2").GetComponent<Transform>().localPosition + new Vector3(0,0,-1);
        }                                                                                                     
        else if (value == 1)                                                                                  
        {                                                                                                     
            player1.transform.position = mapList[1].transform.Find("Player1").GetComponent<Transform>().localPosition + new Vector3(0,0,-1);
            player2.transform.position = mapList[1].transform.Find("Player2").GetComponent<Transform>().localPosition + new Vector3(0,0,-1);
        }                                                                                                   
        else if (value == 2)                                                                                    
        {                                                                                                      
            player1.transform.position = mapList[2].transform.Find("Player1").GetComponent<Transform>().localPosition + new Vector3(0,0,-1);
            player2.transform.position = mapList[2].transform.Find("Player2").GetComponent<Transform>().localPosition + new Vector3(0, 0, -1);
        }
    }
    
}
