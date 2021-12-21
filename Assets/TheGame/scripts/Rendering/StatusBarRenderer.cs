using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Visualisiert den aktuellen Spielzustand in der Statusleiste
/// </summary>
public class StatusBarRenderer : MonoBehaviour
{
    /// <summary>
    /// Die TextMeshPro-Komponente, die den Kristallzähler zeichnet.
    /// </summary>
    public TextMeshProUGUI gemLabel;

    /// <summary>
    /// Das Bild, das die Waffe auf Position A in der Statusleiste zeichnet.
    /// </summary>
    public Image weaponARenderer;

    /// <summary>
    /// Das Bild, das die Waffe auf Position A in der Statusleiste zeichnet.
    /// </summary>
    public Image weaponBRenderer;

    void Update()
    {
        gemLabel.text = SaveGameData.current.inventory.gems.ToString("D3");
        weaponARenderer.gameObject.SetActive(SaveGameData.current.inventory.shield);
        weaponBRenderer.gameObject.SetActive(SaveGameData.current.inventory.sword);
    }
}
