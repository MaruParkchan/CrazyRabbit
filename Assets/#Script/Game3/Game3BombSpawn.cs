using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3BombSpawn : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private GameObject bombClone;
    [SerializeField] private Vector3[] coordinates = new Vector3[56];

    private void Awake()
    {
        Coordinates();
        StartCoroutine(SpawnBombObject());
    }

    IEnumerator SpawnBombObject()
    {
        BombSpawn();
        yield return new WaitForSeconds(spawnTimer);
        StartCoroutine(SpawnBombObject());
    }

    private void Coordinates()
    {
        coordinates[0] = new Vector3(-5.5f, -1.5f);
        coordinates[1] = new Vector3(-5.5f, -2.5f);

        coordinates[2] = new Vector3(-4.5f, -0.5f);
        coordinates[3] = new Vector3(-4.5f, -1.5f);
        coordinates[4] = new Vector3(-4.5f, -2.5f);

        coordinates[5] = new Vector3(-3.5f, -0.5f);
        coordinates[6] = new Vector3(-3.5f, -1.5f);
        coordinates[7] = new Vector3(-3.5f, -2.5f);
        coordinates[8] = new Vector3(-3.5f, -3.5f);

        coordinates[9] = new Vector3(-2.5f, 1.5f);
        coordinates[10] = new Vector3(-2.5f, 0.5f);
        coordinates[11] = new Vector3(-2.5f, -0.5f);
        coordinates[12] = new Vector3(-2.5f, -1.5f);
        coordinates[13] = new Vector3(-2.5f, -2.5f);
        coordinates[14] = new Vector3(-2.5f, -3.5f);

        coordinates[15] = new Vector3(-1.5f, 1.5f);
        coordinates[16] = new Vector3(-1.5f, 0.5f);
        coordinates[17] = new Vector3(-1.5f, -0.5f);
        coordinates[18] = new Vector3(-1.5f, -1.5f);
        coordinates[19] = new Vector3(-1.5f, -2.5f);
        coordinates[20] = new Vector3(-1.5f, -3.5f);
        coordinates[21] = new Vector3(-1.5f, -4.5f);

        coordinates[22] = new Vector3(0f, 2.5f);
        coordinates[23] = new Vector3(0f, 1.5f);
        coordinates[24] = new Vector3(0f, 0.5f);
        coordinates[25] = new Vector3(0f, -0.5f);
        coordinates[26] = new Vector3(0f, -1.5f);
        coordinates[27] = new Vector3(0f, -2.5f);
        coordinates[28] = new Vector3(0f, -3.5f);
        coordinates[29] = new Vector3(0f, -4.5f);
        coordinates[30] = new Vector3(0f, -5.5f);

        coordinates[31] = new Vector3(1.0f, 2.0f);
        coordinates[32] = new Vector3(1.0f, 1.0f);
        coordinates[33] = new Vector3(1.0f, 0.0f);
        coordinates[34] = new Vector3(1.0f, -0.0f);
        coordinates[35] = new Vector3(1.0f, -1.0f);
        coordinates[36] = new Vector3(1.0f, -2.0f);
        coordinates[37] = new Vector3(1.0f, -3.0f);
        coordinates[38] = new Vector3(1.0f, -4.0f);
        coordinates[39] = new Vector3(1.0f, -5.0f);

        coordinates[40] = new Vector3(2.0f, 1.0f);
        coordinates[41] = new Vector3(2.0f, 0.0f);
        coordinates[42] = new Vector3(2.0f, -0.0f);
        coordinates[43] = new Vector3(2.0f, -1.0f);
        coordinates[44] = new Vector3(2.0f, -2.0f);
        coordinates[45] = new Vector3(2.0f, -3.0f);
        coordinates[46] = new Vector3(2.0f, -4.0f);

        coordinates[47] = new Vector3(3.0f, -1.5f);
        coordinates[48] = new Vector3(3.0f, -0.5f);
        coordinates[49] = new Vector3(3.0f, -1.5f);
        coordinates[50] = new Vector3(3.0f, -2.5f);
        coordinates[51] = new Vector3(3.0f, -3.0f);
        coordinates[52] = new Vector3(3.0f, -3.5f);
        coordinates[53] = new Vector3(3.0f, -4.0f);

        coordinates[54] = new Vector3(4.0f, -3.0f);
        coordinates[55] = new Vector3(4.0f, -2.0f);
    }

    private void BombSpawn()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject clone = Instantiate(bombClone);
            clone.transform.position = coordinates[Random.Range(0, coordinates.Length)];
        }
    }
}
