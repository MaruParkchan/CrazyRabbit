using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4Wall : MonoBehaviour
{
    [SerializeField] private WallPoint wallPoint;
    private Game4Data game4Data;

    private void Awake()
    {
        game4Data = GameObject.Find("Game4Data").GetComponent<Game4Data>();    
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Fish")
        {
            //game4Data.FishCountCheck(wallPoint);
            //Destroy(col.gameObject);
        }
    }
}
