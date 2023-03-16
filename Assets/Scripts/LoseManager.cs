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
    private ScoreManagement scoreManager;
    #endregion
    #region Methods
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public void Start()
    {
        scoreManager = FindObjectOfType<ScoreManagement>();
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
    public void RetryButton()
    {
        Time.timeScale = timeToReset;
        string thisSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(thisSceneName);
    }
    public void MenuButton(string sceneToLoad)
    {
        Time.timeScale = timeToReset;
        SceneManager.LoadScene(sceneToLoad);
    }
    /// <summary>
    /// seperated this line so other scripts can call this method, too
    /// </summary>
    public void UpdateCounterText()
    {
        deathCounterText.text = Convert.ToString(loseCounter);
    }
    /// <summary>
    /// Resets the deathcounter to 0, including the PlayerPref and restarts the game
    /// </summary>
    public void ResetScore()
    {
        PlayerPrefs.SetInt(scoreManager.scoreKey, 0);
        loseCounter = 0;
        UpdateCounterText();
        RetryButton();
    }
    #endregion
}
