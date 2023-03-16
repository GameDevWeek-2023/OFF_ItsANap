using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] InputField insertNameField;
    [SerializeField] Button submitButton;
    [SerializeField] Canvas highScoreCanvas;
    [SerializeField] Canvas optionsMenu;
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
