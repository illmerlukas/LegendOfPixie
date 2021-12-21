using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Steuerung der Schwert-Waffe.
/// </summary>
public class Sword : MonoBehaviour
{
    /// <summary>
    /// Zeiger auf den Schwert-Animator zur Darstellung des Hiebs.
    /// </summary>
    public Animator anim;

    /// <summary>
    /// Zeiger auf den Animator der Figur, um die Laufrichtung zu ermitteln.
    /// Dieser Animator muss seine Richtung im Parameter lookAt enthalten.
    /// </summary>
    public Animator characterAnimator;

    /// <summary>
    /// Zeiger auf das Kollisionsscript, das erkennt, ob die Klinge auf ein
    /// Ziel trifft.
    /// </summary>
    public CollisionDetector collisionDetector;

    protected void Start()
    {
        setVisible(false);
        collisionDetector.whenCollisionDetected += onCollisionDetected;
    }

    private void onCollisionDetected(Collider2D collider)
    {
        //Debug.Log("Klinge hat getroffen: " + collider);

        Bush bush = collider.GetComponent<Bush>();
        if (bush != null)
            bush.onHitBySword();

        Enemy enemy = collider.GetComponent<Enemy>();
        if (enemy != null)
            enemy.onHitBySword();
    }

    public void OnEnable()
    {
        AnimationEventDelegate.whenTimelineEventReached += onTimelineEvent;
    }

    public void OnDisable()
    {
        AnimationEventDelegate.whenTimelineEventReached -= onTimelineEvent;
    }

    /// <summary>
    /// Steuert die Sichtbarkeit des Schwerts, indem das Schwert-Renderer-Objekt
    /// (= das Objekt das den anim-Animator trägt) aktiviert oder deaktiviert wird.
    /// </summary>
    /// <param name="isVisible">Neue Sichtbarkeit des Schwerts.</param>
    private void setVisible(bool isVisible)
    {
        anim.gameObject.SetActive(isVisible);
    }

    /// <summary>
    /// Führt einen Schwerthieb aus.
    /// </summary>

    public void stroke()
    {
        int lookAt = Mathf.RoundToInt(characterAnimator.GetFloat("lookAt"));

        float scaleX = 1f;
        float rotateZ = 0f;

        if (lookAt == 0) rotateZ = 90f;
        // lookAt 1 = rotateZ = 0f;
        else if (lookAt == 2) rotateZ = -90f;
        else if (lookAt == 3) scaleX = -1f;

        transform.localScale = new Vector3(scaleX, 1f, 1f);
        transform.localRotation = Quaternion.Euler(0f, 0f, rotateZ);

        setVisible(true);
        anim.SetTrigger("onStroke");
    }

    public void onTimelineEvent()
    {
        setVisible(false);
    }
}
