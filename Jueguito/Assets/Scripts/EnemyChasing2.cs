using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing2 : MonoBehaviour
{
    public GameObject player;
    public float speed = 2;
    private Vector2 direction;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        direction = player.transform.position - transform.position;
        direction.Normalize();
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
}
