using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private Player_health Jugador;
    public AudioSource musicaFondo;

    public void Start()
    {
        Jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_health>();
        Jugador.MuerteJugador += ActivarMenu;

    }
    public void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
        if (musicaFondo != null)
        {
            musicaFondo.Pause();
        }
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Inicio()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
