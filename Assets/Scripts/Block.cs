using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject blockSparklesSFX;
    [SerializeField] AudioClip breakClip;
    Level level;
    Status stat;
    [SerializeField] float maxHits;
    [SerializeField] Sprite[] blockSpriteSequence;

    float timeLeft;
    float totalHits=0;

    private void Awake()
    {
        
    }

    private void Start()
    {
        timeLeft = UnityEngine.Random.Range(1, 20);
        maxHits=blockSpriteSequence.Length+1;
        level = FindObjectOfType<Level>();
        stat = FindObjectOfType<Status>();

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag=="Breakable")
        {
            totalHits++;
            if(maxHits==totalHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
            
        }
        
    }

    private void ShowNextHitSprite()
    {
        if(blockSpriteSequence.Length!=0)
        {
            if (blockSpriteSequence[Convert.ToInt32(totalHits-1)] !=null)
            {
                GetComponent<SpriteRenderer>().sprite = blockSpriteSequence[Convert.ToInt32(totalHits) - 1];
            }
        }
        
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakClip, Camera.main.transform.position);
        Destroy(gameObject);
        TriggerSparklesSFX();
        level.BlockDestroyed();
        stat.IncreaseScore();
    }

    private void TriggerSparklesSFX()
    {
        GameObject sparkles = Instantiate(blockSparklesSFX, transform.position, transform.rotation);
        Destroy(sparkles,2f);
    }

    public void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft<0)
        {            
            timeLeft = UnityEngine.Random.Range(1, 50);
            GetComponent<Animator>().Play("Shining");
        }
        
    }
}
