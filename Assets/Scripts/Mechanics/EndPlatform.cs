using System;
using UnityEngine;

public class EndPlatform : MonoBehaviour {

    [SerializeField] private GameObject DarkSide;

    private float posX;
    private float posY;
    private float posZ;
    private bool triggered = false;

    private void Start() {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        float newY = posY - 0.1f;
        transform.position = new Vector3(posX, newY, posZ);
        triggered = true;
        DarkSide.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        transform.position = new Vector3(posX, posY, posZ);
    }

    public bool EndPlatformTriggered() {
        return triggered;
    }
}
