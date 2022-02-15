using UnityEngine;

public class Barrier : MonoBehaviour {

    [SerializeField] Button button;

    private void Update() {
        if (button.ButtonClicked()) {
            gameObject.SetActive(false);
        }
    }
}
