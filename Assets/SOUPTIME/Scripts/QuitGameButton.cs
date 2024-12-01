using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGameButton : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void QuitGame()
    {
        // Check if the game is running in the editor
#if UNITY_EDITOR
            // Stop play mode in the editor
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the game if it's a build
        Application.Quit();
#endif
    }
}
