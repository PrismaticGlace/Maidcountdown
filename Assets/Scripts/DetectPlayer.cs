using UnityEngine;

public class DetectPlayer : MonoBehaviour {

    [SerializeField] private SeekEnemy se;

    void Start() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Found it");
            se.player = collision.gameObject;
            se.foundPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("ogne");
            se.foundPlayer = false;
        }
    }
}
