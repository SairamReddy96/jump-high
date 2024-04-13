using UnityEngine;

public class PlatformCounter : MonoBehaviour
{
    private GameManager gameManager;
    private bool hasClimbed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "PlatformTrigger" && !hasClimbed)
        {
            //Debug.Log("Trigger working!");
            gameManager.IncreasePlatformCount();
            hasClimbed = true;
        }
    }
}
