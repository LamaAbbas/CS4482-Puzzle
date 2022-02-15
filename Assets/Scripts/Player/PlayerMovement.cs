/**
 *      Lama Abbas - 251035313
 *      PlayerMovement Class
 *      Allows multiple movements for character; running, jumping, crouching
 *      4482 App #1
 * 
 * */

using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Initializing variables
    [SerializeField] private float runSpeed = 10;
    [SerializeField] private float crouchSpeed = 5;
    [SerializeField] private float jumpPower = 20;

    private float speed;
    private float wallJumpCooldown;
    private float horizontalInput;

    private SpriteRenderer spriteColour;
    Color lerpedColour = Color.white;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private EndPlatform endPlatform;
    [SerializeField] private EndPhase endPhase;

    // Components
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;


    private void Awake() {
        // Getting components of the character
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteColour = GetComponent<SpriteRenderer>();
    }
    
    private void Update() {

        if (endPhase.EndGame()) {
            anim.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
        }

        if (endPlatform.EndPlatformTriggered()) {
            lerpedColour = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
            spriteColour.color = lerpedColour;
        }

        // Receiving user input for moving left and right, and flipping the character sprite to face correct direction accordingly
        horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput > 0.01f){
            transform.localScale = Vector2.one;
        } else if(horizontalInput < -0.01f){
            transform.localScale = new Vector2(-1, 1);
        }
        
        // For animating, as long as the character is moving, move from idle to running animation
        anim.SetBool("run", horizontalInput != 0);
        // This animation is for jumping
        anim.SetBool("grounded", isGrounded());

        // This determines if the user enables crouching by holding the Control key
        if (Input.GetKey(KeyCode.LeftControl)) {

            Crouch();
            // Set the speed of the character to be at crouch speed
            speed = crouchSpeed;
            transform.localScale = new Vector2(transform.localScale.x, 0.5f);

            if (horizontalInput != 0) {
                anim.SetBool("crouchidle", false);
            }
            if (horizontalInput == 0)
            {
                anim.SetBool("crouchidle", false);
            }
        } else {
            anim.SetBool("crouch", false);
            anim.SetBool("crouchidle", false);
            speed = runSpeed;
        }

        // This determines the ability for the character to jump, and how frequent they can jump walls
        if (wallJumpCooldown > 0.2f) {

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y); // ordinary speed

            if (onWall() && !isGrounded()) {
                body.gravityScale = 1.75f;  // Prevent character from slipping down the wall
                body.velocity = Vector2.zero;
            } else {
                body.gravityScale = 7;
            }

            if (Input.GetKey(KeyCode.Space)) {
                Jump();
            }
        } else {
            // Keep increasing cooldown so that jump is allowed to occur
            wallJumpCooldown += Time.deltaTime;
        }
    }

    // Helper method Jump determines when and how the character jumps
    private void Jump() {
        if (isGrounded()) {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        } else if (onWall() && !isGrounded()) {
            // Allows player to shoot the other direction when not moving left or right (jumps off the wall)
            if(horizontalInput == 0) { 
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 15, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            } else {
                // Allows movement upwards, to climb the wall
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 2, 6);
            }
            //Prevent another jump until 0.2f
            wallJumpCooldown = 0;
        }
    }

    // Helper method Crouch allows the player to crouch, getting smaller and lowering speed
    private void Crouch() {
        if (isGrounded()) {
            body.velocity = new Vector2(crouchSpeed, body.velocity.y);
            if (horizontalInput == 0){
                anim.SetBool("crouchidle", true);
            } else {
                anim.SetBool("crouch", true);
            }
        }
    }

    // Helper method to check if the character is on the ground
    private bool isGrounded() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    // Helper method to check if the character is on the wall
    private bool onWall() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    // Helper method to ensure that the character can only shoot when they're on the ground and not climbing a wall
    public bool canAttack() {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
}
