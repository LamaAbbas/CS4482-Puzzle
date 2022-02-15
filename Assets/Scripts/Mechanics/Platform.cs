using UnityEngine;
using TMPro;

public class Platform : MonoBehaviour {

    [SerializeField] private GameObject appearingPlatform1;
    [SerializeField] private GameObject appearingPlatform2;
    [SerializeField] private GameObject appearingPlatform3;

    private float timeLeft1 = 0;
    private float timeLeft2 = 0;
    private float timeLeft3 = 0;

    private float posX, posY, posZ;
    private bool triggered = false;
    private bool exited = false;

    private void Start() {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
    }

    private void Update() {
        if (exited) {
            timeLeft1 += Time.deltaTime;
            timeLeft2 += Time.deltaTime;
            timeLeft3 += Time.deltaTime;

            if (timeLeft1 > 1) {
                timeLeft1 = 0;
                appearingPlatform1.SetActive(false);
            }
            if (timeLeft2 > 2) {
                timeLeft2 = 0;
                appearingPlatform2.SetActive(false);
            }
            if (timeLeft3 > 3) {
                timeLeft3 = 0;
                appearingPlatform3.SetActive(false);
                exited = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {

        triggered = true;
        float newY = posY - 0.1f;
        transform.position = new Vector3(posX, newY, posZ);

        appearingPlatform1.SetActive(true);
        appearingPlatform2.SetActive(true);
        appearingPlatform3.SetActive(true);

        timeLeft1 = 0;
        timeLeft2 = 0;
        timeLeft3 = 0;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        transform.position = new Vector3(posX, posY, posZ);
        exited = true;
    }

    public bool PlatformTriggered() {
        return triggered;
    }
}
