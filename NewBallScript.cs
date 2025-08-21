using System.Collections.Generic;
using UnityEngine;

public class NewBallScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigid2d;
    public ScoreManagerScript scoreManagerScript;
    //private int maxLives = 3;
    private float maxBallPositionY = -6f;
    private bool isGameActive = true;
    private float ballThrowSpeed = 10f;

    private void Start() {
        scoreManagerScript = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
    }
    void Update() {

        if (transform.position.y < maxBallPositionY && isGameActive) {
            //spwanBall();
            Destroy(gameObject);
        }
         
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Ceil") {
            Debug.Log("CeilWall");
            ballThrowSpeed = 7f;
            float randX = Random.Range(-0.8f, 0.8f);
            Vector2 dir = new Vector2(randX, -1f).normalized;
            ballRigid2d.linearVelocity = dir * ballThrowSpeed;
        }

        if (collision.gameObject.tag == "LeftWall") {
            Debug.Log("LeftWall");
            ballThrowSpeed = 10f;
            ballRigid2d.linearVelocity = new Vector2(
            ballThrowSpeed,
            Random.Range(-0.8f, 0.8f) * ballThrowSpeed
            );
        }

        if (collision.gameObject.tag == "RightWall") {
            Debug.Log("RightWall");
            ballThrowSpeed = 10f;
            ballRigid2d.linearVelocity = new Vector2(
                -ballThrowSpeed,
                Random.Range(-0.8f, 0.8f) * ballThrowSpeed
            );
        }
    }

    private void spwanBall() {
        transform.position = new Vector2(0, -2.77f);
        ballRigid2d.linearVelocity = Vector2.zero;
    }
}
