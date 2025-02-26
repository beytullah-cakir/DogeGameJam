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
    [SerializeField] private LayerMask groundLayer, stoneLayer, soilLayer;

    private bool isSoil, isStone;

    public GameObject arrow;
    private Animator animator;
    private AudioManager audioManager;

    private float stepTime = 0.5f;  // Adım sesi süresi
    private float stepTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        audioManager = AudioManager.Instanse;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (GameManager.Instance.isPlayer)
        {
            if (moveInput.x > 0)
                spriteRenderer.flipX = true;
            else if (moveInput.x < 0)
                spriteRenderer.flipX = false;

            animator.SetBool("isWalking", moveInput.x != 0);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded && GameManager.Instance.isPlayer)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isPlayer)
        {
            transform.Translate(new Vector2(moveInput.x * speed * Time.deltaTime, 0));

            // Eğer yürüyorsa ve zemindeyse adım sesi çal
            if (isGrounded && moveInput.x != 0)
            {
                stepTimer -= Time.deltaTime;
                if (stepTimer <= 0f)
                {
                    PlayStepSound();
                    stepTimer = stepTime;
                }
            }
        }
    }

    private void Update()
    {
        // Yere değip değmediğini kontrol et
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        isStone = Physics2D.OverlapCircle(groundCheck.position, 0.2f, stoneLayer);
        isSoil = Physics2D.OverlapCircle(groundCheck.position, 0.2f, soilLayer);

        arrow.SetActive(GameManager.Instance.isPlayer);
    }

    private void PlayStepSound()
    {
        if (isStone)
            audioManager.PlayStoneStep();
        else if (isSoil)
            audioManager.PlaySoilStep();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            LevelManager.Instance.LoadScene("Game");
        }
    }
}
