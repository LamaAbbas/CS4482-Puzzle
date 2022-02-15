/**
 *      Lama Abbas - 251035313
 *      Enemies_Side Class
 *      Moves the trap side by side and deals damage
 *      4482 App #1
 * 
 * */

using UnityEngine;

public class Enemies_Side : MonoBehaviour {

    [SerializeField] private float damage;
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;

    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    // Moves a specified distance and turns
    private void Awake() {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    private void Update() {
        if (movingLeft) {
            if (transform.position.x > leftEdge) {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            } else{
                movingLeft = false;
            }
        } else {
            if (transform.position.x < rightEdge) {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
