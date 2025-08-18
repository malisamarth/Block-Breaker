using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public Text scoreText;
    private int currentScore = 0;
    public void addScore() {
        currentScore++;
        scoreText.text = currentScore.ToString();
    }
}
