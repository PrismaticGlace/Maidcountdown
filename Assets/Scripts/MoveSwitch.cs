using UnityEngine;

public class MoveSwitch : MonoBehaviour {
    //Make this true if you want it to move once and only once. 
    public bool buttonSwitch;

    //Button Object is what you want to enable/disable
    public GameObject switchObject;

    //For moving an object
    public float moveSpeed;
    [SerializeField] private float step;
    //Place the orginal position first
    public Vector2[] positions;
    public Vector2 currPos;
    public int currDes;

    //If the switch has been pressed
    public bool pressed;

    void Update() {
        if (buttonSwitch == true) {
            currDes = 1;
        }
        if (pressed == true) {
            step = moveSpeed * Time.deltaTime;
        }

        if (CheckPosition(currDes) == false && pressed == true) {
            switchObject.transform.position = Vector2.MoveTowards(switchObject.transform.position, positions[currDes], step);
        }
        else {
            pressed = false;
            step = 0;
        }

        currPos.x = switchObject.transform.position.x;
        currPos.y = switchObject.transform.position.y;

    }

    private bool CheckPosition(int des) {
        if (currPos == positions[des]) {
            return true;
        }
        else {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Interact")) {
            if (buttonSwitch == true) {
                pressed = true;
            }
            else {
                if (CheckPosition(currDes) == true) {
                    pressed = true;
                    currDes++;
                    if (currDes > (positions.Length - 1)) {
                        currDes = 0;
                    }
                }
            }
        }
    }
}
