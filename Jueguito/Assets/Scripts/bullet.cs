using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private GameObject floatDamage;

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
                GameObject points = Instantiate(floatDamage, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
                vidaEnemigo.UpdateHealth(-damage); 
            }
            Destroy(gameObject);
        }
    }
}