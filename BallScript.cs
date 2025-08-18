using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigid2d;
    void Update()
    {
        if (transform.position.y < -5f) {
            transform.position = new Vector2(0, 0);
            ballRigid2d.linearVelocity = Vector2.zero;
        }
    }
}
