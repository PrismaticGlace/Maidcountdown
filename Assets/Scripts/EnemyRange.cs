using UnityEngine;

public class EnemyRange : MonoBehaviour {

    public StaticEnemy se;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            se.target = collision.gameObject;
            se.inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log(other);
        if (other.gameObject.CompareTag("Player")) {
            se.inRange = false;
        }
    }
}
