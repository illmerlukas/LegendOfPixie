using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Speicherstruktur f�r Z�hler und aufnehmbare Objekte.
/// </summary>
[System.Serializable]
public class Inventory
{
    /// <summary>
    /// Anzahl der Kristalle im Inventar.
    /// </summary>
    public int gems = 0;

    /// <summary>
    /// Tr�gt der Charakter den Schild?
    /// </summary>
    public bool shield = false;

    /// <summary>
    /// Tr�gt der Charakter ein Schwert?
    /// </summary>
    public bool sword = false;
}
