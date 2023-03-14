using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCanvas : MonoBehaviour
{
    #region Fields
    [SerializeField] GameObject playerCharacter;
    [SerializeField] Canvas loseScreen;
    #endregion
    #region Methods
    /// <summary>
    /// Reloads this Scene, resetting everything
    /// </summary>
    public void ResetButton()
    {
        string thisSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(thisSceneName);
    }
    public void MenuButton(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    #endregion
}
