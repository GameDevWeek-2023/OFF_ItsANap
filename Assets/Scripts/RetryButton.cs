using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    #region Fields
    [SerializeField] GameObject playerCharacter;
    [SerializeField] Canvas loseScreen;
    #endregion
    #region Methods
    public void ResetButton()
    {
        //playerCharacter.GetComponent<Player>().Respawn();
        //hide and disable losescreen

    }
    #endregion
}
