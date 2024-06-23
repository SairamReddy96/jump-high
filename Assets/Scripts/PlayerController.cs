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
    private bool isOnPlatform = true;
    [SerializeField]
    private float gravityModifier = 0.5f;
    private float xBound = 30.0f;
    [SerializeField]
    private GameObject movementFX;
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
        
        //  Debug.Log("Gravity value is " + Physics.gravity);
    }
    void FixedUpdate()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }        
    }
    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 velocity = new Vector3(horizontalInput * speed, 0, 0);
        transform.Translate(velocity);
    }
    void Jump()
    {
        //Debug.Log("Jump is called");
        if(isOnPlatform)
        {
            playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
            //Debug.Log("Jumped");
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
}
