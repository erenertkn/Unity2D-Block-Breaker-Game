using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public enum BlockList{
    grey=1,
    orange,
    red,
    blue,
    golden

}
public class Blocknew : MonoBehaviour
{
    public int maxHit;
    private int totalHit;
    public bool unbreakable;
    public BlockList block;

    private Level level;
    
    private void Start()
    {
        level = FindObjectOfType<Level>();
    }

    public void setBreakable(bool isUnbreakable)
    {
        tag = isUnbreakable?"Unbreakable":"Breakable";
    }
    
    public void setSprite(BlockList val)
    {
        GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("anim_"+val);
        GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("block_"+val)[0];
        maxHit = (int)val;
        Debug.Log(val);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag=="Breakable")
        {
            totalHit++;
            if(maxHit==totalHit)
            {
                Destroy(gameObject);
            }
            else
            {
                BlockList b = (BlockList)(maxHit-totalHit);
                Debug.Log(b);
                
                GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("block_"+b)[0];
                
            }
            
        }
    }
    
  
}


