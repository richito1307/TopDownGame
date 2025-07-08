using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_shooting : MonoBehaviour
{
    [SerializeField] private GameObject proyectil;
    [SerializeField] private Transform puntoDeDisparo;
    [SerializeField] VariableJoystick joystick;
    [SerializeField] public Image recarga;
    [SerializeField] public AudioSource sonidoDisparo;

    [SerializeField] public float tiempoActual = 0f; //Tiempo actual
    [SerializeField] private int disparosRealizados = 0; //Numero actual de disparos realizados
    private bool enRecarga = false;
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        if (player == null)
        {
            Debug.LogError("No se encontró el componente Player.");
        }
    }

    private void FixedUpdate()
    {
        if (enRecarga || player == null) return;

        if (joystick.Horizontal >= 0.5f || joystick.Vertical >= 0.5f ||
            joystick.Horizontal <= -0.5f || joystick.Vertical <= -0.5f)
        {
            Disparar();
        }
    }

    void Disparar()
    {
        var stats = player.stats;
        if (disparosRealizados < stats.disparosAntesRecarga)
        {
            tiempoActual += Time.deltaTime;

            if (tiempoActual >= stats.cadenciaDisparo)
            {
                tiempoActual = 0f;
                GameObject bullet = Instantiate(proyectil, puntoDeDisparo.position, puntoDeDisparo.rotation);
                Destroy(bullet, 1f);
                disparosRealizados++;

                float progresoPorBala = 1f / stats.disparosAntesRecarga;
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
        float tiempoFinalRecarga = tiempoInicioRecarga + player.stats.tiempoRecarga;

        while (Time.time < tiempoFinalRecarga)
        {
            float tiempoActualRecarga = Time.time - tiempoInicioRecarga;
            float progresoRecarga = tiempoActualRecarga / player.stats.tiempoRecarga;
            recarga.fillAmount = 1f - progresoRecarga; 
            yield return null;
        }

        recarga.fillAmount = 1f; 
        disparosRealizados = 0;
        enRecarga = false;
    }
}
