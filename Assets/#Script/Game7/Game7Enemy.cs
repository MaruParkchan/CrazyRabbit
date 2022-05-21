using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game7Enemy : MonoBehaviour
{
    public Player player;

    [SerializeField] private float speed;
    [SerializeField] private GameObject dieEffect;
    [SerializeField] private Sprite[] moveSprites; // 0,1,2 - 1번이 경직 
    private SpriteRenderer spriteRender;
    public Transform[] leftPoints;
    public Transform[] rightPoints;

    private bool isMove = false;
    private bool isDie = false;
    private bool isLeftView = false; // 왼쪽을 보는지 오른쪽을 보는지  // 오른쪽을 보면서 가면 false 왼쪽은 true
    private int moveCount = 0; // 몇번걸었는지
    private float x;
    private float[] y = new float[3];
    private int i = 0;
    private Game7Data game7Data;
    private BoxCollider2D boxCollder;

    private bool SmartMove = false;
    private float timer;
    private int index = 0;

    private void Awake()
    {
        game7Data = GameObject.FindWithTag("Data").GetComponent<Game7Data>();
        spriteRender = GetComponent<SpriteRenderer>();
        boxCollder = GetComponent<BoxCollider2D>();
        y[0] = 1;
        y[1] = 4;
        y[2] = 7;
    }

    private void Start()
    {
        TargetPoints();
    }

    private void TargetPoints()
    {
        if (player == Player.P1)
        {
            leftPoints = game7Data.P1LeftPoints;
            rightPoints = game7Data.P1RightPoints;
        }
        else if (player == Player.P2)
        {
            leftPoints = game7Data.P2LeftPoints;
            rightPoints = game7Data.P2RightPoints;
        }
    }

    private void Update()
    {
        //if (isMove)
        //    transform.Translate(Time.smoothDeltaTime * speed * Vector3.left);

        if(isMove && isDie == false)
        {
            if(isLeftView == false)
            {
                TargetTrace(leftPoints);
            }
            else
            {
                TargetTrace(rightPoints);
            }
        }

    }

    //public void EnemyAffiliation(Player _player) // 적이 어느플레이어에 소속이 되는지
    //{
    //    player = _player;
    //}
    void TargetTrace(Transform[] target)
    {
        float distance = Vector2.Distance(target[index].position, transform.position);

        Vector3 dir = (target[index].position - transform.position).normalized;

        transform.position += dir * Time.deltaTime * speed;
        if (distance < 0.3f)
        {
            transform.position = target[index].position;
            index++;
            isMove = false;
        }
    }

    public void RightOrLeft(bool isView)
    {
        isLeftView = isView;
    }

    public void EnemyMove() // 적 움직이는 코드 
    {
        if (isDie && isMove)
            return;

        isMove = true;
    //    StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        isMove = true;
        yield return new WaitForSeconds(0.1f);
        isMove = false;
    }

    IEnumerator RotateAndPush()
    {
        i = Random.Range(0, 3);
        if (isLeftView == false)
            x = -10;
        else
            x = 10;
        while (true)
        {
            transform.localPosition += new Vector3(x, y[i], 0) * Time.deltaTime;
            transform.Rotate(0, 0, -30);

            yield return null;
        }
    }

    IEnumerator MoveAnimation()
    {
        if (moveCount == 0)
            spriteRender.sprite = moveSprites[0];
        else
            spriteRender.sprite = moveSprites[2];

        moveCount++;
        yield return new WaitForSeconds(0.05f);
        spriteRender.sprite = moveSprites[1];
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.transform.parent.GetComponent<Game7Player>() != null) // 현재 충돌하는 콜라이더 면의 부모가 Game7Player스크립트가 있는지 확인 < 예외처리 >
        { 
            Game7Player clone = col.transform.parent.GetComponent<Game7Player>(); // clone 더미를 넣음
            isDie = true;
            boxCollder.enabled = false;

            if (clone.player == Player.P1) // 
            {
                if (col.transform.name == "AttackHit")
                {
                    StartCoroutine(RotateAndPush());
                    Destroy(this.gameObject, 2.0f);
                    game7Data.Player1ScoreGet(1); // 증가
                }
                else if(col.transform.name == "DieHit")
                {
                    if (isLeftView == false)
                    {
                        clone.LeftDamage();
                    }
                    else
                        clone.RightDamage();

                    game7Data.Player1ScoreGet(-2); // 감소
                    DieEffect();
                }
            }
            else if (clone.player == Player.P2) // 
            {
                if (col.transform.name == "AttackHit")
                {
                    StartCoroutine(RotateAndPush());
                    Destroy(this.gameObject, 2.0f);
                    game7Data.Player2ScoreGet(1); // 증가
                }
                else if(col.transform.name == "DieHit")
                {
                    if (isLeftView == false)
                    {
                        clone.LeftDamage();
                    }
                    else
                        clone.RightDamage();

                    game7Data.Player2ScoreGet(-2); // 감소
                    DieEffect();
                }
            }

            Destroy(gameObject, 2.0f);
        }
        else if(col.transform.parent.GetComponent<Game7Player>() == null)
            Debug.LogWarning("버그!!!");
    }

    private void DieEffect()
    {
        GameObject clone = Instantiate(dieEffect);
        clone.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }



}
