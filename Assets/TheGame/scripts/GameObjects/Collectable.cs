using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basis-Klasse f�r alle Szenenobjekte, die beim Dar�berlaufen
/// benachrichtig werden wollen.
/// </summary>

[RequireComponent(typeof(BoxCollider2D))]
public class Collectable : MonoBehaviour
{
    protected virtual void Awake()
    {
        if (!GetComponent<BoxCollider2D>().isTrigger)
            Debug.LogError("Der Boxcollider von " + gameObject.name + " muss ein Trigger sein!");
    }

    /// <summary>
    /// Wird aufgerufen, wenn das Objekt aktiviert oder eingesammelt
    /// werden soll. Unterklassen sollten diese Methode �berschreiben,
    /// um auf den Kontakt zu reagieren, �hnlich wie bei Ontrigger-Ereignissen.
    /// </summary>
    public virtual void OnCollect()
    {
        //leer
    }
}
