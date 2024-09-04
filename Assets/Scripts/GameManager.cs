using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> platformPrefabs;
    [SerializeField]
    protected GameObject player;
    protected CameraShake cameraShake;
    [SerializeField]
    private TextMeshProUGUI platformText;
    [SerializeField]
    private TextMeshProUGUI highScoreText;
    private Vector3 jumpHeight = new Vector3(0, 10.5f, -4);
    public int platformCount;
    private float prevSpeed = 0f;
    [SerializeField]
    public bool isGameActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platformCount = 0;
        isGameActive = true;
        StartCoroutine(MakePlatformSpawn());
        cameraShake = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    IEnumerator MakePlatformSpawn()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(0.5f);
            GeneratePlatforms();
        }
    }

    void GeneratePlatforms()
    {

    }
    public void GameOver()
    {
        StartCoroutine(cameraShake.ShakeCamera(.4f, .15f));
        isGameActive = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(LoadEndScene());
    }
    IEnumerator LoadEndScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }

    public void IncreasePlatformCount()
    {
        platformCount++;
        platformText.text = "Current Score : " + platformCount;
        UpdateHighScore();
    }
    public void UpdateHighScore()
    {
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0); //default value - if none return 0
        if(platformCount > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", platformCount);
            PlayerPrefs.Save();
            highScoreText.text = "High Score : " + platformCount;
        }
        else
        {
            highScoreText.text = "High Score : "+ currentHighScore;
        }
    }
}
