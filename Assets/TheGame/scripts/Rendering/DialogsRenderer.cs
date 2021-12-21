using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Verwaltet Texttafeln, die nur zu bestimmten Zeiten sichtbar sind.
/// </summary>
public class DialogsRenderer : MonoBehaviour
{
    /// <summary>
    /// Zeiger auf die UI-Tafel, die angezeigt wird,
    /// wenn das Spiel vorbei/verloren ist.
    /// </summary>
    public GameObject gameOverDialog;

    /// <summary>
    /// Zeiger auf die "Spiel gespeichert"-Meldung,
    /// die kurz angezeigt wird, dann wieder verschwindet.
    /// </summary>
    public GameObject savedInfo;

    protected void Awake()
    {
        gameOverDialog.SetActive(false);
        savedInfo.SetActive(false);
    }

    /// <summary>
    /// Blendet die "Spiel gespeichert"-Info (savedInfo) ein,
    /// wartet einen Moment und blendet sie wieder aus.
    /// </summary>
    public void showSavedInfo()
    {
        StartCoroutine(showSavedInfoAndHide());
    }

    private IEnumerator showSavedInfoAndHide()
    {
        savedInfo.SetActive(true);
        yield return new WaitForSeconds(1f);
        savedInfo.SetActive(false);
    }
}
