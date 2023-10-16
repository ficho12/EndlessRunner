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

    public float frequency;
    public float amplitude;
    private bool isMovingRight;
    public float spawnInterval;
    private Rigidbody rb;
    private bool coll = false;


    void Start()
    {
        sinCenterX = transform.position.x;
        rb = GetComponent<Rigidbody>();
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        player = GameObject.FindWithTag("Player"); // Asegúrate de que el jugador tenga el tag "Player"
        isMovingRight = Random.Range(0, 2) == 0; // Determina la dirección inicial aleatoriamente
        //frequency = Random.Range(0.1f, 0.2f); // Frecuencia aleatoria
        //amplitude = Random.Range(0.1f, 0.2f); // Amplitud aleatoria
        spawnInterval = Random.Range(2.0f, 5.0f); // Intervalo de aparición aleatorio
    }

    private void FixedUpdate()
    {
        Vector3 velocity = rb.velocity;
        float sin = Mathf.Sin(transform.position.z * frequency) * amplitude;
        velocity.x = sinCenterX + sin;
        rb.velocity = velocity;
    }

    private void OnTriggerExit(Collider other)
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
