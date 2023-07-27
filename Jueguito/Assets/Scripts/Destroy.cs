using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float tiempoDeEspera;

    void Start()
    {
        Invoke("EliminarObjeto", tiempoDeEspera);
    }

    void EliminarObjeto()
    {
        Destroy(gameObject);
    }
}
