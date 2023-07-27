using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawn;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    void Start()
    {
        InvokeRepeating("Spawn", 2f, 5f);
    }

    private void Spawn()
    {
        int randomEnemyType = Random.Range(0, 3);

        switch (randomEnemyType)
        {
            case 0:
                Instantiate(enemy1, spawn.position, GetRotationToPlayer());
                break;
            case 1:
                Instantiate(enemy2, spawn.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemy3, spawn.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }

    private Quaternion GetRotationToPlayer()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        Vector3 directionToPlayer = playerObject.transform.position - spawn.position;
        float angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(new Vector3(0f, 0f, angleToPlayer));
    }
}
