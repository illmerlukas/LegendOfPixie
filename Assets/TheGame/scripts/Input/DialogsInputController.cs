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
    private bool openStartMenu = false;

    protected void Awake()
    {
        dialogsRenderer = GetComponent<DialogsRenderer>();
    }

    private void OnRestart()
    {
        restartScene = true;
    }

    private void OnOpenStartMenu()
    {
        openStartMenu = true;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    protected void Update()
    {
        if (restartScene) 
        {
            Debug.Log(dialogsRenderer.gameOverDialog.activeInHierarchy);
            if (dialogsRenderer.gameOverDialog.activeInHierarchy) // game over 
            {
                SaveGameData.current = new SaveGameData();
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (openStartMenu)
        {
            if (!dialogsRenderer.gameOverDialog.activeInHierarchy)
            {
                dialogsRenderer.togglePause();
                openStartMenu = false;
            }
        }
    }
}
