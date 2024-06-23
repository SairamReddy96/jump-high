using UnityEngine;
using UnityEngine.EventSystems;

public class MovePlatform : MonoBehaviour
{
    [SerializeField]
    private float platformVelocity;
    [SerializeField]
    private Vector3 moveDirection = Vector3.right;
    [SerializeField]
    protected GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = moveDirection * platformVelocity * Time.deltaTime;
        transform.Translate(movement);
        
        if(player != null)
        {
            player.transform.position += movement;
        }

        ChangeDirectiononBounds();
    }
    void ChangeDirectiononBounds()
    {
        if (transform.position.x > 12.22f)
        {
            moveDirection = Vector3.left;
        }
        if (transform.position.x < -21.1f)
        {
            moveDirection = Vector3.right;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player = collision.gameObject;
            //collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //collision.transform.SetParent(null);
            player = null;
        }
    }
    public float GetPlatformVelocity()
    {
        return this.platformVelocity;
    }
    public void UpdatePlatformVeclocity(float newSpeed)
    {
        platformVelocity = newSpeed;
    }
}
