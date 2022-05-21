using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G6_MiniMap : MonoBehaviour
{
    [HideInInspector]
    public bool isGameStart = false;
    [SerializeField] private GameObject clone;

    private void Awake()
    {
        clone.SetActive(false);
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(4.0f);
        isGameStart = true;
        Destroy(this.gameObject);
    }
}
