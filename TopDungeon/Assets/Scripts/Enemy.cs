using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Experience
    public int xpValue = 1;

    //Logic 
    public float triggerLength = 0.3f;
    public float chaseLength = 1.0f;
    private bool chasing = false;
    private bool collidingWithPlayer = false;
    private Transform playerTransform;
    private Vector3 startingPosition;
    private float enemySpeed = 30f;

    //Hitbox
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];
    private ContactFilter2D filter;

    protected override void Start()
    {
        base.Start();
        playerTransform = GameObject.Find("Player").transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        //Check if player is in range
        if(Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            //Check if player is in trigger range
            chasing = Vector3.Distance(playerTransform.position, startingPosition) < triggerLength;
            //If chasing, move towards player
            if(chasing)
            {
                if(!collidingWithPlayer)
                {
                    //Move towards player
                    UpdateMotor((playerTransform.position - transform.position).normalized, enemySpeed);
                }
            }
            else
            {
                //If not chasing, move back to starting position
                UpdateMotor((startingPosition - transform.position).normalized, enemySpeed);
            }
        }
        else
        {
            //If not chasing, move back to starting position
            UpdateMotor((startingPosition - transform.position).normalized, enemySpeed);
            chasing = false;
        }
        //check for overlaps
        collidingWithPlayer = false;
        hitbox.OverlapCollider(filter, hits);
        for(int i = 0; i < hits.Length; i++)
        {
            if(hits[i] == null)
            {
                continue;
            }
            
            if(hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }
            //cleanup Array
            hits[i] = null;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.xp += xpValue;
        GameManager.instance.ShowText("+" + xpValue + " xp", 30, Color.cyan, transform.position, Vector3.up * 40, 1.0f);
    }
}
