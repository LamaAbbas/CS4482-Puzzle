using System.Linq;
using UnityEngine;

public class PlatformSequence : MonoBehaviour {

    [SerializeField] private GameObject Door; 

    private float posX;
    private float posY;
    private float posZ;

    [SerializeField] private int digit = 1;

    static int[] solution = { 3, 1, 2, 4, 5 };
    private static int[] input = { -1, -1, -1, -1, -1 };

    private void Start() {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        float newY = posY - 0.1f;
        transform.position = new Vector3(posX, newY, posZ);

        input[0] = input[1];
        input[1] = input[2];
        input[2] = input[3];
        input[3] = input[4];
        input[4] = digit;

        if (Enumerable.SequenceEqual(solution, input)) {
            Door.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        transform.position = new Vector3(posX, posY, posZ);
    }
}
