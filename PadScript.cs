using UnityEngine;

public class PadScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigid2d;
    [SerializeField] GameObject ballObject;

    private float padMoveSpeed = 15f;
    private float ballThrowSpeed = 8f;
    private float ballObjectPositionY;
    private float padPositionY = -6f;



    void Update()
    {
        ballObjectPositionY = ballObject.transform.position.y;

        if (ballObjectPositionY > padPositionY) {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.position += new Vector3(-1f, 0f, 0f) * padMoveSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow)) {
                transform.position += new Vector3(1f, 0f, 0f) * padMoveSpeed * Time.deltaTime;
            }
        }
        /*
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += new Vector3(-1f, 0f, 0f) * padMoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += new Vector3(1f, 0f, 0f) * padMoveSpeed * Time.deltaTime;
        }*/

    }

    private void OnCollisionEnter2D(Collision2D collision) {

        float directionX;

        if (Mathf.Round(collision.transform.position.x) == Mathf.Round(transform.position.x)) {
            directionX = 0f;
        } else {
            //directionX = (collision.transform.position.x < transform.position.x) ? -1f : 1f;
            directionX = (collision.transform.position.x < transform.position.x) ? -Random.value : Random.value;
        }

        ballRigid2d.linearVelocity = new Vector2(directionX * ballThrowSpeed, ballThrowSpeed);
    }

}
