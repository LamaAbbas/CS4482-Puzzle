using UnityEngine;
using System.Collections;
using TMPro;

public class ButtonChangeText : MonoBehaviour {

    [SerializeField] TMP_Text canvasText;
    [SerializeField] Button button;
    [SerializeField] Platform platform;
    [SerializeField] FireButton fireButton;

    private float lifetime;

    private void Update() {
        if (button.ButtonClicked()) {
            canvasText.text = "That's a tight spot. Try crouching\n[Hold CTRL to crouch]";
        }
        if (platform.PlatformTriggered()) {
            canvasText.text = "Hurry, the platforms will disappear!\nHow will you reach the button?\n[Try using LEFT MOUSE CLICK]";
        }
        if (fireButton.FireButtonClicked()) {
            lifetime += Time.deltaTime;
            if (lifetime < 5) {
                canvasText.text = "Well, you've got what it takes!\nGood luck on your adventure...";
            }
            if (lifetime > 5) {
                canvasText.text = "";
            }
        }

    }
}
