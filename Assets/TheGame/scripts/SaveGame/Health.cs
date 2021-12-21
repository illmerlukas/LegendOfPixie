using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dr�ckt den aktuellen Gesundheitszustand der Spielfigur aus.
/// </summary>
[System.Serializable]
public class Health
{
    /// <summary>
    /// Aktueller Gesundheitswert. Sinkt er auf 0, stirbt die Figur.
    /// </summary>
    public int current = 5;

    /// <summary>
    /// H�chst m�glicher Gesundheitswert.
    /// </summary>
    public int max = 5;

    /// <summary>
    /// F�gt Gesundheitspunkte hinzu und stellt dabei sicher,
    /// dass die Wertgrenzen (0..max) eingehalten werden.
    /// </summary>
    /// <param name="delta">Differenz, die hinzugef�gt oder abgezogen werden soll.</param>
    public void change(int delta)
    {
        current = Mathf.Clamp(current + delta, 0, max);
        Debug.Log("Health ist jetzt " + current + " von " + max);
    }
}
