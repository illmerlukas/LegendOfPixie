using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSword : Collectable
{
    public void Start()
    {
        if (SaveGameData.current.inventory.sword)
            Destroy(gameObject);
    }

    public override void OnCollect()
    {
        base.OnCollect();
        SaveGameData.current.inventory.sword = true;
        Destroy(gameObject);
    }
}
