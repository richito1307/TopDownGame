using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing : MonoBehaviour
{
    public GameObject player;
    public float speed = 2;

    private float movimientoX;
    private float movimientoY;
    [SerializeField] private Animator animator;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);


        float deltaX = direction.x;
        float deltaY = direction.y;


        // Actualizar los parámetros en el Animator
        animator.SetFloat("MovimientoX", deltaX);
        animator.SetFloat("MovimientoY", deltaY);
    }
}
