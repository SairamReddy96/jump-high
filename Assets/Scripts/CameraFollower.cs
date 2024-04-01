using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    protected GameObject player;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private float smoothFollowSpeed = 10f;


    // Update is called once per frame
    void LateUpdate()
    {
        if(player != null)
        {
            Vector3 desiredPosition = new Vector3(transform.position.x, player.transform.position.y + yOffset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothFollowSpeed * Time.deltaTime);
        }
        
    }
   
}
