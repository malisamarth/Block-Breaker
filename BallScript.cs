using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigid2d;
    public ScoreManagerScript scoreManagerScript;
    private int maxLives = 3;
    private float maxBallPositionY = -6f;
    private bool isGameActive = true;
    private void Start() {
        scoreManagerScript = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
    }
    void Update() { 

        if (transform.position.y < maxBallPositionY && isGameActive) {
            maxLives--;
            scoreManagerScript.removeLive(maxLives);
            if (maxLives == 0) {
                //Debug.Log("gameover");
                isGameActive = false;
                ballRigid2d.gravityScale = 0;
                ballRigid2d.linearVelocity = Vector2.zero;

                scoreManagerScript.addCurrentScoreToHighest(scoreManagerScript.currentScore);
                List<int> highestScoreArray = scoreManagerScript.GethighestScoreArray();
                scoreManagerScript.addingScoreToOver(highestScoreArray);

                scoreManagerScript.gameOver();
            } else {
                spwanBall();
            }
        }

    }

    private void spwanBall() {
        transform.position = new Vector2(0, -2.77f);
        ballRigid2d.linearVelocity = Vector2.zero;
    }
}
