using UnityEngine;

public class Interact : MonoBehaviour {

    public float maxTime = 0.25f;
    public float timer = 0f;

    void Update() {
        if (timer >= maxTime) {
            timer = 0f;
            gameObject.SetActive(false);
        }
        else {
            timer += Time.deltaTime;
        }
    }
}
