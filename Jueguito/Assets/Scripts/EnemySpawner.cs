using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public float spawnRadius = 10f; // Ajusta el radio del círculo
    public float spawnDistance = 2f; // Ajusta la distancia desde el objeto centra  
    public float initialInterval = 5f;
    public float intervalReduction = 0.1f;
    public float minInterval = 1f;
    private float currentInterval;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentInterval = initialInterval;
        StartCoroutine(SpawnEnemyRandomly());
    }

    private IEnumerator SpawnEnemyRandomly()
    {
        while (true)
        {
            Vector2 randomCirclePos = Random.insideUnitCircle.normalized * spawnRadius;
            Debug.Log(randomCirclePos);
            Vector3 spawnPosition = player.transform.position + new Vector3(randomCirclePos.x, randomCirclePos.y, 0f).normalized * spawnDistance;
            Debug.Log(spawnPosition);

            int randomEnemyType = Random.Range(0, 3); // Genera un número aleatorio entre 0 y 2

            switch (randomEnemyType)
            {
                case 0:
                    Instantiate(enemy1, spawnPosition, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(enemy2, spawnPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(enemy3, spawnPosition, Quaternion.identity);
                    break;
            }

            yield return new WaitForSeconds(currentInterval);

            // Reducir el intervalo cada vez que se genera un enemigo
            if (currentInterval > minInterval)
            {
                currentInterval -= intervalReduction;
            }
        }
    }
}
