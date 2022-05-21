using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G6_Player : Movement
{
    [SerializeField] private string horizontal;
    [SerializeField] private string vertical;
    [SerializeField] private float speed;
    [SerializeField] private G6_MiniMap g6_MiniMap;
    private GameEnd gameEnd;
    private Rigidbody2D rigid;
    private Animator animator;

    private void Awake()
    {
        Set_Speed(speed);
        gameEnd = GameObject.Find("GameEnd").GetComponent<GameEnd>();
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (g6_MiniMap.isGameStart && (gameEnd.P1_Win == false && gameEnd.P2_Win == false))
        {
            Move(horizontal, vertical, rigid);
        }
    }

    public void CameraEvent()
    {
        animator.SetTrigger("ZoomIn");
    }
}
