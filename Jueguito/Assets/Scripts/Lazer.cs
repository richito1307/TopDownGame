using System.Collections;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private Color targetColor = new Color(1f, 1f, 1f, 1f); // Color con opacidad máxima (alfa = 1)
    public float delay1 = 2f; // Retraso inicial en segundos
    public float delay2 = 1f; // Retraso final en segundos 
    public AudioSource sonido;
    


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        StartCoroutine(OpacityIncreaseAndColliderActivation());
    }

    IEnumerator OpacityIncreaseAndColliderActivation()
    {
        // Esperar 2 segundos antes de aumentar la opacidad y activar el BoxCollider2D
        yield return new WaitForSeconds(delay1);

        if (sonido != null)
        {
            sonido.Play();
        }

        // Aumentar la opacidad a 255 de golpe y activar el BoxCollider2D
        spriteRenderer.color = targetColor;
        boxCollider.enabled = true;

        // Esperar 2 segundos antes de disminuir la opacidad
        yield return new WaitForSeconds(1f);

        // Disminuir la opacidad gradualmente durante 2 segundos hasta llegar a 0
        boxCollider.enabled = false;
        float startTime = Time.time;
        Color startColor = targetColor;

        while (Time.time - startTime <= delay2)
        {
            float t = (Time.time - startTime) / delay2;
            Color newColor = Color.Lerp(startColor, new Color(1f, 1f, 1f, 0f), t);
            spriteRenderer.color = newColor;
            yield return null;
        }

        // Garantizar que la opacidad sea exactamente 0 al final del bucle
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);

        // Destruir el objeto al final del proceso
        Destroy(gameObject);
    }
}
