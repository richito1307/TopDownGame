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
        RotateEnemy(); // Llamar al m�todo de rotaci�n
        MoveEnemy(); // Llamar al m�todo de movimiento
    }
    void MoveEnemy()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void RotateEnemy()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime); // Rotaci�n constante en el eje Z
    }
}
