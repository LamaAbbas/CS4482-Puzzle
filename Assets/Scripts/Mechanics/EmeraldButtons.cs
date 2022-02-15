using UnityEngine;

public class EmeraldButtons : MonoBehaviour {

    [SerializeField] private float vertical = 1;
    [SerializeField] private float horizontal = 1;

    [SerializeField] private GameObject Emerald;
    [SerializeField] private GameObject Shine;
    [SerializeField] private GameObject barrier;

    private SpriteRenderer spriteColour;

    private float newX = 0;
    private float newY = 0;
    private float lifetime = 0;
    private float posZ;
    private bool triggered = false;

    private void Start() {
        spriteColour = GetComponent<SpriteRenderer>();
        posZ = Emerald.transform.position.z;
    }

    private void Update() {

        lifetime += Time.deltaTime;

        if (triggered && lifetime > 0.25) {
            spriteColour.color = new Color32(255, 255, 255, 255);

            if (Input.GetKey(KeyCode.X)) {
                lifetime = 0;
                spriteColour.color = new Color32(180, 180, 180, 255);

                newX = Emerald.transform.position.x + horizontal;
                newY = Emerald.transform.position.y + vertical;

                if (newX > 27.30 && newX < 27.40 && newY > -0.15 && newY < -0.05) {
                    barrier.gameObject.SetActive(false);
                    Shine.gameObject.SetActive(true);
                }
                if (newY >= -2.9f && newY <= 3.9f && newX >= 25.35 && newX <= 31.35) {
                    Emerald.transform.position = new Vector3(newX, newY, posZ);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            triggered = false;
            spriteColour.color = new Color32(255, 255, 255, 255);
        }
    }
}
    
