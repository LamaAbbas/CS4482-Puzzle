/**
 *      Lama Abbas - 251035313
 *      Healthbar Class
 *      Displays the total and current health of the player
 *      4482 App #1
 * 
 * */

using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start() {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;    // Divided by 10 for the Fill Amount variable
    }
    private void Update() {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
