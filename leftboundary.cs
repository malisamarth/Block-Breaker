using UnityEngine;

public class leftboundary : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigid2d;

    private float ballThrowSpeed = 8f;

    private void OnCollisionEnter2D(Collision2D collision) {
        ballRigid2d.linearVelocity = new Vector2(ballThrowSpeed, Random.Range(-1, 1) * ballThrowSpeed);
        Debug.Log("left boudary touched");
    }
}
