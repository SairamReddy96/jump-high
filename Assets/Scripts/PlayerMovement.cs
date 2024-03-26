using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 60.0f;
    [SerializeField]
    private float jumpSpeed = 10.0f;
    [SerializeField]
    private bool isOnPlatform = true;
    [SerializeField]
    private float gravityModifier = 0.5f;
    protected Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        //Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();
    }
    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 velocity = new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);
        transform.Translate(velocity);
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnPlatform == true)
        {
           playerRb.AddForce(Vector3.up * jumpSpeed * Time.deltaTime, ForceMode2D.Impulse);
            isOnPlatform = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            isOnPlatform = true;
            //Debug.Log("Collision!");
        }
    }
}
