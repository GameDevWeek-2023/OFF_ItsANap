using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseManager : MonoBehaviour
{
    #region Fields
    public int loseCounter;
    [SerializeField] Text deathCounterText;
    [SerializeField] Canvas losingScreen;
    [SerializeField] GameObject playerCharacter;
    [SerializeField] float timeToReset;
    #endregion
    #region Methods
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public void Start()
    {
        timeToReset = Time.timeScale;
    }
    /// <summary>
    /// increases Death Counter and shows losing Canvas
    /// </summary>
    public void UpdateLose()
    {
        loseCounter++;
        UpdateCounterText();
        losingScreen.enabled = true;
        playerCharacter.GetComponent<Player>().Dead();
    }
    /// <summary>
    /// Reloads this Scene, resetting everything
    /// </summary>
    public void ResetButton()
    {
        Time.timeScale = timeToReset;
        string thisSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(thisSceneName);
    }
    public void MenuButton(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void UpdateCounterText()
    {
        deathCounterText.text = Convert.ToString(loseCounter);
    }
    #endregion
}
