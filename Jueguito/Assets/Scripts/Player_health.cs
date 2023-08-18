using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_health : MonoBehaviour
{
    [SerializeField] public float vidaMaxima = 10f;
    [SerializeField] public float vidaActual;
    [SerializeField] public Image healthBar;

    public event EventHandler MuerteJugador;

    private void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void UpdateHealth(float cantidad)
    {
        vidaActual += cantidad;
        healthBar.fillAmount = vidaActual / vidaMaxima;

        if (vidaActual <= 0)
        {
            vidaActual = 0;
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
        else if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
    }

    public void UpdateMaxHealth(float cantidad)
    {
        vidaMaxima += cantidad;
        vidaActual += cantidad;

        if (vidaMaxima < 1)
        {
            vidaMaxima = 1;
        }
    }
}
