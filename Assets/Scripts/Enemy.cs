using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyPrefab;

    private GameObject player;
    private GroundSpawner groundSpawner;
    private PlayerMovement playerMovement;
    private GameObject Canvas;
    private UI scriptUI;
    private bool trig = false;
    private float sinCenterX;
    private float frequency;
    private float amplitude;
    private Rigidbody rb;
    private bool coll = false;


    void Start()
    {
        sinCenterX = transform.position.x;
        rb = GetComponent<Rigidbody>();
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        player = GameObject.FindWithTag("Player");
        frequency = Random.Range(0.2f, 2f); // Frecuencia aleatoria
        amplitude = Random.Range(2f, 30f); // Amplitud aleatoria
    }

    /*
     * Se crea el movimiento del enemigo de forma sinusoidal, se le aplica la velocidad a su RigidBody
     */
    private void FixedUpdate()
    {
        Vector3 velocity = rb.velocity;
        float sin = Mathf.Sin(transform.position.z * frequency) * amplitude;
        velocity.x = sinCenterX + sin;
        rb.velocity = velocity;
    }

    /*
     * Si el jugador ha superado al enemigo sin chocar se aumenta un punto scriptUI.addScore()
     */

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))  // Comprobación de la colisión
        {
            if((scriptUI != null) && (trig == false))   // Para evitar que entre más de una vez se activa un boolean trig
            {
                scriptUI.AddScore();
                Debug.Log("OnCollisionEnter addScore");
                trig = true;
                Invoke("SelfDestruct", 3);  // En 3 segundos se llama a la función que destruye el enemigo. Se tiene 3 segundos para que el Enemigo se encuentre fuera de pantalla en ese momento.
                // Se podría crear una variable pública para ajustar el tiempo.
            }
        }
    }

    /*
     * Si colisiona con el jugador se realiza el proceso de finalización de partida scriptUI.changeUItoEndLevel()
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player") && (scriptUI != null) && (coll == false))
        {
            scriptUI.ChangeUItoEndLevel();
            coll = true;
        }
    }

    private void SelfDestruct()
    {
        Destroy(this);
    }

    private void OnDestroy()
    {
        groundSpawner.enemySpawned = false;
    }

    public void PopulateRefs(GameObject Canvas,UI scriptUI, GroundSpawner gs)
    {
        this.Canvas = Canvas;
        this.scriptUI = scriptUI;
        this.groundSpawner = gs;
    }
}
