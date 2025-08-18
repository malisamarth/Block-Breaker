using UnityEngine;

public class EnemySceneScript : MonoBehaviour {
    private int currentBoxCount = 18;
    private int allBoxesClearCount = 0;
    private bool isEmptyBoxes = false;
    float timer = 0;

    public GameObject prefab;

    private void Start() {
        Instantiate(prefab, transform.position, transform.rotation);
    }
    public void boxRemoved() {
        currentBoxCount--;
        if (currentBoxCount == allBoxesClearCount) {
            isEmptyBoxes = true;
        }
        Debug.Log("one object removed : " + currentBoxCount);
    }

    private void Update() {
        if (currentBoxCount == allBoxesClearCount && isEmptyBoxes) {

            
            if (timer * 2 > Time.deltaTime) {
                Instantiate(prefab, transform.position, transform.rotation);
                isEmptyBoxes = false;
                currentBoxCount = 18;
                timer = 0;

            } else {
                timer += Time.deltaTime;
            }

        }
    }

}
