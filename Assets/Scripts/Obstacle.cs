using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que representa un obstáculo en el juego.
/// </summary>
public class Obstacle : MonoBehaviour
{
    private GameObject Canvas;
    private UI scriptUI;
    private bool coll = false;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        scriptUI = Canvas.GetComponent<UI>();
    }

    /*
     * Si el jugador se choca con el obst�culo se restan puntos scriptUI.SubstractScore()
     */
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && (scriptUI != null) && (coll == false))
        {
            scriptUI.SubtractScore();
            Debug.Log("OnCollisionEnter substractScore");
            coll = true;    
        }
    }
}
