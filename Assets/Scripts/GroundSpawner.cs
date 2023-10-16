using System.Collections.Specialized;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    public bool enemySpawned = false;

    private Vector3 nextSpawnPoint;
    private GameObject temp;

    public void SpawnTile()
    {
        temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    /*
     * Se Spawnean un número predefinido de casillas para que de la sensación de infinidad. Se bloquea el spawneo de enemigos en todas menos la última casilla (canSpawnEnemy = false)
     */
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
