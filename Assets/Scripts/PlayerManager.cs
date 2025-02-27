using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer, stoneLayer, soilLayer;

    private bool isSoil, isStone;

    public GameObject arrow;
    private Animator animator;
    private AudioManager audioManager;

    private float stepTime = 0.5f; // Adım sesi süresi
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

    void Update()
    {
        if (GameManager.Instance.isPlayer)
        {
            float moveInput = Input.GetAxis("Horizontal");

            // Yürüme Animasyonu
            if (moveInput != 0)
            {
                spriteRenderer.flipX = moveInput > 0;
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }

            // Hareket
            transform.Translate(Vector2.right * moveInput * speed * Time.deltaTime);

            // Zıplama
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                
            }
        }

        // Yere değip değmediğini kontrol et
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        isStone = Physics2D.OverlapCircle(groundCheck.position, 0.2f, stoneLayer);
        isSoil = Physics2D.OverlapCircle(groundCheck.position, 0.2f, soilLayer);

        arrow.SetActive(GameManager.Instance.isPlayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("LevelEnd"))
        {
            GameManager.Instance.CharacterReachedEnd();
        }
        if (other.CompareTag("Trap"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.CompareTag("Lord"))
        {
            LevelManager.Instance.LoadScene("LordScene");
        }
        if (other.CompareTag("MeetCat"))
        {
            LevelManager.Instance.LoadScene("MeetCat");
        }
    }
}
