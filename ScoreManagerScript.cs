using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public Text scoreText;
    public Text livesRemainingText;
    public Text addingScores;
    public Text highestScore;
    public int currentScore = 0;
    public static List<int> highestScoresArray = new List<int>();

    public GameObject gameOverScreen;

    public void addScore() {
        currentScore++;
        scoreText.text = "Score : " + currentScore.ToString();
    }

    public void addingScoreToOver(List<int> highestScores) {
        addingScores.text = makingStringScores();
        highestScore.text = "Highest Score : " + currentHighestScore().ToString(); ;
    }

    private string makingStringScores() {
        string scoreList = "";
        for (int i = 0; i < highestScoresArray.Count; i++) {
            scoreList += highestScoresArray[i] + "\n";
        }
        Debug.Log(scoreList);
        return scoreList;
    }
    
    private int currentHighestScore() {
        int highestScoreValue = highestScoresArray[0];
        for (int i = 0; i < highestScoresArray.Count; i++) {
            if (highestScoreValue <= highestScoresArray[i]) {
                highestScoreValue = highestScoresArray[i];
            }
        }
        return highestScoreValue;
    }

    public List<int> GethighestScoreArray() {
        return highestScoresArray;
    }

    public void removeLive(int currentRemainingLives) {
        if (currentRemainingLives == 2) {
            livesRemainingText.text = "O O";
        }
        if (currentRemainingLives == 1) {
            livesRemainingText.text = "O";
        }
        if (currentRemainingLives == 0) {
            livesRemainingText.text = " ";
        }
    }

    public void addCurrentScoreToHighest(int currentScore) {
        highestScoresArray.Add(currentScore);
        for ( int i = 0; i < highestScoresArray.Count; i++ ) {
            Debug.Log("Index " + i + " : " + highestScoresArray[i]);
        }
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
    }
}
