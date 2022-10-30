using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public PlayerControls playerControls;
    private InputAction move;

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private float speed = 50f;
    private RaycastHit2D hit;
    Animator animator;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //reset look direction
        animator.SetFloat("vertLook", -1);
        animator.SetFloat("horizontLook", 0);
    }
    private void FixedUpdate()
    {

        //reset moveDelta
        moveDelta = Vector3.zero;
        //read input
        // float x = Input.GetAxisRaw("Horizontal");
        // float y = Input.GetAxisRaw("Vertical");

        //set moveDelta
        moveDelta = move.ReadValue<Vector2>().normalized;

        // if (x > 0)
        //     moveDelta.x = 1;
        // else if (x < 0)
        //     moveDelta.x = -1;
        // if (y > 0)
        //     moveDelta.y = 1;
        // else if (y < 0)
        //     moveDelta.y = -1;

        //set animation
        animator.SetFloat("Speed", moveDelta.sqrMagnitude);

        // hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(BetterSign(moveDelta.x) * Time.deltaTime * speed), LayerMask.GetMask("Creature", "Blocking"));
        // if (hit.collider == null)
        // {
        //     transform.Translate(new Vector3(BetterSign(moveDelta.x) * Time.deltaTime * speed, 0, 0));
        // }
        // hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(BetterSign(moveDelta.y) * Time.deltaTime * speed), LayerMask.GetMask("Creature", "Blocking"));
        // if (hit.collider == null)
        // {
        //     transform.Translate(new Vector3(0, BetterSign(moveDelta.y) * Time.deltaTime * speed, 0));
        // }

        rb.velocity = moveDelta.normalized * speed * Time.deltaTime;


        //set look direction
        if ( moveDelta.x > Mathf.Abs(moveDelta.y))
        {
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("horizontLook", 1);
            animator.SetFloat("vertLook", 0);
        }
        else if (moveDelta.x < -Mathf.Abs(moveDelta.y) )
        {
            animator.SetFloat("Horizontal", -1);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("horizontLook", -1);
            animator.SetFloat("vertLook", 0);
        }
        else if (moveDelta.y > Mathf.Abs(moveDelta.x))
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 1);
            animator.SetFloat("horizontLook", 0);
            animator.SetFloat("vertLook", 1);
        }
        else if (moveDelta.y < -Mathf.Abs(moveDelta.x))
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", -1);
            animator.SetFloat("horizontLook", 0);
            animator.SetFloat("vertLook", -1);
        }
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }
    static int BetterSign(float number)
    {
        return number < 0 ? -1 : (number > 0 ? 1 : 0);
    }
}
