using System.Collections.Specialized;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;
    public bool enemySpawned = false;
    private GameObject temp;

    public void SpawnTile()
    {
        temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            SpawnTile();
            temp.GetComponent<GroundTile>().canSpawnEnemy = false;
        }
        temp.GetComponent<GroundTile>().canSpawnEnemy = true;

    }
}
