using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game7Spawn : MonoBehaviour
{
    // 공통 : 적  , 
    // 다른거 : 나오는 위치 , 회전방향 , 
    // 셋팅 : 게임시작시 한번에 몬스터가 나와야함 
    public Player player;
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private Transform spawnList;

    [SerializeField] private Transform[] leftPoints = new Transform[3];
    [SerializeField] private Transform[] rightPoints = new Transform[3];

    private int index = 0;   // 몬스터 배열수
    private int pointIndex = 0; // 왼쪽 오른쪽 포지션값

    private void Awake()
    {
      // FirstEnemySpawn();    
    }

    private void FirstEnemySpawn() // 총 3번만 스폰 , 좌우중에 랜덤 , 그리고 Count ++  
    {
        for(int i = 0; i < 3; i++)
        {
            int j = Random.Range(0, 2);

            if (j == 0)
            {
                SpawnEnemyFirst(leftPoints[i], 180.0f);
            }
            else
                SpawnEnemyFirst(rightPoints[i], 0);

        }
    }

    private void SpawnEnemyFirst(Transform point, float euler)
    {
        int i = Random.Range(0, enemys.Length);
        GameObject clone = Instantiate(enemys[i]);
        clone.transform.position = point.position;
        clone.transform.rotation = Quaternion.Euler(0, euler, 0);
        clone.transform.parent = spawnList.transform;
    }

    public void SpawnEnemy() // 적 생성
    {
        index = Random.Range(0, enemys.Length);
        pointIndex = Random.Range(0, 2);
        GameObject clone = Instantiate(enemys[index]);
        clone.transform.parent = spawnList.transform;
       
   //     clone.GetComponent<Game7Enemy>().EnemyAffiliation(player);

        if (pointIndex == 0) // 왼쪽 포지션 // 처음 몬스터가 sprite가 왼쪽보고있을 기준 
        {
            clone.transform.position = leftPoint.position;
            clone.transform.rotation = Quaternion.Euler(0, 180.0f, 0);
            clone.GetComponent<Game7Enemy>().RightOrLeft(false); // 왼쪽에서 --> 오른쪽으로 hit할경우 false로 넘김            
        }
        else if (pointIndex == 1) // 오른쪽 포지션 // 처음 몬스터가 sprite가 왼쪽보고있을 기준 
        {
            clone.transform.position = rightPoint.position;
            clone.transform.rotation = Quaternion.Euler(0, 0, 0);
            clone.GetComponent<Game7Enemy>().RightOrLeft(true);
        }
        clone.GetComponent<Game7Enemy>().player = player;
        //   Debug.Log("Player 소속 : " + player + " 생성 ");

    }
}
