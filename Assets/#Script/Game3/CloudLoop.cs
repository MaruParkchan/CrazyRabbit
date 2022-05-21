using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLoop : Movement
{
    [SerializeField] private float xLimit;
    [SerializeField] private float yMaxLimit;
    [SerializeField] private float yMinLimit;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    private void Awake()
    {
        Set_Speed(Random.Range(minSpeed, maxSpeed));
        transform.position = new Vector3(-xLimit, Random.Range(yMinLimit, yMaxLimit), -7.0f);
    }

    void Update()
    {
        Move(Vector3.right);
        LimitPosition();
    }

    private void LimitPosition()
    {
        if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(-xLimit, Random.Range(yMinLimit, yMaxLimit),-7.0f);
            Set_Speed(Random.Range(minSpeed, maxSpeed));
            Debug.Log("재배치");
        }
    }
}
