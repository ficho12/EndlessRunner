using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UI : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text scoreText;
    public int score = 0;
    float timer = 0.0f;
    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        timeText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();      //Time Child(0)
        scoreText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();      //Score Child(1)
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)timer % 60;
        timeText.text = "Time: " + seconds.ToString() + " s";
    }

    public void addScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void subtractScore()
    {
        score -= 2; 
        scoreText.text = "Score: " + score.ToString();
    }
}