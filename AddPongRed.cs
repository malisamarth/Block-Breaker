using UnityEngine;

public class AddPongRed : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigid2d;

    public EnemySceneScript enemyScript;

    public ScoreManagerScript scoreManagerScript;

    private float ballThrowSpeed = 10f;

    public GameObject newRedBallPrefab;

    private bool isNewBallAdded = false;

    public PadScript padScript;

    void Start() {
        ballRigid2d = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
        scoreManagerScript = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
        padScript = GameObject.FindGameObjectWithTag("Pad").GetComponent<PadScript>(); ;
    }

    private void Update() {
        if (isNewBallAdded) {
            isNewBallAdded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("AddRedPongTouched");
        ballThrowSpeed = 6f;
        float randX = Random.Range(-0.8f, 0.8f);
        Vector2 dir = new Vector2(randX, -1f).normalized;
        ballRigid2d.linearVelocity = dir * ballThrowSpeed;

        scoreManagerScript.addScore();

        isNewBallAdded = true;

        Instantiate(newRedBallPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        padScript.getRedBallRigidBody2dd();


    }
}
