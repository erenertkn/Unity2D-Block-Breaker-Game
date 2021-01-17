using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush=2f;
    [SerializeField] float yPush=5f;
    [SerializeField] AudioClip[] ballSounds;

    Vector2 distance;
    private bool hasStarted;
    private Rigidbody2D rb;
    float remainingTime=2;
    Vector2 timerLocation;
    bool getYaxis;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BallOnTheLoop", 0f, 1f);
        getYaxis = false;
        timerLocation = transform.position;
        rb = GetComponent<Rigidbody2D>();
        hasStarted = true;
        distance = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SticktheBall();
        LaunchtheBall();
    }

    private void BallOnTheLoop()
    {
        if( Mathf.Abs(timerLocation.x-transform.position.x) <0.1 || Mathf.Abs(timerLocation.y - transform.position.y) < 0.1)
        {
            remainingTime--;
            if(remainingTime<=0)
            {
                getYaxis = true;
                remainingTime = 2;
              
            }
        }
        else
        {
            timerLocation = transform.position;
            remainingTime = 2;
        }
    }

    private void SticktheBall()
    {
        if(hasStarted==true)
        {
            Vector2 paddlepos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
            transform.position = paddlepos + distance;
        }
    }

    private void LaunchtheBall()
    {
        if (Input.GetMouseButton(0) && hasStarted == true)
        {
            rb.velocity = new Vector2(xPush, yPush);
            hasStarted = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasStarted)
        {
            AudioClip audioClip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            GetComponent<AudioSource>().PlayOneShot(audioClip);
            if(getYaxis)
            {
                rb.velocity = new Vector2(xPush, yPush);
                getYaxis = false;
            }
        }
    }
}
