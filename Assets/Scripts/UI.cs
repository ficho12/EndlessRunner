using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private TMP_Text timeText;
    private TMP_Text scoreText;
    public int score = 0;
    float timer = 0.0f;
    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        timeText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();      //Time Child(0)
        scoreText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();      //Score Child(1)
        scoreText.text = "Score: " + score.ToString();
        //transform.GetChild(2).gameObject.SetActive(false);
        //transform.GetChild(3).gameObject.SetActive(false);
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

    public void changeUItoEndLevel()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Score\n" + score.ToString();
        transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(true);
        Time.timeScale = 0; //Pause
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; //Pause
    }

    public void exit() 
    {
        // save any game data here
        #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
