using UnityEngine;
using TMPro;
using System.Diagnostics;

public class MenuHighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;

    void Start()
    {
        int savedHighScore = PlayerPrefs.GetInt("SavedHS", 0);
        highscoreText.text = "highscore: " + savedHighScore;
    }
}