using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int moneyAmount = 10;
    protected override void OnCollect()
    {
        base.OnCollect();
        GetComponent<SpriteRenderer>().sprite = emptyChest;
        //add money //TODO
        Debug.Log("Collected " + moneyAmount + " money");
        GameManager.instance.money += moneyAmount;
        GameManager.instance.ShowText("+" + moneyAmount + " money", 22, Color.yellow, transform.position, Vector3.up * 20, 1.0f);
    }

}
