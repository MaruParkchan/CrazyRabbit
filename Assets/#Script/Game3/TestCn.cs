using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCn : MonoBehaviour
{
    string name;

    void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0 + i))
                Debug.Log("joy1  " + i);

            if (Input.GetKeyDown(KeyCode.Joystick2Button0 + i))
                Debug.Log("joy2  " + i);
        }

    }
}
