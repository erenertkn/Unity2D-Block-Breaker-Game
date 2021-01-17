using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisGone : ScreenChanger
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeTheScene();
    }
}
