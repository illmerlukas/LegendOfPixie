using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script f�r die Kamera, das die Spielfigur immer im Bild h�lt.
/// </summary>
public class CameraMotionController : MonoBehaviour
{
    /// <summary>
    /// Zeiger auf den Held, den die Kamera im Bild h�lt.
    /// </summary>
    public Hero hero;

    // Update is called once per frame
    private void Update()
    {
        Vector3 heroPos = hero.transform.position; //Position des Helden kopieren
        heroPos.z = transform.position.z; //Kamera-Z beibehalten
        transform.position = heroPos;
    }
}
