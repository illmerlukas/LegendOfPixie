using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Realisiert eine einfache Animation auf Basis einer Liste
/// von Sprites
/// </summary>
public class SimpleSpriteAnimator : MonoBehaviour
{
    /// <summary>
    /// Liste der Einzelbilder, die abgespielt werden.
    /// </summary>
    public Sprite[] frames = new Sprite[0];

    /// <summary>
    /// Dauer der gesamten Animation.
    /// </summary>
    public float duration = 0.5f;

    /// <summary>
    /// Gibt an, dass die Framesequenz endlos wiederholt wird.
    /// </summary>
    public bool loop = true;

    /// <summary>
    /// Wenn true, wird das Objekt am Ende der Animation zerstört.
    /// </summary>
    public bool destroyObject = false;

    // Use this for initialization
    private void Start() {}

    public void OnEnable()
    {
        StartCoroutine(playAni());
    }
    protected IEnumerator playAni()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        do {
            for (int i = 0; i < frames.Length; i++)
            {
                if (!enabled)
                    break;

                spriteRenderer.sprite = frames[i];
                yield return new WaitForSeconds(duration / frames.Length);
            }
        } while (enabled && loop);

        if (destroyObject)
            Destroy(gameObject);
    }
}
