using UnityEngine;

public class SeekEnemy : MonoBehaviour {
    public bool foundPlayer;
    public GameObject player;
    public float moveSpeed;
    [SerializeField] private float step;
    [SerializeField] private Rigidbody2D rb;

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
    }
}
