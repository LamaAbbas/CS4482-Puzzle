using UnityEngine;

public class LastDoor : MonoBehaviour {

    [SerializeField] private EndPlatform endPlatform;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Fireball" && endPlatform.EndPlatformTriggered()) {
            gameObject.SetActive(false);
        }
    }

}
