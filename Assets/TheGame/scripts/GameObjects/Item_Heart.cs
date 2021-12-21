using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Heart : Collectable
{
    public bool saveDestruction = false;

    public void Start()
    {
        if (saveDestruction)
            SaveGameData.current.recoverDestroy(gameObject);
    }

    public override void OnCollect()
    {
        base.OnCollect();
        SaveGameData.current.health.change(1);

        if (saveDestruction)
            SaveGameData.current.recordDestroy(gameObject);
        else
            Destroy(gameObject);
    }
}
