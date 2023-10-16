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
    }

    // Update is called once per frame
    /*
     * Se actualiza el tiempo y se castea a int para representarlo en la interfaz
     */
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)timer;
        timeText.text = "Time: " + seconds.ToString() + " s";
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void SubtractScore()
    {
        score -= 2; 
        scoreText.text = "Score: " + score.ToString();
    }

    /*
     * Se utiliza un solo Canvas para todos los menús por lo cual se activan y desactivan los hijos necesarios para el cambio de menú.
     * Además, se pausan las físicas para que no se siga ejecutando en el fondo mientras se está en el menú.
     * (La pausa de físicas no afecta al funcionamiento de la interfaz)
     */
    public void ChangeUItoEndLevel()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(true);
        transform.GetChild(5).gameObject.SetActive(true);
        transform.GetChild(6).gameObject.SetActive(true);
        Time.timeScale = 0; //Pause: true
        transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = "Time\n" + seconds.ToString() + " s";
        transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Score\n" + score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; //Pause: false
    }

    /*
     * Funcionalidad para cerrar la ventana de juego del editor, si está compilado cierra la aplicación de manera normal
     */
    public void Exit() 
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
