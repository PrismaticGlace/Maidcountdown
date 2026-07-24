using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }

}
