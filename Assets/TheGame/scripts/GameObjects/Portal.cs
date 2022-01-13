using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Lädt ein anderes Level, wenn der Spieler auf das Objekt läuft.
/// </summary>
public class Portal : Collectable
{
    /// <summary>
    /// Name der zu ladenden Szene
    /// </summary>
    public string sceneName;

    public override void OnCollect()
    {
        base.OnCollect();
        SceneManager.LoadScene(sceneName);
    }
}
