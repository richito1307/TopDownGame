using System;
using UnityEngine;
using UnityEngine.UI;

public class Player_health : MonoBehaviour
{
    [SerializeField] public Image healthBar;
    public event EventHandler MuerteJugador;
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();

        if (player == null)
        {
            Debug.LogError("No se encontró el componente Player.");
            return;
        }

        player.stats.vidaActual = player.stats.vidaMaxima;
        UpdateHealthBar();
    }

    public void UpdateHealth(float cantidad)
    {
        player.stats.vidaActual += cantidad;

        if (player.stats.vidaActual <= 0)
        {
            player.stats.vidaActual = 0;
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
        else if (player.stats.vidaActual > player.stats.vidaMaxima)
        {
            player.stats.vidaActual = player.stats.vidaMaxima;
        }

        UpdateHealthBar();
    }

    public void UpdateMaxHealth(float cantidad)
    {
        player.stats.vidaMaxima += cantidad;
        player.stats.vidaActual += cantidad;

        if (player.stats.vidaMaxima < 1)
        {
            player.stats.vidaMaxima = 1;
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = player.stats.vidaActual / player.stats.vidaMaxima;
        }
    }
}
