using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Helfer, um ein Ereignis der Zeitleiste an ein beliebiges
/// Script weiter zu leiten.
/// </summary>
public class AnimationEventDelegate : MonoBehaviour
{
    /// <summary>
    /// Definiert, wie Funktionen aufgebaut sein m�ssen, damit sie in die
    /// Liste whenTimelineEventReached aufgenommen werden k�nnen.
    /// </summary>
    public delegate void Callback();

    /// <summary>
    /// Eine "Liste" die Funktionen nach dem Bauplan des 'delegate Callback'
    /// enth�lt. Diese Funktionen werden aufgerufen, wenn das Zeitleistenereignis
    /// eintritt.
    /// </summary>
    public static event Callback whenTimelineEventReached;

    public void onTimelineEvent()
    {
        if (whenTimelineEventReached != null) whenTimelineEventReached();
    }
}
