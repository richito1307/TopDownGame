using UnityEngine;
using UnityEngine.UI;

public class player_motion : MonoBehaviour
{
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Button button;
    [SerializeField] private AudioSource audioDash;
    [SerializeField] private Animator animator;

    private bool isDashing = false;
    private float dashTimer = 0f;
    private float cooldownTimer = 0f;
    private Vector2 movimiento;

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();

        if (player == null)
        {
            Debug.LogError("Componente Player no encontrado en el GameObject.");
            return;
        }

        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

        if (button != null)
        {
            button.onClick.AddListener(StartDash);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartDash();
        }
    }

    private void FixedUpdate()
    {
        if (player == null) return;

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
        var stats = player.stats;

        rb2D.velocity = rb2D.velocity.normalized * stats.velocidadMovimiento * stats.dashMultiplicador;
        dashTimer -= Time.deltaTime;

        if (dashTimer <= 0f)
        {
            isDashing = false;
            rb2D.velocity = Vector2.zero;
            cooldownTimer = stats.dashCooldown;

            if (audioDash != null)
            {
                audioDash.Play();
            }
        }
    }

    private void PerformNormalMovement()
    {
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
        rb2D.velocity = movimiento * player.stats.velocidadMovimiento;
    }

    private void StartDash()
    {
        if (!isDashing && cooldownTimer <= 0f)
        {
            isDashing = true;
            dashTimer = player.stats.dashDuracion;
        }
    }
}

