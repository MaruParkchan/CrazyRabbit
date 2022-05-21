using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Normal , Water
}
public class Game3Item : MonoBehaviour
{
    [SerializeField] private ItemType itemType;
    private CircleCollider2D col;
    private Animator animator;

    private void Awake()
    {
        col = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        animator.speed = Random.Range(0.5f, 1.0f);
        col.enabled = false;
        ItemCheck();
    }

    public void ItemCheck()
    {
        if (itemType == ItemType.Normal)
            animator.Play("G3_BOX");
        else if (itemType == ItemType.Water)
            animator.Play("G3_BOX_Water");               
    }

    public void OnCollider()
    {
        col.enabled = true;
    }
}
