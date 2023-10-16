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

    /// <summary>
    /// Actualiza la velocidad del enemigo en cada fixed update para que se mueva en una onda sinusoidal, aplicando la velocidad a su RigidBody.
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 velocity = rb.velocity;
        float sin = Mathf.Sin(transform.position.z * frequency) * amplitude;
        velocity.x = sinCenterX + sin;
        rb.velocity = velocity;
    }

    /// <summary>
    /// Método que se llama cuando un objeto sale del trigger del enemigo. Si el objeto que sale es el jugador, se suma un punto al score y se destruye el enemigo después de 3 segundos.
    /// </summary>
    /// <param name="other">Collider del objeto que sale del trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))  // Comprobaci�n de la colisi�n
        {
            if((scriptUI != null) && (trig == false))   // Para evitar que entre m�s de una vez se activa un boolean trig
            {
                scriptUI.AddScore();
                Debug.Log("OnCollisionEnter addScore");
                trig = true;
                Invoke("SelfDestruct", 3);  // En 3 segundos se llama a la funci�n que destruye el enemigo. Se tiene 3 segundos para que el Enemigo se encuentre fuera de pantalla en ese momento.
                // Se podr�a crear una variable p�blica para ajustar el tiempo.
            }
        }
    }

    /// <summary>
    /// Método que se ejecuta cuando el objeto colisiona con otro objeto.
    /// Si el objeto colisionado es el jugador, el objeto UI no es nulo y la colisión no ha ocurrido antes,
    /// se cambia la interfaz de usuario a la pantalla de fin de nivel.
    /// </summary>
    /// <param name="collision">Información sobre la colisión.</param>
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
