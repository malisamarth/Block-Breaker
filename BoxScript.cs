using UnityEngine;

public class BoxScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigid2d;

    public EnemySceneScript enemyScript;

    public ScoreManagerScript scoreManagerScript;

    private float gravityPush = 1f;

    void Start() {
        ballRigid2d = GameObject.FindGameObjectWithTag("Box").GetComponent<Rigidbody2D>();
        enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemySceneScript>();
        scoreManagerScript = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
    }

    private float ballThrowSpeed = 5f;

    private void OnCollisionEnter2D(Collision2D collision) {

        ballRigid2d.linearVelocity = new Vector2(Random.Range(-1, 1) * ballThrowSpeed /** gravityPush*/, Random.Range(-1, 1) * ballThrowSpeed * gravityPush);
        //Debug.Log("left boudary touched");
        enemyScript.boxRemoved();
        scoreManagerScript.addScore();
        Destroy(gameObject);
    }

}
