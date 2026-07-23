using UnityEngine;

public class PatrolEnemy : MonoBehaviour {

    public float moveSpeed;
    [SerializeField] private float step;
    public Vector2[] destinations;
    public int currDes;

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
    }

    //void OnCollisionEnter(Collision collision) {
    //    if (collision.gameObject.CompareTag("Wall")) {
    //        currDes++;
    //        step = 0;
    //        if (currDes > (destinations.Length -1)) {
    //            currDes = 0;
    //        }
    //    }
    //}
}
