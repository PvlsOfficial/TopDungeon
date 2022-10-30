using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : Collidable
{
    public PlayerControls playerControls;
    public InputAction attack;
    //Damage structure
    public int damagePoint = 1;
    public float pushForce = 2f;

    //Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    //Swing
    private float coolDown = 0.5f;
    private float lastAttack = 0f;


    private void Awake()
    {
        playerControls = GameObject.Find("Player").GetComponent<PlayerControls>();
    }

    private void OnEnable()
    {
        attack = playerControls.Player.Attack;
        attack.Enable();
        attack.performed += Attack;
    }

    private void OnDisable()
    {
        attack.Disable();
    }

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnCollide(Collider2D coll)
    {
        
    }


    private void Attack(InputAction.CallbackContext context)
    {
        if(Time.time - lastAttack > coolDown)
        {
            lastAttack = Time.time;
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Swing");
        //animator.SetTrigger("attack");
        //check for collision
        //Vector2 pos = transform.position;
        //pos.x += moveDelta.x * 0.7f;
        //pos.y += moveDelta.y * 0.7f;
        //hit = Physics2D.BoxCast(pos, boxCollider.size, 0, Vector2.zero, 0, LayerMask.GetMask("Enemy"));
        //if(hit.collider != null)
        //{
        //    Debug.Log("Hit " + hit.collider.name);
        //    //damage enemy
        //    Enemy enemy = hit.collider.GetComponent<Enemy>();
        //    if(enemy != null)
        //    {
        //        enemy.Fix();
        //    }
        //}
    }
}
