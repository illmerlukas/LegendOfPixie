using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basisklasse f�r alle Blockaden, die bei Ber�hrung benachrichtigt
/// werden sollen.
/// </summary>
public class TouchableBlocker : MonoBehaviour
{
    /// <summary>
    /// Wird aufgerufen wenn das Objekt ber�hrt wird.
    /// Unterklassen sollten die Methode �berschreiben,
    /// um auf den Kontakt zu reagieren, �hnlich wie bei OnTrigger-Ereignissen.
    /// </summary>
    public virtual void OnTouch()
    {
        //leer
    }   
}
