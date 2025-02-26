using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Sprite Renderer'ı al
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        // Sağa sola dönme kontrolü
        if (moveInput.x > 0)
            spriteRenderer.flipX = false; // Sağ tarafa bak
        else if (moveInput.x < 0)
            spriteRenderer.flipX = true;  // Sol tarafa bak
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded) // Sadece yere değdiğinde zıpla
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);
    }

    private void Update()
    {
        // Yere değip değmediğini kontrol et
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
