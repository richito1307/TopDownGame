using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawn;
    public GameObject enemy;

    void Start()
    {
        InvokeRepeating("Spawn", 2f, 5f);
    }

    private void Spawn()
    {
        Instantiate(enemy, spawn.position, spawn.rotation);
    }
}
