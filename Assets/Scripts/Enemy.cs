using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyPrefab;
    public float minAmplitude = 1f;
    public float maxAmplitude = 3f;
    public float enemySpeed = 5f;
    public float minSpawnFrequency = 1f;
    public float maxSpawnFrequency = 5f;
    public float nextSpawnTime = 0f;

    private bool isPlayerAlive = true;
    private int score = 0;
    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (isPlayerAlive)
        {
            // Controla la generación de enemigos
            //if (Time.time >= nextSpawnTime)
            GameObject.Find("Enemy");
            if (FindObjectsByType(enemyPrefab.GetType(), FindObjectsSortMode.None ) == null)
            {
                Debug.Log("No encontre enemigo");
                SpawnEnemy();

                //nextSpawnTime = Time.time + Random.Range(minSpawnFrequency, maxSpawnFrequency);
            }
            else
            {
                //Debug.Log("Encontre enemigo");

            }

            // Controla la colisión entre el jugador y los enemigos
            Collider playerCollider = player.GetComponent<Collider>();
            Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, 0.5f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Enemy"))
                {
                    // El jugador ha chocado con un enemigo
                    isPlayerAlive = false;
                    Debug.Log("Game Over");
                }
            }
        }
    }

    void SpawnEnemy()
    {
        float amplitude = Random.Range(minAmplitude, maxAmplitude);
        float frequency = Random.Range(0.1f, 1.0f);

        float startX = Random.Range(-amplitude, amplitude);
        Vector3 spawnPosition = new Vector3(startX, 1, player.transform.position.z + 20f);

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Rigidbody enemyRigidbody = newEnemy.GetComponent<Rigidbody>();
        enemyRigidbody.velocity = new Vector3(0, 0, -enemySpeed);

        StartCoroutine(MoveSinusoidal(newEnemy.transform, amplitude, frequency));
    }

    IEnumerator MoveSinusoidal(Transform enemyTransform, float amplitude, float frequency)
    {
        Vector3 originalPosition = enemyTransform.position;

        while (enemyTransform != null)
        {
            float z = originalPosition.z + Mathf.Sin(Time.time * frequency) * amplitude;
            enemyTransform.position = new Vector3(enemyTransform.position.x, enemyTransform.position.y, z);

            yield return null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // El jugador ha esquivado un enemigo y gana un punto
            score++;
            Debug.Log("Puntos: " + score);
            Destroy(other.gameObject); // Elimina el enemigo
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
            playerMovement.Die();        // Kill the player


    }
}
