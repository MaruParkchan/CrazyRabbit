using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] fishObject;
    [SerializeField] private float firstWaitTime; // 게임 첫 대기시간
    [SerializeField] private int minLimit;
    [SerializeField] private int maxLimit;
    private int limitPlus;

    public void FishReSpawn()
    {
        StartCoroutine(SpawnFish());
    }

    IEnumerator SpawnFish()
    {
        int limit = Random.Range(minLimit + limitPlus, maxLimit+1 + limitPlus);
        for(int i = 0; i < limit; i++)
        {
            SpawnObject();
        }
        yield return null;
    }

    private void SpawnObject()
    {
        GameObject clone = Instantiate(fishObject[Random.Range(0,fishObject.Length)]);
        clone.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(3.2f, -3.4f), 0);
    }

    public void FishPlus(int value) // 무승부일시 물고기수 증가
    {
        limitPlus += value;
    }
}
