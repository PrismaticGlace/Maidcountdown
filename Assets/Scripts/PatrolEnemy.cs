using UnityEngine;

public class PatrolEnemy : MonoBehaviour {

    public float moveSpeed;
    [SerializeField] private float step;
    public Vector2[] destinations;
    public int currDes;
    public int health;

    void Update() {
        step = moveSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, destinations[currDes], step);

        if (transform.position.x == destinations[currDes].x) {
            if (transform.position.y == destinations[currDes].y) {
                currDes++;
                if (currDes > (destinations.Length -1)) {
                    currDes = 0;
                    step = 0;
                }
            }
        }

        if (health <= 0) {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PlayerAttack")) {
            health--;
        }
    }
}
