using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing2 : MonoBehaviour
{
    public GameObject player;
    public float speed = 2;
    private Vector2 direction;
    public float rotationSpeed = 30f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        direction = player.transform.position - transform.position;
        direction.Normalize();
    }

    void Update()
    {
        RotateEnemy(); // Llamar al método de rotación
        MoveEnemy(); // Llamar al método de movimiento
    }
    void MoveEnemy()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void RotateEnemy()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime); // Rotación constante en el eje Z
    }
}
