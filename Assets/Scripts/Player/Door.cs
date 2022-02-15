/**
 *      Lama Abbas - 251035313
 *      Door Class
 *      Determines trigger that allows camera to follow character to the next room
 *      4482 App #1
 * 
 * */

using UnityEngine;
using TMPro;

public class Door : MonoBehaviour {

    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;
    [SerializeField] private GameObject door;

    // Detects when character is entering previous or next room through a trigger
    private void OnTriggerEnter2D(Collider2D collision) {
        // Only player can have the camera move
        if (collision.tag == "Player") {
            if(collision.transform.position.x < transform.position.x) {
                // If the position of the player is smaller than the door trigger, then it is to the left and needs to proceed to the right
                cam.MoveToNewRoom(nextRoom);
                
            } else {
                cam.MoveToNewRoom(previousRoom);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            door.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
