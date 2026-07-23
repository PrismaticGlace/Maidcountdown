using UnityEngine;

public class DisableButton : MonoBehaviour {
    
    //Make this true if you want it to ONLY ENABLE something.
    public bool enableButton;
    
    //Makes the Button a switch that can Enable and Disable
    public bool bothButton;

    //Button Object is what you want to enable/disable
    public GameObject buttonObject;

    public bool pressed;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Interact")) {
            if (bothButton) {
                pressed = !pressed;
                buttonObject.SetActive(pressed);
            }
            else if (enableButton == true) {
                if (pressed == false) {
                    buttonObject.SetActive(true);
                    pressed = true;
                }
            }
            else {
                if (pressed == false) {
                    buttonObject.SetActive(false);
                    pressed = true;
                }
            }
        }
    }
}
