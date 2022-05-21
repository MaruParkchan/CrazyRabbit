using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    protected float moveSpeed;
    private Vector3 pos;
    protected float xPos;
    public float XPos
    {
        get { return xPos; }
    }
    protected float yPos;
    public float YPos
    {
        get { return yPos; }
    }


    public void Set_Speed(float speed)
    {
        moveSpeed = speed;
    }

    public float Get_Speed()
    {
        return moveSpeed;
    }

    public void Move(Vector3 pos)
    {
        transform.position += Time.deltaTime * moveSpeed * pos;
    }

    public void Move(string horizontal, string vertical)
    {
        xPos = Input.GetAxisRaw(horizontal);
        yPos = Input.GetAxisRaw(vertical);
        pos = transform.position;
        pos.x += xPos * Time.deltaTime * moveSpeed;
        pos.y += yPos * Time.deltaTime * moveSpeed;
        pos.z = -1.0f;
        transform.position += pos;
    }

    public void Move(string horizontal, string vertical, Rigidbody2D rigid)
    {
        xPos = Input.GetAxisRaw(horizontal);
        yPos = Input.GetAxisRaw(vertical);
        pos = transform.position;
        pos.x += xPos * Time.deltaTime * moveSpeed;
        pos.y += yPos * Time.deltaTime * moveSpeed;
        pos.z = -1.0f;
        rigid.MovePosition(pos);
    }

    public void Get_Pos()
    {
        Debug.Log("xPos" + xPos);
        Debug.Log("yPos" + yPos);
    }
}
