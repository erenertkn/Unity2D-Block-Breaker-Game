using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] Ball ball;
    bool playAuto;
    float mouse_x,xMin,xMax;
    void Start()
    {
        playAuto = false;
        mouse_x = Input.mousePosition.x;
        SetBoundaries();
    }

    

    void Update()
    {
        if (playAuto == false)
        {
            transform.position=new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -2.5f, 4.5f), transform.position.y);
        }
        else
        {
            transform.position = new Vector2(Mathf.Clamp(ball.transform.position.x, xMin, xMax), transform.position.y);
        }
        //AÇIKLAMA DEFTERDE
        
        // SECOND METHOD
        //transform.position=new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -2.149759f, 2.149759f),transform.position.y);
    }

    public void AutoPaddle(bool isAuto)
    {
        playAuto = isAuto;
    }

    private void SetBoundaries()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }
}
