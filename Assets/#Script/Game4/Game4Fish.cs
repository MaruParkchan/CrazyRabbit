using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4Fish : MonoBehaviour
{
    private Game4Data game4Data;
    private float startTime = 6.0f; // 패트롤 끝나고 달려갈 대기시간
    private Vector3 pos;
    private float patrolSpeed; // 패트롤 스피드 
    private float runSpeed; // 빠르게 왼쪽 오른쪽 갈 스피드
    private float timer; // 패트롤 시간
    private float saveTimer; // 패트롤 시간 저장 - 재사용 - 
    private bool isWait = false; // 패트롤 끝남 체크

    private void Awake()
    {
        pos.x = Random.Range(-1.5f, 1.5f);
        timer = Random.Range(1.0f, 2.0f);
        saveTimer = timer;
        patrolSpeed = Random.Range(1.0f, 2.5f);
        runSpeed = Random.Range(3.0f, 4.0f);
        game4Data = GameObject.Find("Game4Data").GetComponent<Game4Data>();
        StartCoroutine(StartLine());
    }

    private void Update()
    {
        Patrol();
        Turn();
    }

    private void Patrol()
    {
        if (isWait)
            return;

        Move(patrolSpeed);
        if (timer < 0)
        {
            pos.x *= -1.0f;
            timer = saveTimer;
        }

        timer -= Time.deltaTime;
    }

    private void Move(float speed)
    {
        transform.position += pos * speed * Time.deltaTime;
    }

    private void Turn()
    {
        if (pos.x > -0.1f)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    IEnumerator StartLine()
    {
        yield return new WaitForSeconds(startTime);
        isWait = true;

        Vector3[] dir = new Vector3[2];
        int value = Random.Range(0, 2);
        dir[0] = Vector3.right;
        dir[1] = Vector3.left;
        pos = dir[value];

        if(value == 0)
        {
            game4Data.FishRightCountPlus();
        }
        else if(value == 1)
        {
            game4Data.FishLeftCountPlus();
        }
            
        while (true)
        {
            Move(runSpeed);
            yield return null;
        }
    }
}
