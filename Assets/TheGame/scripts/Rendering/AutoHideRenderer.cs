using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHideRenderer : MonoBehaviour
{
    /// <summary>
    /// Deaktiviert die Renderer-Komponente auf diesem Spielobjekt
    /// beim Start.
    /// </summary>
    private void Start()
    {
        Renderer r = GetComponent<Renderer>();

        if (r != null) r.enabled = false;
    }
}
