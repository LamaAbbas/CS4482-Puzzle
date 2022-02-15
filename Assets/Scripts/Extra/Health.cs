/**
 *      Lama Abbas - 251035313
 *      Health Class
 *      Affects player's current health
 *      4482 App #1
 * 
 * */

using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] private float startingHealth;
    private Animator anim;
    public float currentHealth { get; private set; } // Is public for use in other scripts but not for editing within editor
    private bool dead;
    
    private void Awake() {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage) {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);    // Declines the health but not below 0
        if (currentHealth > 0) {
            anim.SetTrigger("hurt");
        } else {
            if (!dead) {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false; // Keep player from ever moving again
                dead = true;
            }
        }
    }

    public void AddHealth(float _value) {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);    // Increases the health but not above 3

    }
}
