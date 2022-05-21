using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G5TEST : MonoBehaviour
{

    private bool isStop = false;
    private void Awake()
    {
        StartCoroutine(ch());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StopAllCoroutines();
    }

    IEnumerator ch()
    {
        Debug.Log("1");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("2");
    }
}
