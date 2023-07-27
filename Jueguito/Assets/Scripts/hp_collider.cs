using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_collider : MonoBehaviour
{
    [SerializeField] private float hp;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player_health hpPlayer = other.GetComponent<Player_health>();
            if (hpPlayer != null)
            {
                hpPlayer.UpdateHealth(hp);
            }
            Destroy(gameObject);
        }
    }
}
