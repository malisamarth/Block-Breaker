using UnityEngine;

public class PadScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBallRigid2d;
    [SerializeField] GameObject playerBallObject;

    public Rigidbody2D AddNewBallRigid2d;
    [SerializeField] GameObject AddNewBallObject;

    public Rigidbody2D AddBlueBallRigid2d;
    [SerializeField] GameObject AddBlueBallObject;

    public Rigidbody2D AddRedBallRigid2d;
    [SerializeField] GameObject AddRedBallObject;

    private float padMoveSpeed = 30f;
    private float ballThrowSpeed = 10f;
    private float playerBallObjectPositionY;
    private float AddNewBallObjectPositionY;
    private float padPositionY = -6f;

    private bool isNewBallActive = false;
    private bool isBlueBallActive = false;
    private bool isRedBallActive = false;

    void Update()
    {
        playerBallObjectPositionY = playerBallObject.transform.position.y;
        padMotion(playerBallObjectPositionY);
    }

     void OnCollisionEnter2D(Collision2D collision) {
        if ( collision.gameObject.name == "Ball" )  {
            ballTrajectory(collision.transform.position.x, playerBallRigid2d);
            Debug.Log("Original ball touched");
        }
        if ( collision.gameObject.tag == "NewBalll" && isNewBallActive ) {
            ballTrajectory(collision.transform.position.x, AddNewBallRigid2d);
            Debug.Log("new new new ball touched");
        }
        if (collision.gameObject.tag == "newBlueBall" && isBlueBallActive) { 
            ballTrajectory(collision.transform.position.x, AddBlueBallRigid2d);
            Debug.Log("Blue Blue new ball touched");
        }
        if (collision.gameObject.tag == "NewRedBall" && isRedBallActive) {
            ballTrajectory(collision.transform.position.x, AddRedBallRigid2d);
            Debug.Log("Red Red new ball touched");
        }
    }

    public void getNewBallRigidBody2dd() {
        AddNewBallRigid2d = GameObject.FindGameObjectWithTag("NewBalll").GetComponent<Rigidbody2D>();
        isNewBallActive = true; ;
        Debug.Log("new ball is active!!");
    }

    public void getBlueBallRigidBody2dd() {
        AddBlueBallRigid2d = GameObject.FindGameObjectWithTag("newBlueBall").GetComponent<Rigidbody2D>();
        isBlueBallActive = true; ;
        Debug.Log("Blue ball is active!!");
    }

    public void getRedBallRigidBody2dd() {
        AddRedBallRigid2d = GameObject.FindGameObjectWithTag("NewRedBall").GetComponent<Rigidbody2D>();
        isRedBallActive = true; ;
        Debug.Log("Red ball is active!!");
    }


    private void ballTrajectory(float collisionPoistionX, Rigidbody2D ballRigid2d) {
        float directionX;

        if (collisionPoistionX == transform.position.x) {
            directionX = 0f;
        } else {
            directionX = (collisionPoistionX < transform.position.x) ? -Random.value : Random.value;
        }

        ballRigid2d.linearVelocity = new Vector2(directionX * ballThrowSpeed, ballThrowSpeed);
    }

    private void padMotion(float ballObjectPositionY) {
        if (ballObjectPositionY > padPositionY) {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.position += new Vector3(-1f, 0f, 0f) * padMoveSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow)) {
                transform.position += new Vector3(1f, 0f, 0f) * padMoveSpeed * Time.deltaTime;
            }
        }
    }

}
