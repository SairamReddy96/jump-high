using UnityEngine;

public class LavaMovement : MonoBehaviour
{
    [SerializeField] private float movSpeed = 10.0f;
    private GameManager gameManager;

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
        Vector3 currPos = transform.position;
        Vector3 targetPos = currPos + new Vector3(0, 1f, 0);

        transform.position = Vector3.Lerp(currPos, targetPos, movSpeed * Time.deltaTime);
    }
}
