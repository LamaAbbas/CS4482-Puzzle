/**
 *      Lama Abbas - 251035313
 *      PlayerAttack Class
 *      Determines player's attacks
 *      4482 App #1
 * 
 * */

using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    // Initializing variables
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;   // Location of fireball spawn
    [SerializeField] private GameObject[] fireballs;

    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private PlayerMovement playerMovement;

    private void Awake() {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() {
        // Determining whether the character can start shooting fireballs
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()) {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    // Helper method that shoots projectiles from the arsenal of fireballs
    private void Attack() {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;  // Place an available fireball in front of the character
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));  // Yeet it
    }

    // Helper method that determines if a fireball in array is available (they are set to deactive by default)
    private int FindFireball() {
        for (int i = 0; i < fireballs.Length; i++) {
            if (!fireballs[i].activeInHierarchy) {
                return i;
            }
        }
        return 0;
    }
}
