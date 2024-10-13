using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoremanager : MonoBehaviour
{
    public GameObject scoreBoard;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI highScoreText;

    public Image medal;

    public Sprite[] medals;

    

    public void ShowScoreBoard(int score)
    {
        scoreBoard.SetActive(true);
        scoreText.text = score.ToString("0000");


        var hightScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > hightScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            highScoreText.text = score.ToString("0000");
            medal.sprite = medals[0];
        }
        else
        {
            highScoreText.text = hightScore.ToString("0000");
            medal.sprite = medals[1];
        }
    }
}
