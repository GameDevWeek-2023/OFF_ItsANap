using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] InputField insertNameField;
    [SerializeField] Button submitButton;
    [SerializeField] Canvas DeathCounter;
    [SerializeField] Canvas highScoreCanvas;
    [SerializeField] Canvas optionsMenu;
    [SerializeField] Canvas mainMenu;
    private LoseManager loseManager;
    private void Start()
    {
        loseManager = FindObjectOfType<LoseManager>();
        if (GameState.state == stateOfGame.newStart)
        {
            Time.timeScale = 0;
        }
        else
        {
            mainMenu.enabled = false;
        }
    }
    public void ShowHighScoreButton()
    {
        highScoreCanvas.enabled = true;
        submitButton.enabled = false;
        insertNameField.enabled = false;
    }
    public void CreditsButton()
    {
        SceneManager.LoadScene("CreditsScene");
    }
    public void StartGameButton()
    {
        GameState.state = stateOfGame.running;
        Time.timeScale = 1;
        DeathCounter.enabled = true;
        loseManager.ResetScore();
        submitButton.enabled = true;
        insertNameField.enabled = true;
        SceneManager.LoadScene("MainLevel");
    }
    public void OptionsButton()
    {
        optionsMenu.enabled = !optionsMenu.enabled;
    }
    public void QuitGameButton()
    {
        Application.Quit();
    }
}
