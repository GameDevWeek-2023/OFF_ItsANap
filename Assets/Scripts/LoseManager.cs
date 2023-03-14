using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LoseManager : MonoBehaviour
{
    #region Fields
    public int loseCounter = 0;
    [SerializeField] Text loseText;
    [SerializeField] Canvas losingScreen;
    #endregion
    #region Methods
    public void UpdateLose()
    {
        loseCounter++;
        loseText.text = Convert.ToString(loseCounter);
        //show losingscreen
    }
    #endregion
}
