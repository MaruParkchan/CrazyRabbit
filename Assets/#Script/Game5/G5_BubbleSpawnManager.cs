using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G5_BubbleSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] bubbles;
    [SerializeField] private Transform leftLimitPoint;
    [SerializeField] private Transform rightLimitPoint;
    [SerializeField] private float spawnTime;

    private void Awake()
    {
        StartCoroutine(SpawnBubble());
    }

    IEnumerator SpawnBubble()
    {
        int i = Random.Range(0, bubbles.Length);
        GameObject clone = Instantiate(bubbles[i]);
        clone.transform.position = new Vector3(Random.Range(leftLimitPoint.position.x, rightLimitPoint.position.x), -7.0f, -1.0f);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(SpawnBubble());
    }
}
