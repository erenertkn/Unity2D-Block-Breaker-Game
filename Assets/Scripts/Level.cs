using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour 
{
    public int numOfBlocks;
    ScreenChanger sc;

    private void Start()
    {
        sc = FindObjectOfType<ScreenChanger>();
        CountBreakableBlocks();
    }
    public void CountBreakableBlocks()
    {
        numOfBlocks=GameObject.FindGameObjectsWithTag("Breakable").Length;
    }
    public void BlockDestroyed()
    {
        numOfBlocks--;
        if(numOfBlocks<=0)
        {
            sc.ChangeTheScene();
        }
    }


}
