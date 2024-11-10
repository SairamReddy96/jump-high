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
    private float smoothFollowSpeed = 2f;


    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {

        if (player != null)
        {
            float targetOffset = player.transform.position.y > 20 ? 1.05f : 5;
            yOffset = Mathf.Lerp(yOffset, targetOffset, smoothFollowSpeed * Time.deltaTime);
            Vector3 desiredPosition = new Vector3(transform.position.x, player.transform.position.y + yOffset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothFollowSpeed * Time.deltaTime);
        }
    }
}
