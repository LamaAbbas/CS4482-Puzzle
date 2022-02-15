using UnityEngine;

public class StayPlatform : MonoBehaviour {

    private float posX;
    private float posY;
    private float posZ;

    [SerializeField] GameObject door;

    private void Start() {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        float newY = posY - 0.1f;
        transform.position = new Vector3(posX, newY, posZ);

        if (collision.tag == "Player") {
            door.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        transform.position = new Vector3(posX, posY, posZ);
        if (collision.tag == "Player") {
            door.gameObject.SetActive(true);
        }
    }
}
