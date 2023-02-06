using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] astreoidPrefabs;
    [SerializeField] private float secondsBetweenAstreoids = 1.5f;
    [SerializeField] private Vector2 forceRange;

    private Camera mainCamera;

    private float timer;

    void Start() 
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnAstreoid();
            timer+= secondsBetweenAstreoids;
        }
    }

    private void SpawnAstreoid()
    {
        int side = Random.Range(0, 4);
    

        Vector2 spawnPoint= Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch(side)
        {
            case 0:
            //left
                spawnPoint.x = 0f;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1:
            //bottom
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
            case 2:
            //right
                spawnPoint.x = 1f;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 3:
            //up
                spawnPoint.x = Random.value;
                spawnPoint.y = 1f;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject selectedAstreoid = astreoidPrefabs[Random.Range(0, astreoidPrefabs.Length)];

       GameObject astreoidInstace = Instantiate(
                    selectedAstreoid, 
                    worldSpawnPoint, 
                    Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
        
        Rigidbody rb = astreoidInstace.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);

    }
}
