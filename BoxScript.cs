using UnityEngine;

public class BoxScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigid2d;

    [SerializeField] Rigidbody2D NewBallRigid2d;
    private bool isNewBallActive = false;

    public EnemySceneScript enemyScript;

    public ScoreManagerScript scoreManagerScript;

    

    void Start() {
        ballRigid2d = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
        enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemySceneScript>();
        scoreManagerScript = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
    }

    private float ballThrowSpeed = 5f;
    private void OnCollisionEnter2D(Collision2D collision) {

        Debug.Log("boxTouched");
        ballThrowSpeed = 6f;

        float randX = Random.Range(-0.8f, 0.8f);
        Vector2 dir = new Vector2(randX, -1f).normalized;

        if (collision.gameObject.name == "Ball") {
            ballRigid2d.linearVelocity = dir * ballThrowSpeed;
            Debug.Log("Box touched by Original Ball");
        }
        if (collision.gameObject.tag == "NewBalll" && isNewBallActive) {
            NewBallRigid2d.linearVelocity = dir * ballThrowSpeed;
            Debug.Log("new new new ball touched");
        }

        enemyScript.boxRemoved();
        scoreManagerScript.addScore();
        Destroy(gameObject);
    }

    public void getNewBallRigidBody2dd() {
        NewBallRigid2d = GameObject.FindGameObjectWithTag("newBlueBall").GetComponent<Rigidbody2D>();//AddNewBallObject.GetComponent<Rigidbody2D>();
        isNewBallActive = true; ;
        Debug.Log("new ball is active!!");
    }

}
