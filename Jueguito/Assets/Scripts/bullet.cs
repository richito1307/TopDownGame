using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health vidaEnemigo = other.GetComponent<Health>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.UpdateHealth(-damage);
                Debug.Log(vidaEnemigo.vidaActual);
            }
                Destroy(gameObject);
        }
    }
}
