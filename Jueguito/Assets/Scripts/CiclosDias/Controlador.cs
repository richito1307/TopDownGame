using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Controlador : MonoBehaviour
{
    [SerializeField] private Light2D luzGlobal;
    [SerializeField] private CicloDia[] ciclosDia;
    [SerializeField] private float tiempoPorCiclo;

    private float tiempoActualCiclo = 0;
    private float porcentajeCiclo;
    private int cicloActual = 0;
    private int cicloSiguiente = 1;


    private void Start()
    {
        luzGlobal.color = ciclosDia[0].colorCiclo;

    }

    private void Update()
    {
        tiempoActualCiclo += Time.deltaTime;
        porcentajeCiclo = tiempoActualCiclo / tiempoPorCiclo;

        if (tiempoActualCiclo >= tiempoPorCiclo)
        {
            tiempoActualCiclo = 0;

            cicloActual = cicloSiguiente;

            if (cicloSiguiente + 1 > ciclosDia.Length - 1)
            {
                cicloSiguiente = 0;
            }
            else
            {
                cicloSiguiente += 1;
            }
        }
        CambiarColor(ciclosDia[cicloActual].colorCiclo, ciclosDia[cicloSiguiente].colorCiclo);
    }

    private void CambiarColor(Color colorActual, Color siguienteColor)
    {
        luzGlobal.color = Color.Lerp(colorActual, siguienteColor, porcentajeCiclo);
    }
}
