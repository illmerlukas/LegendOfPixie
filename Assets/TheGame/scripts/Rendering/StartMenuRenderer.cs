using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuRenderer : MonoBehaviour
{
    /// <summary>
    /// Startet mit dem letzten Spielstand.
    /// </summary>
    public void OnContinue()
    {
        SceneManager.LoadScene("main");
    }

    /// <summary>
    /// Startet mit einem neuen Spielstand.
    /// </summary>
    public void OnNewGame()
    {
        SaveGameData.current = new SaveGameData();
        SceneManager.LoadScene("main");
    }

    /// <summary>
    /// Geendet das gesamte Programm/Spiel
    /// </summary>
    public void OnQuit()
    {
        Debug.Log("Spiel beenden!");
        Application.Quit();
    }
}
