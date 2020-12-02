using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blocksparkle;
    [SerializeField] int TimesHit = 0;
    [SerializeField] Sprite[] Hitsprites;


    Level level;
    
    
    private void Start()
    {

        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag =="Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        TimesHit++;
        int MaxHits = Hitsprites.Length + 1;
        if (TimesHit >= MaxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int SpriteIndext = TimesHit - 1;
        if (Hitsprites[SpriteIndext] != null)
        {
            GetComponent<SpriteRenderer>().sprite = Hitsprites[SpriteIndext];
        }
        else
        {
            Debug.LogError("Block Sprite is missing"+gameObject.name);
        }
        }

    private void DestroyBlock()
    {
        PlaySound();
        Destroy(gameObject, 0.1f);
        level.BlockDestroyed();
        Sparkle();
    }

    private void PlaySound()
    {
        FindObjectOfType<Status>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.2f);
    }

    private void Sparkle()
    {
        GameObject sparkle = Instantiate(blocksparkle,transform.position,transform.rotation);
        Destroy(sparkle, 0.2f);
    }      

}
