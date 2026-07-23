using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, PlayerInputActions.IPlayerActions {
    //Variables
    public float moveSpeed = 2f;


    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector3 playerpos;
    private PlayerInputActions pia;
    private Animator anim;
    private SpriteRenderer sr;
    [SerializeField] private bool isAttacking;
    public bool isInteract;
    public bool canMove;
    public GameObject interCir;
    public GameObject broom;
    public int playerLooking;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        pia = new PlayerInputActions();
        pia.Player.SetCallbacks(this);
        pia.Player.Enable();
    }

    public void OnMove(InputAction.CallbackContext context) {
        if (canMove) {
            moveInput = context.ReadValue<Vector2>();
            if (moveInput == Vector2.down) {
                playerLooking = 0;
            }
            else if (moveInput == Vector2.right) {
                playerLooking = 1;
            }
            else if (moveInput == Vector2.up) {
                playerLooking = 2;
            }
            else if (moveInput == Vector2.left) {
                playerLooking = 3;
            }
        }
        else {
            moveInput = Vector2.zero;
        }
    }

    public void OnAttack(InputAction.CallbackContext context) {
        if (context.started) {
            isAttacking = true;
            //1 = Right, 2 = Up, 3 = Left
            switch (playerLooking) {
                case 1:
                    Instantiate(broom, (playerpos + (Vector3.right * 2)), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(broom, (playerpos + (Vector3.up * 2)), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 3:
                    Instantiate(broom, (playerpos + (Vector3.left * 2)), Quaternion.identity);
                    break;
                default:
                    Instantiate(broom, (playerpos + (Vector3.down * 2)), Quaternion.Euler(0f, 0f, -90f));
                    break;
            }
        }
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
            canMove = false;
            rb.linearVelocity = Vector2.zero;
        }
        else {
            canMove = true;
        }

        if (isInteract) {
            interCir.SetActive(true);
        }

        playerpos.x = transform.position.x;
        playerpos.y = transform.position.y;
    }
}
