using UnityEngine;

public class BroomMagic : MonoBehaviour {

    public GameObject hitbox;
    public float timer;
    public float maxTime;


    void Update() {
        timer += Time.deltaTime;

        if (timer > maxTime) {
            Destroy(gameObject);
        }

    }


    public void ActivateHitbox(bool real) {
        if (real) {
            hitbox.SetActive(true);
        }
        else {
            hitbox.SetActive(false);
        }
    }
}
