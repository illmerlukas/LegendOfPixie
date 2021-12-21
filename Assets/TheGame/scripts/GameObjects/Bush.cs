using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    /// <summary>
    /// Liste der Einzelbilder, die bei Zerstörung des Busches abgespielt werden.
    /// </summary>
    public Sprite[] destructionFrames = new Sprite[0];

    /// <summary>
    /// Dauer der gesamten Animation (Abspielzeit der destructionFrames).
    /// </summary>
    public float duration = 0.5f;

    private bool isHitAnyPlaying = false;

    public void Start()
    {
        SaveGameData.current.recoverDestroy(gameObject);
    }

    /// <summary>
    /// Zerstört den Busch, wenn er vom Schwert getroffen wird.
    /// (Wird aufgerufen von Sword.onCollisionDetected)
    /// </summary>
    public void onHitBySword()
    {
        if (!isHitAnyPlaying)
        StartCoroutine(playOnHitBySwordAni());
    }

    protected IEnumerator playOnHitBySwordAni()
    {
        RandomSpawn randomSpawn = GetComponent<RandomSpawn>();

        if (randomSpawn != null)
        {
            GameObject item = randomSpawn.spawn();

            if (item != null)
                item.transform.position = transform.position;
        }

        isHitAnyPlaying = true;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        for (int i = 0; i < destructionFrames.Length; i++)
        {
            spriteRenderer.sprite = destructionFrames[i];
            yield return new WaitForSeconds(duration / destructionFrames.Length);
        }

        SaveGameData.current.recordDestroy(gameObject);
    }
}
