using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 60.0f;
    [SerializeField]
    private bool isOnPlatform = false;
    [SerializeField]
    private float gravityModifier = 0.5f;
    [SerializeField]
    private float jumpSpeed = 10.0f;
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
        //Physics.gravity *= gravityModifier;
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
    public void Jump()
    {
        //Debug.Log("Jump is called");
        if(isOnPlatform)
        {
            //Debug.Log("Jumped with force "+ Vector3.up * jumpSpeed);
            playerRb.AddForce(Vector3.up * jumpSpeed , ForceMode2D.Impulse);
            isOnPlatform = false;
            playerAnim.SetBool("isJumping", true);
            movementFX.SetActive(false);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Ground"))
        {
            isOnPlatform = true;
            playerAnim.SetBool("isJumping", false);
            movementFX.SetActive(true);
            //Debug.Log("Collision!");
        }
        if(collision.gameObject.CompareTag("Spike"))
        {
            deathParticles.transform.position = transform.position + new Vector3(0, 0, -5.0f);
            deathParticles.Play();
            gameManager.GameOver();
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 0.5f);
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
