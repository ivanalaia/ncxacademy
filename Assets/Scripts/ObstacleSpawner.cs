using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpowner : MonoBehaviour
{

    public GameObject[] obstaclePrefabs;

    public float spawnTimeMin, spawnTimeMax;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(spawnTimeMin, spawnTimeMax);

    }

    // Update is called once per frame
    void Update()
    {
        SpawnObstacles();
    }
    
    void SpawnObstacles()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            int r = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[r], transform.position, Quaternion.identity);

            timer = Random.Range(spawnTimeMin, spawnTimeMax);
        }

    }
} 
 