/**
 *      Lama Abbas - 251035313
 *      CameraController Class
 *      Movement of the camera as player embarks through rooms
 *      4482 App #1
 * 
 * */

using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private float speed = 10;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    private void Update() {
        // Moves the position to the center of the rooms
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
    }

    // Helper method for which room the character is entering
    public void MoveToNewRoom(Transform _newRoom) {
        currentPosX = _newRoom.position.x;
    }
}
