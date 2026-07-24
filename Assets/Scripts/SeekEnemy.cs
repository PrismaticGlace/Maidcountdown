using UnityEngine;

public class SeekEnemy : MonoBehaviour {
    public bool foundPlayer;
    public GameObject player;
    public float moveSpeed;
    [SerializeField] private float step;
    [SerializeField] private Rigidbody2D rb;
    public int health;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if (foundPlayer) {
            step = moveSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        }
        else {
            step = 0;
        }

        if (health <= 0) {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PlayerAttack")) {
            health--;
        }
    }


}
