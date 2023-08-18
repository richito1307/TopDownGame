using UnityEngine;
using UnityEngine.UI;

public class player_motion : MonoBehaviour
{
    [SerializeField] private float motionSpeed;
    [SerializeField] private float dashSpeedMultiplier;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Button button;
    [SerializeField] public AudioSource audioDash;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float cooldownTimer = 0f;
    [SerializeField] private Animator animator;
    private Vector2 movimiento;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        button.onClick.AddListener(StartDash);
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            PerformDash();
        }
        else
        {
            PerformNormalMovement();
        }

        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    private void PerformDash()
    {
        // Realizar el dash
        rb2D.velocity = rb2D.velocity.normalized * motionSpeed * dashSpeedMultiplier;
        dashTimer -= Time.deltaTime;

        if (dashTimer <= 0f)
        {
            // Terminar el dash
            isDashing = false;
            rb2D.velocity = Vector2.zero;

            // Iniciar el cooldown
            cooldownTimer = dashCooldown;

            if (audioDash != null)
            {
                audioDash.Play(); 
            }
        }
    }

    private void PerformNormalMovement()
    {
        // Movimiento normal
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal") + joystick.Horizontal;
        float movimientoVertical = Input.GetAxisRaw("Vertical") + joystick.Vertical;
        animator.SetFloat("MovimientoX", movimientoHorizontal);
        animator.SetFloat("MovimientoY", movimientoVertical);

        if (movimientoHorizontal != 0 || movimientoVertical != 0)
        {
            animator.SetFloat("UltimoX", movimientoHorizontal);
            animator.SetFloat("UltimoY", movimientoVertical);
        }
        movimiento = new Vector2(movimientoHorizontal, movimientoVertical).normalized;
        rb2D.velocity = movimiento * motionSpeed;

    }

    private void StartDash()
    {
        if (!isDashing && cooldownTimer <= 0f)
        {
            // Comenzar el dash
            isDashing = true;
            dashTimer = dashDuration;
        }
    }
}
