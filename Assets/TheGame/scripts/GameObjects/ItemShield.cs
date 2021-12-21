using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShield : Collectable
{
    public void Start()
    {
        if (SaveGameData.current.inventory.shield)
            Destroy(gameObject);
    }

    public override void OnCollect()
    {
        base.OnCollect();
        SaveGameData.current.inventory.shield = true;
        Destroy(gameObject);
    }
}
