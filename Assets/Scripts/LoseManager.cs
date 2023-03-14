using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LoseManager : MonoBehaviour
{
    #region Fields
    public int loseCounter = 0;
    [SerializeField] Text deathCounterText;
    [SerializeField] Canvas losingScreen;
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
    }
    #endregion
}
