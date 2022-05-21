using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dddd : MonoBehaviour
{
  //  public Vector3 pos;

    private float x;
    private float y;

    void Start()
    {
        StartCoroutine(Rotate());
        x = Random.Range(5.0f, 8.0f);
        y = Random.Range(0.1f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += new Vector3(x, y, 0) * Time.deltaTime * 10.0f;
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(0, 0, -30);
            yield return null;
        }
    }
}
