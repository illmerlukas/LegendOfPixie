using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Helden-spezifische Funktionen.
/// </summary>
public class Hero : TheGameObject
{
    private ContactFilter2D triggerContactFilter;

    /// <summary>
    /// Sprites für den Charakter ohne Ausrüstung
    /// </summary>
    public RuntimeAnimatorController emptySkin;

    /// <summary>
    /// Sprites für den Charakter bei angelegtem Schild.
    /// </summary>
    public RuntimeAnimatorController shieldSkin;

    protected override void Awake()
    {
        base.Awake();
        triggerContactFilter = new ContactFilter2D();
        triggerContactFilter.useTriggers = true; //Trigger-Collider auch erkennen!
    }
    private void Update()
    {
        int found = boxCollider.OverlapCollider(triggerContactFilter, colliders);

        for (int i = 0; i < found; i++)
        {
            Collider2D foundCollider = colliders[i];
            if (foundCollider.isTrigger)
                foreach (Collectable collectable in foundCollider.GetComponents<Collectable>())
                    collectable.OnCollect();
        }

        if (gameObject.name == "Hero")
        {
            if (SaveGameData.current.inventory.shield)
                anim.runtimeAnimatorController = shieldSkin;
            else
                anim.runtimeAnimatorController = emptySkin;
        }

        if (SaveGameData.current.health.current == 0)
        {
            anim.SetTrigger("die");
            anim.updateMode = AnimatorUpdateMode.UnscaledTime; // hero-animator soll time.timeScale ignorieren, damit die sterbe-animation läuft
            GetComponent<PlayerInputController>().enabled = false;
            Time.timeScale = 0f; // spiel pausieren
        }
    }

    public void onDeathAnimationComplete()
    {
        DialogsRenderer dialogsRenderer = FindObjectOfType<DialogsRenderer>();
        dialogsRenderer.gameOverDialog.SetActive(true);
    }

    /// <summary>
    /// Helfer-Struktur, um eine Reihe von Bildern
    /// für die Figur zu hinterlegen.
    /// </summary>
    [System.Serializable]
    public class SpriteSet
    {
        public Sprite down;
        public Sprite left;
        public Sprite up;
        public Sprite right;

        /// <summary>
        /// Weist dem Sprite-Renderer das Sprite zu, das zur Blickrichtung passt.
        /// </summary>
        /// <param name="spriteRenderer">Sprite renderer.</param>
        /// <param name="lookAt">Blickrichtung, entspricht dem Animator-Parameter lookAt</param>
        public void apply(SpriteRenderer spriteRenderer, int lookAt)
        {
            spriteRenderer.flipX = false;
            if (lookAt == 0)
                spriteRenderer.sprite = down;
            else if (lookAt == 1)
                spriteRenderer.sprite = left;
            else if (lookAt == 2)
                spriteRenderer.sprite = up;
            else if (lookAt == 3)
            {
                spriteRenderer.sprite = right;
                spriteRenderer.flipX = true;
            }
        }
    }

    /// <summary>
    /// Satz der Bilder, die die Schlagaktion ohne Schild visualisieren.
    /// </summary>
    public SpriteSet emptyActionSkin;

    /// <summary>
    /// Satz der Bilder, die die Schlagaktion mit Schild visualisieren.
    /// </summary>
    public SpriteSet shieldActionSkin;

    /// <summary>
    /// Reaktion auf Aktionstastendruck.
    /// </summary>
    public void performAction()
    {
        if (!SaveGameData.current.inventory.sword) // Kein Schwert = Kein Schlag
            return;

        anim.enabled = false;

        AnimationEventDelegate.whenTimelineEventReached += resetSkin;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int lookAt = Mathf.RoundToInt(anim.GetFloat("lookAt"));

        if (SaveGameData.current.inventory.shield)
            shieldActionSkin.apply(spriteRenderer, lookAt);
        else
            emptyActionSkin.apply(spriteRenderer, lookAt);

        Sword sword = GetComponentInChildren<Sword>();
        sword.stroke();
    }

    private void resetSkin()
    {
        anim.enabled = true;
        AnimationEventDelegate.whenTimelineEventReached -= resetSkin;
    }
}