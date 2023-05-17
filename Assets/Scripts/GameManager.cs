using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text scoreUIText;
    public Text highScoreText;
    public GameObject pauseMenu;
    public int score = 0;
    private int highScore = 0;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "" + highScore.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        scoreUIText.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}