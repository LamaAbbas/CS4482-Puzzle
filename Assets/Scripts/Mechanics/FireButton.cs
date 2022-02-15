using UnityEngine;

public class FireButton : MonoBehaviour {

    [SerializeField] private GameObject Door;

    private SpriteRenderer spriteColour;
    private bool isClicked = false;

    private void Start() {
        spriteColour = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Fireball") {
            spriteColour.color = new Color32(180, 180, 180, 255);
            Door.gameObject.SetActive(false);
            isClicked = true;
        }
    }

    public bool FireButtonClicked() {
        return isClicked;
    }

}


