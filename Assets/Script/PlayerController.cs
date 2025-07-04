using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 500f;
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private AudioSource playerAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return; // If the player is dead, do not process further
        }

        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.linearVelocity = Vector2.zero; // Reset velocity before applying jump force
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.linearVelocity.y > 0)
        {
            playerRigidbody.linearVelocity = playerRigidbody.linearVelocity * 0.5f; // Reduce upward velocity on mouse release
        }

        animator.SetBool("Grounded", isGrounded);
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();
        playerRigidbody.linearVelocity = Vector2.zero; // Stop player movement
        isDead = true;

        Gamemanager.instance.OnPlayerDead(); // Notify the game manager that the player has died
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false; // Player is no longer grounded when they leave the ground
    }
}