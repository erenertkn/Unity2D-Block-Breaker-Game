using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Status : MonoBehaviour
{
    [Range(-1f,2f)] [SerializeField] float t=1;
    [SerializeField] float scorePerBlock = 10f;
    [SerializeField] float currentScore = 0f;
    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] bool autoPlay = false;

    Paddle paddle;

    // Start is called before the first frame update
    private void Awake()
    {
        paddle = FindObjectOfType<Paddle>();
        int numberOfGameStatus = FindObjectsOfType<Status>().Length;
        if(numberOfGameStatus>1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

   

    private void Start()
    {
        ChangeScoreText(currentScore);
        Debug.Log("Hi");
    }

    public void IncreaseScore()
    {
        currentScore += scorePerBlock;
        ChangeScoreText(currentScore);
    }

    // Update is called once per frame
    void Update()
    {
        paddle.AutoPaddle(autoPlay);
        Time.timeScale = t;       
    }
    void ChangeScoreText(float score)
    {
        tmp.text = "Score: " + score.ToString();
    }

    public void DestroyThisStat()
    {
        Destroy(gameObject);
    }


}
