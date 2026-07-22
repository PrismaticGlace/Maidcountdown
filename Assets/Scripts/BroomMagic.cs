using UnityEngine;

public class BroomMagic : MonoBehaviour {

    public GameObject hitbox;

    public void ActivateHitbox(bool real) {
        if (real) {
            hitbox.SetActive(true);
        }
        else {
            hitbox.SetActive(false);
        }
    }
}
