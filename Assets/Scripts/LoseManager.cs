using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseManager : MonoBehaviour
{
    #region Fields
    public int loseCounter = 0;
    [SerializeField] Text deathCounterText;
    [SerializeField] Canvas losingScreen;
    [SerializeField] GameObject playerCharacter;
    #endregion
    #region Methods
    /// <summary>
    /// increases Death Counter and shows losing Canvas
    /// </summary>
    public void UpdateLose()
    {
        loseCounter++;
        deathCounterText.text = Convert.ToString(loseCounter);
        losingScreen.enabled = true;
        playerCharacter.GetComponent<Player>().Dead();
    }
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
