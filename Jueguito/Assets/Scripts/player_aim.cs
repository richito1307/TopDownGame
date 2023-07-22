using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_aim : MonoBehaviour
{
    [SerializeField] VariableJoystick joystick;
    [SerializeField] Transform cannon; // Este es el objeto que apuntará al disparar.

    private void Start()
    {
        joystick.gameObject.SetActive(true);
    }
    private void FixedUpdate()
    {
        if (joystick.Direction == Vector2.zero) return;
        float angle = Mathf.Atan2(joystick.Vertical, joystick.Horizontal);
        float angleR = (180 / Mathf.PI) * angle - 90;
        cannon.rotation = Quaternion.Euler(0, 0, angleR); // Aplicar la rotación al cañón en lugar de toda la entidad del jugador.

    }
}
