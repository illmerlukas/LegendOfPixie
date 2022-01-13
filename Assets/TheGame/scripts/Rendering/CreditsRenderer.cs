using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Zeigt die Mitwirkenden als durchlaufenden Text an.
/// </summary>
public class CreditsRenderer : MonoBehaviour
{
    /// <summary>
    /// Komponente zum Darstellen des Textx in der Szene.
    /// </summary>
    public TextMeshProUGUI textRenderer;

    /// <summary>
    /// Die Textdatei, die die anzuzeigenden Credits enthält.
    /// Die Datei wird zeilenweise eingelesen und jede Zeile
    /// separat angezeigt.
    /// </summary>
    public TextAsset textFile;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        string[] lines = textFile.text.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            textRenderer.text = lines[i];
            yield return new WaitForSeconds(1f + (lines[i].Length * 0.1f));
        }

        SceneManager.LoadScene("startmenu");
    }
}
