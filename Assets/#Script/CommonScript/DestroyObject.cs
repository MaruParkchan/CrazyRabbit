using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float destroyTime;

    private void Awake()
    {
        Destroy(this.gameObject, destroyTime); 
    }
}
