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
    private LoseManager loseManager;
    private void Start()
    {
        loseManager = FindObjectOfType<LoseManager>();
        Time.timeScale = 0;
    }
    public void ShowHighScoreButton()
    {
        highScoreCanvas.enabled = true;
        submitButton.enabled = false;
        insertNameField.enabled = false;
    }
    public void CreditsButton()
    {
        //TODO:
        //show credits
    }
    public void StartGameButton()
    {
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
