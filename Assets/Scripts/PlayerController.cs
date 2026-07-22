using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, PlayerInputActions.IPlayerActions {
    //Variables
    public float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private PlayerInputActions pia;
    private Animator anim;
    private SpriteRenderer sr;
    [SerializeField] private bool isAttacking;
    public bool isInteract;
    public GameObject interCir;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        pia = new PlayerInputActions();
        pia.Player.SetCallbacks(this);
        pia.Player.Enable();
    }

    public void OnMove(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context) {
        if (context.started) isAttacking = true;
        else if (context.canceled) isAttacking = false;
    }

    public void OnInteract(InputAction.CallbackContext context) {
        if (context.started) isInteract = true;
        else if (context.canceled) isInteract = false;
    }
    
    void FixedUpdate() {
        rb.linearVelocity = moveInput * moveSpeed;
        //Animation here

        if (moveInput.x > 0) sr.flipX = false;
        if (moveInput.x < 0) sr.flipX = true;

        if (isAttacking) {
            //Attacking here
        }

        if (isInteract) {
            interCir.SetActive(true);
        }

    }
}
