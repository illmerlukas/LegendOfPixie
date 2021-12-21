using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// Steuert Eingabesignale, die von Dialogen ausgewertet werden sollen.
/// </summary>
public class DialogsInputController : MonoBehaviour
{
    private DialogsRenderer dialogsRenderer;
    private bool restartScene = false;

    protected void Awake()
    {
        dialogsRenderer = GetComponent<DialogsRenderer>();
    }

    private void OnRestart()
    {
        restartScene = true;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    protected void Update()
    {
        Debug.Log("restartScene " + restartScene);
        if (restartScene)
        {
            if (dialogsRenderer.gameOverDialog.activeInHierarchy)
            {
                SaveGameData.current = new SaveGameData();
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
    }
}
