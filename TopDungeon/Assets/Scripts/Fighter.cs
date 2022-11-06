using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    //Public fields
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    //Immunity
    protected float immuneTime = 1f;
    protected float lastImmune;

    //Push
    protected Vector3 pushDirection;

    //All fighters can receive Damage and also die
    public virtual void ReceiveDamage(Damage damage)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= damage.damageAmount;
            pushDirection = (transform.position - damage.origin).normalized * damage.pushForce;

            //Show damage
            Debug.Log("Damage: " + damage.damageAmount);
            GameManager.instance.ShowText(damage.damageAmount.ToString(), 35, Color.red, transform.position + new Vector3(0,0.05f,0), Vector3.up * 40, 1.0f);

            if(hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {
        Debug.Log("Death is not implemented in " + this.name);
    }
}
