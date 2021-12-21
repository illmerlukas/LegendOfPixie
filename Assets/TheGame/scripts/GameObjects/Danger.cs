using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Realisiert eine Gefahrenquelle, die den Spieler bei Berührung verletzt.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class Danger : TouchableBlocker
{
    /// <summary>
    /// Zeitpunkt der letzten Verletzung
    /// </summary>
    private float lastHit = 0f;

    /// <summary>
    /// Muss true sein, wenn das Objekt mit der linken oberen Ecke
    /// an den Kacheln ausgerichtet wird, false, wenn das Objekt
    /// am Mittelpunkt ausgerichtet wird.
    /// </summary>
    public bool topLeftAnchor = false;

    public bool shieldProtection = false;
    public override void OnTouch()
    {
        base.OnTouch();
        bool isSafe = shieldProtection && SaveGameData.current.inventory.shield;
        // Nur wenn genügend Zeit nach der letzten Verletzung vergangen ist
        if (Time.time - lastHit > 1f)
        {
            if (!isSafe)
                SaveGameData.current.health.change(-1);

            lastHit = Time.time;

            if (SaveGameData.current.health.current > 0)
            {
                Hero hero = FindObjectOfType<Hero>();
                hero.pushAwayFrom(this, topLeftAnchor);
                    
                if (isSafe)
                    hero.flicker(5, Color.gray);
                else
                    hero.flicker(5, Color.red);
            }
        }
    }
}
