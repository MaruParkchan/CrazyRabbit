using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G5_Prop : MonoBehaviour
{
    private int propValue;
    public int PropValue
    {
        get { return propValue; }
    }
    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    public void Setting() // 발판 리셋
    {
        ani.SetInteger("Color", propValue);
        ani.SetTrigger("Reset");
    }


    public void ValueReset(int value) // 발판 값넣기
    {
        propValue = value;

    }

    public void AnimationUpdate(int value)
    {
        if (propValue == value)
            ani.SetTrigger("Open");
    }
}
