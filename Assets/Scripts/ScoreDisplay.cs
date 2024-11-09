using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currScoretext;
    [SerializeField] private TextMeshProUGUI highScoretext;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int currentScore = PlayerPrefs.GetInt("CurrentScore");
        int highScore = PlayerPrefs.GetInt("HighScore");

        currScoretext.text = "Current Score: "+currentScore;
        highScoretext.text = "High Score: "+highScore;
    }

}
