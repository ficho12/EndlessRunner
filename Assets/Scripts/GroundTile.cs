using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject enemyPrefab;
    public bool canSpawnEnemy = true;

    private GroundSpawner groundSpawner;
    private GameObject enemy;
    private bool done = false;
    private GameObject Canvas;
    private UI scriptUI;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        scriptUI = Canvas.GetComponent<UI>();
        groundSpawner = GameObject.FindAnyObjectByType<GroundSpawner>();
        if(Random.Range(0, 2).Equals(0))    //33% Posibilidades de Spawn
            SpawnObstacle();
        if (!groundSpawner.enemySpawned && Random.Range(0, 4).Equals(0) && canSpawnEnemy)  // %20 Posibilidades de Spawn
            SpawnEnemy();
    }

    /*
     * Cuando el jugador avanza hacia la siguiente "casilla" se spawnea una al fondo, además en 2 segundos se elimina la que acaba de pasar. De esta manera se generan infinitamente
     */
    private void OnTriggerExit(Collider other)
    {
        if(!done && other.CompareTag("Player"))
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 2);
            done = true;
        }
    }

    /*
     * Se tienen 3 GameObjects vacios como hijos de cada casilla para usar su transform como lugar de spawn de obstáculos y enemigos
     */

    private void SpawnObstacle ()
    {
        // Elige una posición aleatoria
        int obstacleSpawnIndex = Random.Range(2, 5);

        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawnea el obstáculo en la posición
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    private void SpawnEnemy()
    {
        groundSpawner.enemySpawned = true;
        // Elige una posición aleatoria
        int obstacleSpawnIndex = Random.Range(2, 5);

        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawnea el enemigo en la posición
        enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, transform);
        enemy.GetComponent<Enemy>().PopulateRefs(Canvas,scriptUI,this.groundSpawner);   // Se le pasan las refs a usar para no tener que volver a inicializarlas.
    }

}
