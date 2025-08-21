

using UnityEngine;

public class EnemySceneScript : MonoBehaviour {
    private int currentBoxCount = 55;
    private int allBoxesClearCount = 0;
    private bool isEmptyBoxes = false;

    public BallScript BallScript;
    public ScoreManagerScript scoreManagerScript;

    public GameObject boxCollageSceneOne;
    public GameObject boxCollageSceneTwo;
    public GameObject boxCollageSceneThree;

    private bool isBoxCollageSceneOneActive = false;
    private bool isBoxCollageSceneTwoActive = false;
    private bool isBoxCollageSceneThreeActive = false;

    private void Start() {

        BallScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();
        scoreManagerScript = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();

        Instantiate(boxCollageSceneOne, transform.position, transform.rotation);
        isBoxCollageSceneOneActive = true;
        isBoxCollageSceneTwoActive = false;
        isBoxCollageSceneThreeActive = false;
    }
    public void boxRemoved() {
        currentBoxCount--;
        Debug.Log("box removed :" + currentBoxCount);
        if (currentBoxCount == allBoxesClearCount) {
            isEmptyBoxes = true;
        }
    }

    private void Update() {
        if (currentBoxCount == allBoxesClearCount && isEmptyBoxes) {
            //Instantiate(boxCollageSceneTwo, transform.position, transform.rotation);

            if (isBoxCollageSceneOneActive && !isBoxCollageSceneTwoActive && !isBoxCollageSceneThreeActive) {
                Instantiate(boxCollageSceneTwo, transform.position, transform.rotation);
                isBoxCollageSceneOneActive = false;
                isBoxCollageSceneTwoActive = true;
                isBoxCollageSceneThreeActive = false;
                BallScript.increaseScore();
                scoreManagerScript.removeLive(3); //But we are adding mf

            } else if (!isBoxCollageSceneOneActive && isBoxCollageSceneTwoActive && !isBoxCollageSceneThreeActive) {
                Instantiate(boxCollageSceneThree, transform.position, transform.rotation);
                isBoxCollageSceneOneActive = false;
                isBoxCollageSceneTwoActive = false;
                isBoxCollageSceneThreeActive = true;
                BallScript.increaseScore();
                scoreManagerScript.removeLive(3); //But we are adding mf

            } else if (!isBoxCollageSceneOneActive && !isBoxCollageSceneTwoActive && isBoxCollageSceneThreeActive) {
                Instantiate(boxCollageSceneOne, transform.position, transform.rotation);
                isBoxCollageSceneOneActive = true;
                isBoxCollageSceneTwoActive = false;
                isBoxCollageSceneThreeActive = false;
                BallScript.increaseScore();
                scoreManagerScript.removeLive(3); //But we are adding mf

            }

            isEmptyBoxes = false;
            currentBoxCount = 18;
            Debug.Log("new Level");
        }
    }
}

