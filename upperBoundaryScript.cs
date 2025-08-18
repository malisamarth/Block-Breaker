using UnityEngine;

public class upperBoundaryScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigid2d;
    private float ballThrowSpeed = 8f;//1.8f;
    //private float upperGravityPush = 1f;

    private void OnCollisionEnter2D(Collision2D collision) {
        //ballRigid2d.linearVelocity = new Vector2(Random.Range(-9, 9) * ballThrowSpeed /** upperGravityPush*/, Random.Range(-1, 1) * ballThrowSpeed * upperGravityPush);
        ballRigid2d.linearVelocity = new Vector2(Random.Range(-1, 1) * ballThrowSpeed, Random.Range(-1, 1) * ballThrowSpeed);
        Debug.Log("upper boudary touched");
    }
}
