using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarHeartRenderer : MonoBehaviour
{
    /// <summary>
    /// Ist die Gesundheit h�her oder gleich diesem Wert ist,
    /// wird das Herz gef�llt angezeigt.
    /// </summary>
    public int value = 5;

    /// <summary>
    /// Zeiger auf die Bildkomponente, die umgef�rbt bzw. ausgeblendet wird.
    /// </summary>
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (SaveGameData.current.health.current >= value)
            image.color = Color.white;
        else
            image.color = Color.black;
    }
}
