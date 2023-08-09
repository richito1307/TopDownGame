using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class RotacionCamara : MonoBehaviour
{
    public GameObject joystick2;
    

    private void Update()
    {

        Vector2 joystickDirection = joystick2.GetComponent<VariableJoystick>().Direction;

        float angle = Mathf.Atan2(joystickDirection.y, joystickDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        angle = Mathf.Repeat(angle, 360f);
        

        if (angle > 90 && angle < 270)
        {
            Vector3 localScale = transform.localScale;
            localScale.y = -Mathf.Abs(localScale.y);
            transform.localScale = localScale;
        }
        else
        {
            Vector3 localScale = transform.localScale;
            localScale.y = Mathf.Abs(localScale.y);
            transform.localScale = localScale;
        }

    }
}
