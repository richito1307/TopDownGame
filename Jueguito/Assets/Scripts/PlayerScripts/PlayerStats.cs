[System.Serializable]
public class PlayerStats
{
    public float velocidadMovimiento = 5;
    public float dashMultiplicador = 2;
    public float dashDuracion = 0.2f;
    public float dashCooldown = 5;

    public float vidaMaxima = 10f;
    public float vidaActual = 10f;

    public int level = 1;
    public float experience = 0;
    public float experienceRequired = 100;

    public float cadenciaDisparo = 0.5f;
    public int disparosAntesRecarga = 3;
    public float tiempoRecarga = 2f;
}
