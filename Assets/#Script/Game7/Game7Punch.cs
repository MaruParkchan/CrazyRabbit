using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game7Punch : MonoBehaviour
{
    [SerializeField] private Sprite[] effectHits;
    [SerializeField] private Game7Shake game7Shake;
    [SerializeField] private AudioClip[] sounds;

    private AudioSource audio;
    private SpriteRenderer spriteRender;
    private BoxCollider2D boxCliider;
    private int index = 0;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        spriteRender = GetComponent<SpriteRenderer>();
        boxCliider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Enemy")
        {
            StartCoroutine(StartEffect());
            StartCoroutine(game7Shake.Shake(0.1f, 0.1f));
        }
    }

    IEnumerator StartEffect()
    {
        if (index > effectHits.Length -1)
            index = 0;

        audio.PlayOneShot(sounds[index]);
        spriteRender.sprite = effectHits[index];
        boxCliider.enabled = false;
        yield return new WaitForSeconds(0.1f);
        spriteRender.sprite = null;
        boxCliider.enabled = true;
        index++;
    }
}
