using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basisklasse für alle Blockaden, die bei Berührung benachrichtigt
/// werden sollen.
/// </summary>
public class TouchableBlocker : MonoBehaviour
{
    /// <summary>
    /// Wird aufgerufen wenn das Objekt berührt wird.
    /// Unterklassen sollten die Methode überschreiben,
    /// um auf den Kontakt zu reagieren, ähnlich wie bei OnTrigger-Ereignissen.
    /// </summary>
    public virtual void OnTouch()
    {
        //leer
    }   
}
