using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3BoxSpawn : MonoBehaviour
{
    [SerializeField] private GameObject boxClone;
    [SerializeField] private GameObject boxWaterClone;
    [SerializeField] private float spawnTime;
    [SerializeField] private int spawnLimit;
    [SerializeField] private Vector3[] coordinates = new Vector3[83];  // 맨꼭대기부터 -> 오른쪽방향순 
    private Transform boxPoint;
    private int count;
    private int pointValue;

    private void Awake()
    {
        // 69 ~ 82
        Coordinates();
        Debug.Log(coordinates.Length);
        StartCoroutine(Spawn());
    }

    private void Coordinates()
    {
        coordinates[0] = new Vector3(0.1f, 5.0f);
        coordinates[1] = new Vector3(0.9f, 4.6f);
        coordinates[2] = new Vector3(1.7f, 4.2f);
        coordinates[3] = new Vector3(2.6f, 3.7f);
        coordinates[4] = new Vector3(3.3f, 3.2f);
        coordinates[5] = new Vector3(4.2f, 2.7f);
        coordinates[6] = new Vector3(6.9f, 1.2f);
        coordinates[7] = new Vector3(7.7f, 0.6f);
        // 1 

        coordinates[8] = new Vector3(-0.65f, 4.6f);
        coordinates[9] = new Vector3(0.07f, 4.1f);
        coordinates[10] = new Vector3(0.8f, 3.7f);
        coordinates[11] = new Vector3(1.7f, 3.2f);
        coordinates[12] = new Vector3(2.4f, 2.7f);
        coordinates[13] = new Vector3(3.2f, 2.2f);
        coordinates[14] = new Vector3(5.9f, 0.7f);
        coordinates[15] = new Vector3(6.7f, 0.1f);
        // 2         
               
        coordinates[16] = new Vector3(-1.6f, 4.1f);
        coordinates[17] = new Vector3(-0.8f, 3.7f);
        coordinates[18] = new Vector3(-0.1f, 3.2f);
        coordinates[19] = new Vector3(0.7f, 2.7f);
        coordinates[20] = new Vector3(1.4f, 2.2f);
        coordinates[21] = new Vector3(2.3f, 1.7f);
        coordinates[22] = new Vector3(3.2f, 1.2f);
        coordinates[23] = new Vector3(4.0f, 0.6f);
        coordinates[24] = new Vector3(5.0f, 0.2f);
        coordinates[25] = new Vector3(5.8f, -0.4f);
        // 3           
                      
        coordinates[26] = new Vector3(-2.6f, 3.5f);
        coordinates[27] = new Vector3(-1.8f, 3.2f);
        coordinates[28] = new Vector3(-1.0f, 2.7f);
        coordinates[29] = new Vector3(-0.2f, 2.2f);
        coordinates[30] = new Vector3(0.5f, 1.7f);
        coordinates[31] = new Vector3(1.4f, 1.2f);
        coordinates[32] = new Vector3(2.3f, 0.7f);
        coordinates[33] = new Vector3(3.1f, 0.1f);
        coordinates[34] = new Vector3(4.1f, -0.3f);
        coordinates[35] = new Vector3(4.9f, -0.9f);
        // 4   
             
        coordinates[36] = new Vector3(-2.8f, 2.6f);
        coordinates[37] = new Vector3(-2.0f, 2.1f);
        coordinates[38] = new Vector3(-1.1f, 1.7f);
        coordinates[39] = new Vector3(-0.4f, 1.2f);
        coordinates[40] = new Vector3(0.4f, 0.6f);
        coordinates[41] = new Vector3(1.3f, 0.1f);
        coordinates[42] = new Vector3(2.1f, -0.5f);
        coordinates[43] = new Vector3(3.1f, -1.0f);
        coordinates[44] = new Vector3(3.9f, -1.5f);
        // 5         
                    
        coordinates[45] = new Vector3(-3.8f, 2.1f);
        coordinates[46] = new Vector3(-3f, 1.6f);
        coordinates[47] = new Vector3(-2.1f, 1.2f);
        coordinates[48] = new Vector3(-1.4f, 0.7f);
        coordinates[49] = new Vector3(-0.5f, 0.2f);
        coordinates[50] = new Vector3(0.4f, -0.3f);
        coordinates[51] = new Vector3(1.2f, -0.9f);
        coordinates[52] = new Vector3(2.0f, -1.3f);
        coordinates[53] = new Vector3(3.0f, -1.9f);
        // 6         
              
        coordinates[54] = new Vector3(-4.8f, 1.5f);
        coordinates[55] = new Vector3(-4.0f, 1.0f);
        coordinates[56] = new Vector3(-0.6f, -0.9f);
        coordinates[57] = new Vector3(0.19f, -1.5f);
        coordinates[58] = new Vector3(1.2f, -2.0f);
        coordinates[59] = new Vector3(2.0f, -2.5f);
        // 7       
                 
        coordinates[60] = new Vector3(-6.6f, 1.4f);
        coordinates[61] = new Vector3(-5.8f, 0.9f);
        coordinates[62] = new Vector3(-0.7f, -2.0f);
        coordinates[63] = new Vector3(0.3f, -2.4f);
        coordinates[64] = new Vector3(1.1f, -3.0f);
        // 8           
                       
        coordinates[65] = new Vector3(-7.5f, 0.8f);
        coordinates[66] = new Vector3(-6.8f, 0.3f);
        coordinates[67] = new Vector3(-0.7f, -2.9f);
        coordinates[68] = new Vector3(0.1f, -3.5f);
        // 8           
                       
        ///////////    
                       
        // WaterLine   
        coordinates[69] = new Vector3(-3.2f, 0.5f);
        coordinates[70] = new Vector3(-2.4f, 0.0f);
        coordinates[71] = new Vector3(-1.5f, -0.5f);
               
        coordinates[72] = new Vector3(-5.0f, 0.3f);
        coordinates[73] = new Vector3(-4.1f, -0.1f);
        coordinates[74] = new Vector3(-3.4f, -0.5f);
        coordinates[75] = new Vector3(-2.5f, -1.0f);
        coordinates[76] = new Vector3(-1.6f, -1.5f);
                
        coordinates[77] = new Vector3(-5.9f, -0.2f);
        coordinates[78] = new Vector3(-5.1f, -0.6f);
        coordinates[79] = new Vector3(-4.3f, -1.0f);
        coordinates[80] = new Vector3(-3.5f, -1.5f);
        coordinates[81] = new Vector3(-2.5f, -2.0f);
        coordinates[82] = new Vector3(-1.7f, -2.6f);

    }

    private void SpawnObject(GameObject obj , Vector3 pos)
    {
        GameObject clone = Instantiate(obj);
        clone.transform.position = pos;

    }
    IEnumerator Spawn()
    {
        pointValue = Random.Range(0, 83);
        yield return new WaitForSeconds(spawnTime);

        if (pointValue > 68)
        {
            SpawnObject(boxWaterClone, coordinates[pointValue]);
        }
        else
            SpawnObject(boxClone, coordinates[pointValue]);
        
        count++;

        if (spawnLimit <= count)
        {
            Debug.Log("생성종료");
            yield break;
        }
        StartCoroutine(Spawn());
    }
}
