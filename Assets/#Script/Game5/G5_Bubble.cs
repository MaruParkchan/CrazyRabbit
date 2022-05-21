using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G5_Bubble : MonoBehaviour
{
    [SerializeField] private float minSpeedValue;
    [SerializeField] private float maxSpeedValue;
    private float speed;

    private void Awake()
    {
        speed = Random.Range(minSpeedValue, maxSpeedValue);
    }

    private void Update()
    {
        UpMove();
    }

    private void UpMove()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "DestioyZone")
            Destroy(this.gameObject);
    }
}
