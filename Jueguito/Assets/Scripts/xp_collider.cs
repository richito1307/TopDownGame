using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xp_collider : MonoBehaviour
{
    [SerializeField] private float xp;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Level expPlayer = other.GetComponent<Level>();
            if (expPlayer != null)
            {
                expPlayer.GainExperience(xp);
            }
            Destroy(gameObject);
        }
    }
}
