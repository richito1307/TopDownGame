using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Detection : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (CompareTag("Player"))
            {
                Player_health healthP = GetComponent<Player_health>();
                EnemyDamage enemyD = collision.gameObject.GetComponent<EnemyDamage>();
                if (healthP != null && enemyD != null)
                {
                    healthP.UpdateHealth(-enemyD.enemyDamage);
                }
            }
        }
    }
}
