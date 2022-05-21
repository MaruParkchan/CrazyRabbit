using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] target;
    [SerializeField] private float speed = 0;
    private int index = 0;

    private bool isMove = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMove)
            TargetTrace();
    }

    void TargetTrace()
    {
        if (index >= target.Length)
            index = 0;

        float distance = Vector2.Distance(target[index].position, transform.position);

        Vector3 dir = (target[index].position - transform.position).normalized;
        Debug.Log(distance);

        transform.position += dir * Time.deltaTime * speed;
        if (distance < 0.1f)
        {
            transform.position = target[index].position;
            isMove = true;
   //         index++;
        }

    }
}
