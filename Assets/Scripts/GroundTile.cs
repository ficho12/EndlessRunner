using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject enemyPrefab;
    GroundSpawner groundSpawner;
    GameObject enemy;
    bool done = false;
    GameObject Canvas;
    UI scriptUI;
    public bool canSpawnEnemy = true;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        scriptUI = Canvas.GetComponent<UI>();
        groundSpawner = GameObject.FindAnyObjectByType<GroundSpawner>();
        //if(Random.Range(0, 5).Equals(0))
            SpawnObstacle();
        if (!groundSpawner.enemySpawned && canSpawnEnemy)  // && Random.Range(0, 5).Equals(0)
            SpawnEnemy();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(!done && other.CompareTag("Player"))
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 2);
            done = true;
        }
    }

    void SpawnObstacle ()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);

        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstacle at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

    }

    void SpawnEnemy()
    {
        groundSpawner.enemySpawned = true;
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);

        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstacle at the position
        enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, transform);
        enemy.GetComponent<Enemy>().PopulateRefs(Canvas,scriptUI,this.groundSpawner);
    }

}
