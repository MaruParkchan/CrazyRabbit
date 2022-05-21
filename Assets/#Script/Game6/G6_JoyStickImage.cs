using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G6_JoyStickImage : MonoBehaviour
{
    [SerializeField] private Movement movement;
    //[SerializeField] private Sprite leftSprite;
    //[SerializeField] private Sprite rightSprite;
    //[SerializeField] private Sprite downSprite;
    //[SerializeField] private Sprite upSprite;
    //[SerializeField] private Sprite idleSprite;

    Animator ani;
    //private Image image;

    private void Awake()
    {
        ani = GetComponent<Animator>();  
    }

    private void Update()
    {
        ImageUpdate();
    }

    private void ImageUpdate()
    {
        if (movement.XPos == 0 && movement.YPos == 0)
            ani.Play("G6_P1_Idle");
        else if (movement.XPos > 0.8f && movement.YPos == 0)
            ani.Play("G6_P1_Right");
        else if (movement.XPos < -0.8f && movement.YPos == 0)
            ani.Play("G6_P1_Left");
        else if (movement.XPos == 0 && movement.YPos > 0.8f)
            ani.Play("G6_P1_Up");
        else if (movement.XPos == 0 && movement.YPos < -0.8f)
            ani.Play("G6_P1_Down");
    }
}
