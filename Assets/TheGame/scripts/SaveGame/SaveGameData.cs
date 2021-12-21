using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Datenspeicher für den aktuellen Spielstand
/// </summary>
public class SaveGameData
{
    /// <summary>
    /// Der aktuelle Spielstand.
    /// </summary>
    public static SaveGameData current = loadOrNew();

    /// <summary>
    /// Speicher für einsammelbare, mitgeführte Objekte
    /// </summary>
    public Inventory inventory = new Inventory();

    /// <summary>
    /// Aktueller Gesundheitszustand des Spielers.
    /// </summary>
    public Health health = new Health();

    /// <summary>
    /// Name/ID des Savepoint-Objekts ("Barber-Pole") an dem
    /// zuletzt gespeichert wurde und an dem die Figur beim Laden
    /// platziert wird.
    /// </summary>
    public string savepoint = "";

    /// <summary>
    /// Speicher den Spielstand.
    /// </summary>
    public void save()
    {
        string filePath = "";
        try
        {
            string data = JsonUtility.ToJson(this);
            filePath = Path.Combine(Application.persistentDataPath, "savegame.json");
            File.WriteAllText(filePath, data);
            DialogsRenderer dialogsRenderer = UnityEngine.Object.FindObjectOfType<DialogsRenderer>();

            if (dialogsRenderer != null)
                dialogsRenderer.showSavedInfo();

            Debug.Log("saved \nDatei=" + filePath + "\nDaten=" + data);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Datei konnte nicht gespeichert werden:\nDatei=" + filePath + "\nFehlermeldung" + ex.Message + "\nStracktrace" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Lädt den Spielstand aus dem Savegame (wenn vorhanden)
    /// oder erzeugt einen neuen leeren Spielstand.
    /// </summary>
    /// <returns>Der geladene oder neue Spielstand.</returns>
    private static SaveGameData loadOrNew()
    {
        SaveGameData result = new SaveGameData();

        string filePath = Path.Combine(Application.persistentDataPath, "savegame.json");

        if (File.Exists(filePath))
        {
            try
            {
                string data = File.ReadAllText(filePath);
                result = JsonUtility.FromJson<SaveGameData>(data);
                Debug.Log("loaded \nDatei=" + filePath + "\nDaten=" + data);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Datei konnte nicht geladen werden:\nDatei=" + filePath + "\nFehlermeldung" + ex.Message + "\nStracktrace" + ex.StackTrace);
            }
        }

        return result;
    }

    public List<string> deletedObjects = new List<string>();

    /// <summary>
    /// Löscht das angegebene Objekt aus der Szene
    /// und zeichnet diesen Vorgang im Savegame auf.
    /// </summary>
    /// <param name="go">Zu löschendes Objekt</param>
    public void recordDestroy(GameObject go)
    {
        string ID = go.name + "/" + go.scene.name;
        UnityEngine.Object.Destroy(go);
        deletedObjects.Add(ID);
    }

    /// <summary>
    /// Löscht das Spielobjekt, wenn es als gelöscht im
    /// Spielzustand gespeichert ist.
    /// </summary>
    /// <param name="go">Zu löschendes bzw. zuvor evtl. gelöschtes Objekt.</param>
    public void recoverDestroy(GameObject go)
    {
        string ID = go.name + "/" + go.scene.name;
        if (deletedObjects.Contains(ID))
            UnityEngine.Object.Destroy(go);
    }
}
