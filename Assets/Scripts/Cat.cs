using UnityEngine;
using UnityEngine.InputSystem;

public class Cat : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    public GameObject arrow;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Sprite Renderer'ı al
        animator = GetComponent<Animator>(); // Animator bileşenini al
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (!GameManager.Instance.isPlayer)
        {
            if (moveInput.x > 0)
                spriteRenderer.flipX = false;
            else if (moveInput.x < 0)
                spriteRenderer.flipX = true;

            animator.SetBool("isWalking", moveInput.x != 0);
        }

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded && !GameManager.Instance.isPlayer)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.isPlayer)
            transform.Translate(new Vector2(moveInput.x * speed * Time.deltaTime, 0));
    }

    private void Update()
    {
        // Yere değip değmediğini kontrol et
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        arrow.SetActive(!GameManager.Instance.isPlayer);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LevelEnd"))
        {
            GameManager.Instance.CharacterReachedEnd();
        }
    }
}
