using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private Vector3 targetPos;
    [SerializeField] private float speed = 10f;
    [SerializeField] private bool isMovingDown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isMovingDown)
        {
            JumpDown();
        }
        if(isMovingDown)
        {
            MoveDownwards();
        }
    }
    void JumpDown()
    {
        targetPos = transform.position + new Vector3(0, -9.5f, 0);
        isMovingDown = true;
    }
    void MoveDownwards()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
        if(transform.position == targetPos)
        {
            isMovingDown = false;
        }
    }
}
