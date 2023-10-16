using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyPrefab;
    private GroundSpawner groundSpawner;
    PlayerMovement playerMovement;

    float sinCenterX;

    GameObject Canvas;
    UI scriptUI;
    private bool trig = false;

    public float speed = 5.0f; // Velocidad relativa a la pista
    public float frequency;
    public float amplitude;
    private bool isMovingRight;
    public float spawnInterval;
    //private float timeSinceLastSpawn;
    private Rigidbody rb;
    private bool coll = false;


    void Start()
    {
        sinCenterX = transform.position.x;
        rb = GetComponent<Rigidbody>();
        //groundSpawner = GameObject.FindGameObjectWithTag("GroundSpawner");
        //groundSpawner = GameObject.FindAnyObjectByType<GroundSpawner>();
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        //Canvas = GameObject.FindGameObjectWithTag("Canvas");
        //scriptUI = Canvas.GetComponent<UI>();
        player = GameObject.FindWithTag("Player"); // Asegúrate de que el jugador tenga el tag "Player"
        isMovingRight = Random.Range(0, 2) == 0; // Determina la dirección inicial aleatoriamente
        //frequency = Random.Range(0.1f, 0.2f); // Frecuencia aleatoria
        //amplitude = Random.Range(0.1f, 0.2f); // Amplitud aleatoria
        spawnInterval = Random.Range(2.0f, 5.0f); // Intervalo de aparición aleatorio
        //timeSinceLastSpawn = 0;
    }

    void Update()
    {

        //if (player == null)
        //{
        //    return; // Si el jugador ya no existe, no se mueve
        //}

        //// Mover el enemigo hacia el jugador en dirección contraria
        //Vector3 movement = Vector3.back * speed * Time.deltaTime;
        //rb.velocity = movement;

        // Mover el enemigo de lado a lado utilizando una ecuación senoidal
        //float offsetX = amplitude * Mathf.Sin(frequency * Time.time);
        //if (isMovingRight)
        //{
        //    rb.position += new Vector3(offsetX, 0, 0);
        //}
        //else
        //{
        //    rb.position -= new Vector3(offsetX, 0, 0);
        //}

        //// Mover el enemigo hacia el jugador en dirección contraria
        //Vector3 movement = Vector3.back * speed * Time.deltaTime;
        //transform.Translate(movement);

        //// Mover el enemigo de lado a lado utilizando una ecuación senoidal
        //float offsetX = amplitude * Mathf.Sin(frequency * Time.time);
        //if (isMovingRight)
        //{
        //    transform.position += new Vector3(offsetX, 0, 0);
        //}
        //else
        //{
        //    transform.position -= new Vector3(offsetX, 0, 0);
        //}

        //// Control de aparición de enemigos
        //timeSinceLastSpawn += Time.deltaTime;
        //if (timeSinceLastSpawn >= spawnInterval)
        //{
        //    // Reiniciar el contador y cambiar la dirección de movimiento
        //    timeSinceLastSpawn = 0;
        //    isMovingRight = !isMovingRight;
        //}
    }

    private void FixedUpdate()
    {
        //Vector3 pos = transform.position;

        //float sin = Mathf.Sin(pos.z * frequency) * amplitude;
        //pos.x = sinCenterX + sin;
        //transform.position = pos;
        Vector3 velocity = rb.velocity;
        float sin = Mathf.Sin(transform.position.z * frequency) * amplitude;
        velocity.x = sinCenterX + sin;
        rb.velocity = velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if((scriptUI != null) && (trig == false))
            {
                scriptUI.addScore();
                Debug.Log("OnCollisionEnter addScore");
                trig = true;
                Invoke("SelfDestruct", 3);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player") && (scriptUI != null) && (coll == false))
        {
            scriptUI.changeUItoEndLevel();
            coll = true;
        }


        //    playerMovement.Die();        // Kill the player
    }

    public void SelfDestruct()
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
