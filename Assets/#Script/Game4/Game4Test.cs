using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4Test : MonoBehaviour
{
    [SerializeField] private int p1;
    [SerializeField] private int p2;

    private int resultP1;
    private int resultP2;

    private int count;
    private void Awake()
    {
        count = Random.Range(0, 31);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(SST());
        }
    }

    IEnumerator SST()
    {
        count = Random.Range(0, 16);

        Debug.Log("count -> " + count);

        resultP1 = Mathf.Abs(p1 - count);
        resultP2 = Mathf.Abs(p2 - count);

        if (resultP1 == resultP2)
        {
            Debug.Log("비김 재시작->");
            StartCoroutine(SST());
            yield break;
        }

        else if (resultP1 < resultP2)
            Debug.Log("p1 승리");
        else if (resultP1 > resultP2)
            Debug.Log("p2 승리");

        yield return null;
    }
}
