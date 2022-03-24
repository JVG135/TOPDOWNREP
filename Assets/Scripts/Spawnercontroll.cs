using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction
{
    Up,
    Down
}

public class Spawnercontroll : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate = 1f;
    // Start is called before the first frame update
    private float minX, maxX, minY, maxY;
    public Camera cam;
    public int spawnSide;
    void Start()
    {
        InvokeRepeating("SpawnEnemyRandom", spawnRate, spawnRate);
    }

    void Update()
    {
        cam = Camera.main;
    }

    void SpawnEnemyRandom()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;

        //randomizes spawn between all edges of screen
        spawnSide = Random.Range(0, 4);
        if (spawnSide == 0)
        {
            Instantiate(enemyPrefab, new Vector3(minX - 1, Random.Range(minY, maxY), 0f), Quaternion.identity);
            spawnSide = Random.Range(0, 4);
        }
        else if (spawnSide == 1)
        {
            Instantiate(enemyPrefab, new Vector3(maxX + 1, Random.Range(minY, maxY), 0f), Quaternion.identity);
            spawnSide = Random.Range(0, 4);
        }
        else if (spawnSide == 2)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(minX, maxX), maxY + 1, 0f), Quaternion.identity);
            spawnSide = Random.Range(0, 4);
        }
        else if (spawnSide == 3)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(minX, maxX), minY - 1, 0f), Quaternion.identity);
            spawnSide = Random.Range(0, 4);
        }

        Destroy(enemyPrefab, 15f);
    }
}