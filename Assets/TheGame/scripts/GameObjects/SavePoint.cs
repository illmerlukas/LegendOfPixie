using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Läuft der Spieler über dieses Objekt, wird das Spiel gespeichert.
/// </summary>
public class SavePoint : Collectable
{
    public void Start()
    {
        if (SaveGameData.current.savepoint == gameObject.name) //an diesem savepoint wurde zuletzt gespeichert
        {
            setLocked(true);
            FindObjectOfType<Hero>().transform.position = transform.position + new Vector3(0.5f, -0.5f, 0);
        }
    }

    public override void OnCollect()
    {
        if (isLocked())
            return;

        SaveGameData.current.savepoint = gameObject.name;
        SaveGameData.current.save();
        setLocked(true);
    }

    /// <summary>
    /// Zeitpunkt in der Zukunft an dem das Objekt automatisch entsperrt wird.
    /// </summary>
    private float lockedUntil = 0f;

    /// <summary>
    /// Animator der aktiv ist, wenn das Objekt nicht gesperrt ist.
    /// </summary>
    public SimpleSpriteAnimator unlockedSprites;

    /// <summary>
    /// Bild das gezeigt wird, wenn das Objekt gesperrt ist.
    /// </summary>
    public Sprite lockedSprite;

    /// <summary>
    /// Renderer, der das lockedSprite empfängt
    /// </summary>
    public SpriteRenderer spriteRenderer;

    /// <summary>
    /// Sperrt das Objekt, so dass das Speichern nicht ausgelöst wird.
    /// </summary>
    /// <param name="doLock">Gibt an, ob das Objekt gesperrt (true) oder entsperrt (false) werden soll</param>
    private void setLocked(bool doLock)
    {
        Debug.Log("set locked " + doLock + " " + unlockedSprites.enabled);
        if (doLock != unlockedSprites.enabled) // wichtig: Zustand nur ändern, wenn sich wirklich etwas ändert. Ansonsten endloses neu-setzen des lockeUntil timers.
            return;

        if (doLock)
        {
            lockedUntil = Time.time + 10f; // Objekt wird in 10 sek wieder entsperrt.
            unlockedSprites.enabled = false; //animation stoppen
            spriteRenderer.sprite = lockedSprite;
        }
        else
        {
            unlockedSprites.enabled = true;
        }
    }

    /// <summary>
    /// Ermittelt, ob das Objekt bei Brührung speichert oder ob
    /// das Objekt noch gesperrt ist.
    /// </summary>
    /// <returns><c>true</c>, wenn das Objekt gesperrt ist, d.h. nicht speichert.</returns>
    private bool isLocked()
    {
        return lockedUntil > Time.time;
    }

    public void Update()
    {
        setLocked(isLocked());
    }
}
