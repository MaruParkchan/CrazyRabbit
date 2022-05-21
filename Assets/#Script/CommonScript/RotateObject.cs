using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 rotatePos;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (transform.rotation.z > 360.0f)
            transform.rotation = Quaternion.Euler(0, 0, 0);

        transform.Rotate(rotatePos * speed);
    }
}
