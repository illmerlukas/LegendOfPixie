using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    /// <summary>
    /// Liste m�glicher Spielobjekte, aus denen zuf�llig eines
    /// ausgew�hlt und in der Szene dupliziert wird.
    /// </summary>
    public GameObject[] possibleElements = new GameObject[0];

    /// <summary>
    /// W�hlt per Zufall ein Element aus der possibleElements-Liste
    /// und erzeugt eine Kopie/Instanz davon in der Szene.
    /// </summary>
    /// <returns>Das neu erzeugte Objekt.</returns>
    public GameObject spawn()
    {
        GameObject template = possibleElements[Random.Range(0, possibleElements.Length)];

        if (template == null)
            return null;
        else
            return Instantiate(template);
    }
}
