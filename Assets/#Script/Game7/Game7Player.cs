using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game7Player : MonoBehaviour
{
    public Player player;
    [SerializeField] private GameReady gameReady;
    [SerializeField] private Game7Data game7Data;
    [SerializeField] private GameEnd gameEnd;
    [SerializeField] private Sprite leftSpriteIdle;
    [SerializeField] private Sprite[] leftSprites;
    [SerializeField] private Sprite rightSpriteIdle;
    [SerializeField] private Sprite[] rightSprites;
    [SerializeField] private Sprite leftHitDamage;
    [SerializeField] private Sprite rightHitDamage;
    SpriteRenderer spriteRender;
    private int leftCount = 0;
    private int rightCount = 0;
    public float attackDelay;
    public float stunDelay;

    private bool isAttack = false;
    private bool isHit = false;
     
    private KeyCode BKey;
    private KeyCode XKey;

    private void Awake()
    {
        JoyStickKeySetting();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(FirstEnemySpawnLoop());
    }

    private void Update()
    {
        if (gameReady.IsStart && game7Data.isGameEnd == false)
            Key();
    }

    private void Key()
    {
        if (Input.GetKeyDown(XKey) && isAttack == false)
        {
            game7Data.EnemyMoveAndSpawn(player);
            StartCoroutine(LeftAttack(leftSpriteIdle, leftSprites, 0.0f, false));
        }

        else if (Input.GetKeyDown(BKey) && isAttack == false)
        {
            game7Data.EnemyMoveAndSpawn(player);
            StartCoroutine(RightAttack(rightSpriteIdle, rightSprites, 180.0f, true));
        }
    }

    private void CharacterDirection()
    {
        
    }

    IEnumerator LeftAttack(Sprite idleSprite, Sprite[] sprites, float euler, bool flip) // 좌우 Idle , 좌우 [] 순서 , 배열순서
    {
        isAttack = true;

        // 첫줄에 현재 왼쪽 이미지 바로 교체 ( left 3 / right3 )
        spriteRender.sprite = sprites[leftCount];
        spriteRender.flipX = flip;
        transform.rotation = Quaternion.Euler(0, euler, 0);
        yield return new WaitForSeconds(attackDelay);
        spriteRender.sprite = idleSprite;
        leftCount++;
        if (leftCount > 2)
        {
            leftCount = 0;
        }
        isAttack = false;

        // Idle상태 이미지 교체
    }

    IEnumerator RightAttack(Sprite idleSprite, Sprite[] sprites, float euler, bool flip) // 좌우 Idle , 좌우 [] 순서 , 배열순서
    {
        if (isAttack)
            yield return null;

        isAttack = true;
        if (rightCount > 2)
        {
            rightCount = 0;
        }
        // 첫줄에 현재 왼쪽 이미지 바로 교체 ( left 3 / right3 )
        spriteRender.sprite = sprites[rightCount];
        spriteRender.flipX = flip;
        transform.rotation = Quaternion.Euler(0, euler, 0);
        yield return new WaitForSeconds(attackDelay);
        spriteRender.sprite = idleSprite;
        rightCount++;
        if (rightCount > 2)
        {
            rightCount = 0;
        }
        isAttack = false;

        // Idle상태 이미지 교체
    }

    IEnumerator LeftHitDamage() // 맞을시 sprite , 
    {
        spriteRender.sprite = leftHitDamage;
        spriteRender.flipX = false;
        yield return new WaitForSeconds(stunDelay);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        spriteRender.sprite = leftSpriteIdle;
        isAttack = false;
        isHit = false;
    }

    IEnumerator RightHitDamage() // 맞을시 sprite , 
    {
        spriteRender.sprite = leftHitDamage;
        yield return new WaitForSeconds(stunDelay);
        spriteRender.flipX = true;
        transform.rotation = Quaternion.Euler(0, 180.0f, 0);
        spriteRender.sprite = rightSpriteIdle;
        isAttack = false;
        isHit = false;
    }

    IEnumerator FirstEnemySpawnLoop()
    {
        int count = 0;
        while (true)
        {
            if (count > 2)
                yield break;
            game7Data.EnemyMoveAndSpawn(player);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
    }

    public void LeftDamage()
    {
        isHit = true;
        StopAllCoroutines();
        StartCoroutine(LeftHitDamage());
    }

    public void RightDamage()
    {
        isHit = true;
        StopAllCoroutines();
        StartCoroutine(RightHitDamage());
    }


    private void JoyStickKeySetting()
    {
        if (player == Player.P1)
        {
            BKey = KeyCode.Joystick1Button1;
            XKey = KeyCode.Joystick1Button2;
        }
        else if (player == Player.P2)
        {
            BKey = KeyCode.Joystick2Button1;
            XKey = KeyCode.Joystick2Button2;
        }
    }
    


}
