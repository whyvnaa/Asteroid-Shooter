using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployAsteroids : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 1f;
    //distance from the origin in which asteroids are spawned
    public float spawnDistance = 15f;
    private Vector2 screenBounds;
    void Start()
    {
        //Calculates the rightmost, upmost point of the screen in Worldcoordinates and stores it as a Vector2
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(AsteroidWave());
    }
    
    private void SpawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = CalculateRandomPosition();
    }

    //calculates a random position on a circle of radius spawnDistance around the origin an return it as a Vector2
    private Vector2 CalculateRandomPosition()
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        return new Vector2(Mathf.Cos(angle) * spawnDistance, Mathf.Sin(angle) * spawnDistance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //coroutine that spawns an asteroid every respawnTime seconds
    IEnumerator AsteroidWave()
    {
        while (true){   
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
}
