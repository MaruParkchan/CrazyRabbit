using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G6_EffectPos : MonoBehaviour
{
    [SerializeField] private GameEnd gameEnd;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    private void Awake()
    {
        if (gameEnd.P1_Win == true)
            transform.position = player1.transform.position;
        else if (gameEnd.P2_Win == true)
            transform.position = player2.transform.position;
    }
}
