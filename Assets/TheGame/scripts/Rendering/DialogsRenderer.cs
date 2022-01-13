using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    /// <summary>
    /// Mini-Menü das zu sehen ist, während sich das Spiel
    /// im Pause-Zustand befindet.
    /// </summary>
    public GameObject pauseInfo;

    /// <summary>
    /// Schwarzbild, dass zum Abblenden des Hintergund verwendet wird
    /// </summary>
    public GameObject blackness;

    protected void Awake()
    {
        gameOverDialog.SetActive(false);
        savedInfo.SetActive(false);
        pauseInfo.SetActive(false);
        blackness.SetActive(false);
    }

    /// <summary>
    /// Blendet das Pause-Menü aus, wenn es sichtbar ist 
    /// und blendet es ein, wenn es unsichtbar ist.
    /// </summary>
    public void togglePause()
    {
        if (pauseInfo.activeSelf)
        {
            pauseInfo.SetActive(false);
            Time.timeScale = 1f; // Zeit fortsetzen
        }
        else
        {
            pauseInfo.SetActive(true);
            Time.timeScale = 0f; // Zeit anhalten
            Button button = pauseInfo.GetComponentInChildren<Button>();
            EventSystem.current.SetSelectedGameObject(button.gameObject); // Fokus auf den ersten button
            button.OnSelect(null);
        }

        blackness.SetActive(pauseInfo.activeSelf);
        AudioListener.pause = pauseInfo.activeSelf;
    }

    /// <summary>
    /// Kehrt sofort zum Startmenü zurück;
    /// </summary>
    public void onBackToStartMenu()
    {
        Time.timeScale = 1f; // Zeit fortsetzen
        AudioListener.pause = false; // Sounds fortsetzen
        SceneManager.LoadScene("StartMenu");
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
