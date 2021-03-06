using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrans : MonoBehaviour
{
    Vector3 originPos;

    void Start()
    {
        originPos = transform.localPosition;

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            StartCoroutine(Shake(1.0f, 1.0f));
    }

    public IEnumerator Shake(float _amount, float _duration)
    {
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
