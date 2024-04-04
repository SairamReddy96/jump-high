using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> platformPrefabs;
    [SerializeField]
    protected GameObject player;
    protected CameraShake cameraShake;
    private Vector3 jumpHeight = new Vector3(0, 9.5f, -4);
    [SerializeField]
    private int jumpCount;
    [SerializeField]
    private int platformCount;
    [SerializeField]
    public bool isGameActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpCount = 0;
        platformCount = 0;
        isGameActive = true;
        StartCoroutine(MakePlatformSpawn());
        cameraShake = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
    }

    IEnumerator MakePlatformSpawn()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(2);
            GenerateRandomPlatforms();
        }
    }
    public void GameOver()
    {
        StartCoroutine(cameraShake.ShakeCamera(.4f, .15f));
        isGameActive = false;
    }
    void GenerateRandomPlatforms()
    {
        int randomIndex = Random.Range(0, platformPrefabs.Count);
        GameObject platform = Instantiate(platformPrefabs[randomIndex], jumpHeight, platformPrefabs[randomIndex].transform.rotation);
        //Debug.Log("The platform height is " + jumpHeight);
        jumpHeight = platform.transform.position + new Vector3(0, 9.5f);
        //platformCount++;
    }
}
