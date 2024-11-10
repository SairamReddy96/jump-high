using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMovement : MonoBehaviour
{
    [SerializeField] private float movSpeed = 10.0f;
    private GameManager gameManager;
    [SerializeField] private Transform player;
    [SerializeField] private float buffDist = 75f;
    [SerializeField] private float offset = 25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveUp();
    }
    void MoveUp()
    {
        if(player != null)
        {
            Vector3 playerPos = player.position;
            Vector3 currPos = transform.position;
            Vector3 targetPos = new Vector3(transform.position.x, playerPos.y - offset, transform.position.z);

            transform.position = Vector3.Lerp(currPos, targetPos, getLavaVelocity(playerPos, transform.position) * Time.deltaTime);
        }
        
    }
    float getLavaVelocity(Vector3 playerPos, Vector3 lavaPos)
    {
        float lavaSpeed = 0.5f;
        float distance = Vector3.Distance(lavaPos, playerPos);
        if(distance > buffDist)
        {
            return lavaSpeed * 3f;
        }
        return lavaSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Platform"))
        {
            //Debug.Log("Platform destroyed!");
            StartCoroutine(DestroyPlatform(collider.gameObject));
        }
    }
    IEnumerator DestroyPlatform(GameObject platform)
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(platform);
    }
}

