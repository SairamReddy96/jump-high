using UnityEngine;

public class SnowEffectController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 startPos;
    private Vector3 targetPos;
    [SerializeField] float followSpeed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        targetPos = new Vector3(startPos.x, startPos.y + player.position.y, startPos.z);
        transform.position = targetPos;
    }
}
