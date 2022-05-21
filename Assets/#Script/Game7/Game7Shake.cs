using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game7Shake : MonoBehaviour
{
    Vector3 originPos;

    void Start()
    {
        originPos = transform.localPosition;
    }

    public IEnumerator Shake(float _amount, float _duration)
    {
        Debug.Log("ㅇㅇ");
        float timer = 0;
        while (timer <= _duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originPos;

    }
}
