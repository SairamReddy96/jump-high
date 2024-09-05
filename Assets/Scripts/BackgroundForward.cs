using UnityEngine;

public class BackgroundForward : MonoBehaviour
{
    [SerializeField]
    protected GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (player != null)
            transform.position = new Vector3(transform.position.x, player.transform.position.y);
    }
}