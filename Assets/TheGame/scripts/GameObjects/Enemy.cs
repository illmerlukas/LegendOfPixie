using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basis-Script für grundsätzliches Feindverhalten:
/// Zerstörbarkeit mit dem Schwert.
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// Prefab der Explosion, das bei Tod des Feindes in der Szene instanziert wird.
    /// </summary>
    public GameObject explosionPrototype;

    public bool saveDestruction = false;

    public void Start()
    {
        if (saveDestruction)
            SaveGameData.current.recoverDestroy(gameObject);
    }

    /// <summary>
    /// Zerstört den Feind, wenn er vom Schwert getroffen wird.
    /// (Wird aufgerufen von Sword.onCollisionDetected)
    /// </summary>
    public void onHitBySword()
    {
        RandomSpawn randomSpawn = GetComponent<RandomSpawn>();
        if (randomSpawn != null)
        {
            GameObject item = randomSpawn.spawn();

            if (item != null)
                item.transform.position = transform.position;
        }

        GameObject explosion = Instantiate(explosionPrototype, transform.parent);
        explosion.transform.position = transform.position;

        if (saveDestruction)
            SaveGameData.current.recordDestroy(gameObject);
        else
            Destroy(gameObject);
    }
}
