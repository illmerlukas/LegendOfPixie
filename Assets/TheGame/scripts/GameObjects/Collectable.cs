using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basis-Klasse für alle Szenenobjekte, die beim Darüberlaufen
/// benachrichtig werden wollen.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class Collectable : MonoBehaviour
{
    /// <summary>
    /// Der Sound, der beim Einsammeln abgespielt wird,
    /// sofern ein Clip gesetzt ist.
    /// </summary>
    public AudioClip collectSound;

    protected virtual void Awake()
    {
        if (!GetComponent<BoxCollider2D>().isTrigger)
            Debug.LogError("Der Boxcollider von " + gameObject.name + " muss ein Trigger sein!");
    }

    /// <summary>
    /// Wird aufgerufen, wenn das Objekt aktiviert oder eingesammelt
    /// werden soll. Unterklassen sollten diese Methode überschreiben,
    /// um auf den Kontakt zu reagieren, ähnlich wie bei Ontrigger-Ereignissen.
    /// </summary>
    public virtual void OnCollect()
    {
        if (collectSound != null)
            AudioSource.PlayClipAtPoint(collectSound, Vector3.zero);
    }
}
