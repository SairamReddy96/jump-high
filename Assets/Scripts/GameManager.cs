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
    [SerializeField]
    private int jumpCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpCount = 0;
        StartCoroutine(MakePlatformSpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator MakePlatformSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            SpawnRandomPlatforms(player.transform.position);
        }
    }
    void SpawnRandomPlatforms(Vector3 playerPos)
    {
        int randomIndex = Random.Range(0, platformPrefabs.Count);
        GameObject platform = Instantiate(platformPrefabs[randomIndex], playerPos + new Vector3(0,9.3f), platformPrefabs[randomIndex].transform.rotation);
    }

}
