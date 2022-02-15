using UnityEngine;

public class Button : MonoBehaviour {

    private SpriteRenderer spriteColour;
    private bool isClicked = false;

    private void Start() {
        spriteColour = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.X)) {
            isClicked = true;
            spriteColour.color = new Color32(180, 180, 180, 255);
        }
    }

    public bool ButtonClicked() {
        return isClicked;
    }

}
