using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSequence : MonoBehaviour {

    [SerializeField] public GameObject barrier;
    [SerializeField] public int digit = 1;

    private SpriteRenderer spriteColour;

    static int[] solution = { 4, 2, 3, 1 };
    private static int[] input;
    private static List<int> inputList = new List<int>();

    private float lifetime = 0;
    private static float counter = 0;

    private bool pressed = false;
    private bool cantPress = false;
    private static bool restart = false;
 
    private void Start() {
        spriteColour = GetComponent<SpriteRenderer>();
    }

    private void Update() {

        if (restart) {
            spriteColour.color = new Color32(255, 255, 255, 255);
            inputList.Clear();
            Array.Clear(input, 0, input.Length);
            cantPress = false;
            pressed = false;
            counter++;
        }
        
        if (counter == 4) {
            restart = false;
            counter = 0;
        }

        lifetime += Time.deltaTime;

        if (!cantPress && pressed && lifetime > 0.25) {
            cantPress = true;

            lifetime = 0;
            spriteColour.color = new Color32(180, 180, 180, 255);
            inputList.Add(digit);

            if (inputList.Count == 4) {
                input = inputList.ToArray();
                if (Enumerable.SequenceEqual(solution, input)) {
                    barrier.gameObject.SetActive(false);
                    restart = true;
                } else {
                    restart = true;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.X)) {
            pressed = true;
        } else {
            pressed = false;
        }
    }
}
