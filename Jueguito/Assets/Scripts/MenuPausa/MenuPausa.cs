using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject botonMenuPausa;
    public AudioSource musicaFondo;

    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        botonMenuPausa.SetActive(true);

        if (musicaFondo != null)
        {
            musicaFondo.Pause(); 
        }
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        botonMenuPausa.SetActive(false);

        if (musicaFondo != null)
        {
            musicaFondo.Play();
        }
    }

    public void Salir()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
