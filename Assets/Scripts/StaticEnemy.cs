using UnityEngine;

public class StaticEnemy : MonoBehaviour {

    public GameObject projPrefab;
    public GameObject target;
    public bool inRange;
    public float projSpeed;
    [SerializeField] private float shotTimer;
    [SerializeField] private float shotTimerMax;
    public int health;

    void Update() {
        if (shotTimer >= shotTimerMax) {
            if (inRange) {
                Vector2 direction = (target.transform.position - transform.position).normalized;
                float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

                GameObject project = Instantiate(projPrefab, transform.position, rotation);

                Rigidbody2D rb = project.GetComponent<Rigidbody2D>();

                rb.linearVelocity = direction * projSpeed;

                shotTimer = 0;

            }
        }
        else {
            shotTimer += Time.deltaTime;
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

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("PlayerAttack")) {
            health--;
        }
    }

}

