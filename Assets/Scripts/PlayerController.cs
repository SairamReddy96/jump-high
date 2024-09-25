using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 60.0f;
    [SerializeField]
    private float jumpSpeed = 10.0f;
    [SerializeField]
    public bool isOnPlatform = true;
    [SerializeField]
    private float fallMultiplier = 2.5f;
    private float xBound = 30.0f;
    [SerializeField]
    private GameObject movementFX;
    [SerializeField] protected ParticleSystem leftFX;
    [SerializeField] protected ParticleSystem rightFX;
    protected Rigidbody2D playerRb;
    [SerializeField]
    protected ParticleSystem deathParticles;
    private Animator playerAnim;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void Update()
    {
        RestrictOnBounds();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("The Spacebar is pressed");
            Jump();
        }       
        //  Debug.Log("Gravity value is " + Physics.gravity);
    }

    void FixedUpdate()
    {
        //Debug.Log("FixedUpdate is running");
        Move();      
    }
    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        PlayMovParticles(horizontalInput);
        Vector3 velocity = new Vector3(horizontalInput * speed, 0, 0);
        transform.Translate(velocity);
    }
    void Jump()
    {
        //Debug.Log("Jump is called");
        if(isOnPlatform)
        {
            BetterJump();
            isOnPlatform = false;
            playerAnim.SetBool("isJumping", true);
            movementFX.SetActive(false);
        }
    }
    void BetterJump()
    {
        playerRb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);

        if(playerRb.linearVelocity.y < 0)
        {
            playerRb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void RestrictOnBounds()
    {
        if(transform.position.x > xBound-9.5f)
        {
            transform.position = new Vector3(xBound - 9.5f, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }
    void PlayerDeath()
    {
        deathParticles.transform.position = transform.position + new Vector3(0, 0, -5.0f);
        deathParticles.Play();
        gameManager.GameOver();
        this.gameObject.SetActive(false);
        Destroy(this.gameObject, 0.5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Ground"))
        {
            playerAnim.SetBool("isJumping", false);
            movementFX.SetActive(true);
            //Debug.Log("Collision!");
        }
        if(collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Enemy"))
        {
            PlayerDeath();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Enemy")) {
            PlayerDeath();
        }
    }
    void PlayMovParticles(float horizontaInput)
    {
        if(horizontaInput < 0 && !rightFX.isPlaying)
        {
            rightFX.Play();
        }
        else if(horizontaInput > 0 && !leftFX.isPlaying)
        {
            leftFX.Play();  
        }
    }
}
