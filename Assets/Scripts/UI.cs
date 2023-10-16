using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que maneja la interfaz de usuario del juego.
/// </summary>
public class UI : MonoBehaviour
{
    private TMP_Text timeText;
    private TMP_Text scoreText;
    public int score = 0;
    float timer = 0.0f;
    int seconds;

    void Start()
    {
        timeText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();      //Time Child(0)
        scoreText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();      //Score Child(1)
        scoreText.text = "Score: " + score.ToString();
    }
    /// <summary>
    /// Se actualiza el tiempo y se castea a int para representarlo en la interfaz
    /// </summary>
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)timer;
        timeText.text = "Time: " + seconds.ToString() + " s";
    }

    /// <summary>
    /// Añade un punto al puntaje del jugador.
    /// </summary>
    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    /// <summary>
    /// Resta dos puntos al puntaje del jugador.
    /// </summary>
    public void SubtractScore()
    {
        score -= 2; 
        scoreText.text = "Score: " + score.ToString();
    }

    /// <summary>
    /// Cambia la interfaz de usuario al menú de fin de nivel.
    /// Se utiliza un solo Canvas para todos los men�s por lo cual se activan y desactivan los hijos necesarios para el cambio de men�.
    /// Adem�s, se pausan las f�sicas para que no se siga ejecutando en el fondo mientras se est� en el men�.
    /// (La pausa de f�sicas no afecta al funcionamiento de la interfaz)
    /// </summary>
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

    /// <summary>
    /// Reinicia el nivel actual.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; //Pause: false
    }

    /// <summary>
    /// Cierra la aplicación del juego.
    /// </summary>
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
