using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G6_Goal : MonoBehaviour
{
    [SerializeField] GameEnd gameEnd;
    bool isGoal = false;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isGoal = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isGoal)
            return;

        if(col.name.Contains("Player"))
        {
            isGoal = true;
            if (col.name == "Player1")
            { 
                WinnerCheck(0);
            }
            else if (col.name == "Player2")
            {
                WinnerCheck(1);
            }
            col.GetComponent<G6_Player>().CameraEvent();
        }
    }

    private void WinnerCheck(int value)
    {
        gameEnd.EndSysytem();

        if (value == 0)
            gameEnd.Player1Win();

        else if(value == 1)
            gameEnd.Player2Win();
    }
}
