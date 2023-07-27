using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_detection : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (CompareTag("Player"))
            {
                Player_health healthP = GetComponent<Player_health>();
                EnemyDamage enemyD = other.GetComponent<EnemyDamage>();
                if (healthP != null && enemyD != null)
                {
                    healthP.UpdateHealth(-enemyD.enemyDamage);
                }
            }
        }
    }
}
