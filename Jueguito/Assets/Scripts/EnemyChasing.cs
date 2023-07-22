using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing : MonoBehaviour
{
    public GameObject player;
    public float speed = 2;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
