using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Sprite facingForward;
    public Sprite facingLeft;
    public Sprite facingRight;

    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveLeft;
    public KeyCode moveRight;

    public KeyCode abilityKey;
    public KeyCode abilityKey2;

    public bool isPlayerOne;
    public Transform otherPlayer;

    public LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;
    public Transform groundCheck;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool isGrounded;

    public bool abilityActive = false;
    private float abilityTimer = 0f;
    private float cooldownTimer = 0f;
    private const float abilityDuration = 5f;
    private const float cooldown = 10f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (!isGrounded && otherPlayer != null)
        {
            Collider2D otherCol = otherPlayer.GetComponent<Collider2D>();
            if (otherCol != null)
            {
                Collider2D[] hits = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius);
                foreach (Collider2D hit in hits)
                {
                    if (hit == otherCol)
                    {
                        isGrounded = true;
                        break;
                    }
                }
            }
        }

        // Movement
        float moveX = 0f;
        if (Input.GetKey(moveLeft)) moveX = -1f;
        if (Input.GetKey(moveRight)) moveX = 1f;

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        float currentJumpForce = (isPlayerOne && abilityActive) ? jumpForce * 2f : jumpForce;

        if (Input.GetKeyDown(moveUp) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, currentJumpForce);
        }

        // Sprite direction
        if (moveX > 0) spriteRenderer.sprite = facingRight;
        else if (moveX < 0) spriteRenderer.sprite = facingLeft;
        else spriteRenderer.sprite = facingForward;

        // Ability timers
        if (abilityActive)
        {
            abilityTimer -= Time.deltaTime;
            if (abilityTimer <= 0f)
            {
                abilityActive = false;
                cooldownTimer = cooldown;
            }
        }

        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Abilities
        if (cooldownTimer <= 0f && !abilityActive)
        {
            if (isPlayerOne)
            {
                if (Input.GetKeyDown(abilityKey))
                {
                    abilityActive = true;
                    abilityTimer = abilityDuration;
                }
            }
            else
            {
                if (Input.GetKeyDown(abilityKey) && otherPlayer != null)
                {
                    transform.position = otherPlayer.position;
                    cooldownTimer = cooldown;
                }

                if (Input.GetKeyDown(abilityKey2) && otherPlayer != null)
                {
                    otherPlayer.position = transform.position;
                    cooldownTimer = cooldown;
                }
            }
        }
    }
}