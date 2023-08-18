using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_shooting : MonoBehaviour
{
    [SerializeField] private GameObject proyectil;
    [SerializeField] private Transform puntoDeDisparo;
    [SerializeField] VariableJoystick joystick;
    [SerializeField] public float tiempoActual = 0f; //Tiempo actual
    [SerializeField] public float tiempoMaximo = 0.5f; //Cadencia de disparo
    [SerializeField] public int disparosAntesRecarga = 3; // Número de balas
    [SerializeField] public float tiempoRecarga = 2f; // Tiempo de recarga 
    [SerializeField] private int disparosRealizados = 0; //Numero actual de disparos realizados
    private bool enRecarga = false;
    [SerializeField] public Image recarga;
    [SerializeField] public AudioSource sonidoDisparo;


    private void FixedUpdate()
    {
        if (enRecarga) return;

        if (joystick.Horizontal >= .5f || joystick.Vertical >= .5f)
        {
            Disparar();
        }
        else if (joystick.Horizontal <= -.5f || joystick.Vertical <= -.5f)
        {
            Disparar();
        }
    }

    void Disparar()
    {
        if (disparosRealizados < disparosAntesRecarga)
        {
            tiempoActual += Time.deltaTime;

            if (tiempoActual >= tiempoMaximo)
            {
                tiempoActual = 0f;
                GameObject bullet = Instantiate(proyectil, puntoDeDisparo.position, puntoDeDisparo.rotation);
                Destroy(bullet, 1f);
                disparosRealizados++;

                float progresoPorBala = 1f / disparosAntesRecarga;
                recarga.fillAmount -= progresoPorBala;

                if (sonidoDisparo != null)
                {
                    sonidoDisparo.Play();
                }
            }
        }
        else
        {
            StartCoroutine(Recargar());
        }
    }

    IEnumerator Recargar()
    {
        enRecarga = true;
        float tiempoInicioRecarga = Time.time;
        float tiempoFinalRecarga = tiempoInicioRecarga + tiempoRecarga;

        while (Time.time < tiempoFinalRecarga)
        {
            float tiempoActualRecarga = Time.time - tiempoInicioRecarga;
            float progresoRecarga = tiempoActualRecarga / tiempoRecarga;
            recarga.fillAmount = 1f - progresoRecarga; 
            yield return null;
        }

        recarga.fillAmount = 1f; 
        enRecarga = false;
        disparosRealizados = 0;
    }
}
