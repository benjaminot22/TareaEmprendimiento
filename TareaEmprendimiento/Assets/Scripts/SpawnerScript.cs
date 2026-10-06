using UnityEngine;
using UnityEngine.VFX;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 1f;

    public float timeUntilObstacleSpawn;


    private void Update()
    {
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
        { Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void Spawn() 
    { GameObject ObstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

      GameObject spawnedObstacle = Instantiate(ObstacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.linearVelocity = Vector2.left * obstacleSpeed;
    
    }

}
