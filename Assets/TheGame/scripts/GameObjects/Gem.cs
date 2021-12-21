using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Das ist das script für einsammelbare Objekte
/// </summary>
public class Gem : Collectable
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
        Debug.Log("Kristall eingesammelt;");
        SaveGameData.current.inventory.gems += 1;

        if (saveDestruction)
            SaveGameData.current.recordDestroy(gameObject);
        else
            Destroy(gameObject);
    }
}
