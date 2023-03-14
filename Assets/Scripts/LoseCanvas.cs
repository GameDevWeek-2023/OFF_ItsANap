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
    public void ResetButton()
    {
        //playerCharacter.GetComponent<Player>().Respawn();
        TrapTrigger[] trapsToReset = GameObject.FindObjectsOfType(TrapTrigger);
        DeathZone[] zonesToReset = GameObject.FindObjectsOfType(DeathZone);
        loseScreen.enabled = false;

    }
    public void MenuButton(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    #endregion
}
