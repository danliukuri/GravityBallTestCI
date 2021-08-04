using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static int Score { get; set; }

    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] GameObject highScoreContainer;
    [SerializeField] TextMeshProUGUI highScoreTMP;

    void Awake()
    {
        OutputHighScore();
    }

    void OutputHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (highScore > 0)
        {
            highScoreContainer.SetActive(true);
            highScoreTMP.text = highScore.ToString();
        }
    }

    void LateUpdate()
    {
        scoreTMP.text = Score.ToString();
    }

    public static void TryToSaveScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (Score > highScore)
            highScore = Score;
        if (highScore > 0)
        {
            PlayerPrefs.SetInt("HighScore", highScore);
            Score = 0;
        }
    }
}