using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Mover : Fighter
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 0.75f;
    Animator animator;

    protected virtual void Start()
    {
        
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //reset look direction
        animator.SetFloat("vertLook", -1);
        animator.SetFloat("horizontLook", 0);
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        //set moveDelta
        moveDelta = input;

        //set animation
        animator.SetFloat("Speed", moveDelta.sqrMagnitude);

        rb.velocity = moveDelta.normalized * Time.deltaTime;


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
    protected virtual void UpdateMotor(Vector3 input, float speed)
    {
        //set moveDelta
        moveDelta = input;

        //set animation
        animator.SetFloat("Speed", moveDelta.sqrMagnitude);

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
}
