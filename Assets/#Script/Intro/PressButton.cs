using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private KeyCode pressKey;
    private KeyCode startKeyP1;
    private KeyCode startKeyP2;

    private void Awake()
    {
        pressKey = KeyCode.Space;
        startKeyP1 = KeyCode.Joystick1Button7;
        startKeyP2 = KeyCode.Joystick2Button7;
    }

    private void Update()
    {
        if (Input.GetKeyDown(pressKey) || Input.GetKeyDown(startKeyP1) || Input.GetKeyDown(startKeyP2))
        {
            target.SetActive(true);
      //      this.gameObject.SetActive(false);
        }
    }

}
