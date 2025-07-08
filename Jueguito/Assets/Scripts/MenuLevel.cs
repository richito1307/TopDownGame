using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLevel : MonoBehaviour
{
    [SerializeField] private GameObject menuLevel;
    public AudioSource musicaFondo;

    public void LevelPausa()
    {
        Time.timeScale = 0f;
        menuLevel.SetActive(true);

        if (musicaFondo != null)
        {
            musicaFondo.Pause();
        }
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        menuLevel.SetActive(false);

        if (musicaFondo != null)
        {
            musicaFondo.Play();
        }
    }
}
