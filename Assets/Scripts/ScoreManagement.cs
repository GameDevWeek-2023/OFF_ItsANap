using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class ScoreManagement : MonoBehaviour
{
    #region Fields
    [SerializeField] Canvas highScoreCanvas;
    [SerializeField] Text highScoreTextNames;
    [SerializeField] Text highScoreTextNumbers;
    [SerializeField] Button submitButton;
    [SerializeField] InputField inputNameField;
    public string scoreKey = "Deathscore";
    private LoseManager loseManager;
    #region FilePath
    private string filePath;
    private string fileContent = "";
    private Dictionary<int, string> highScoreNames = new Dictionary<int, string>(11);
    private Dictionary<int, int> highScoreNumbers = new Dictionary<int, int>(11);
    #endregion
    #endregion
    #region Methods
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        loseManager = FindObjectOfType<LoseManager>();
        loseManager.loseCounter = PlayerPrefs.GetInt(scoreKey, 0);
        loseManager.UpdateCounterText();
        filePath = Application.dataPath + "/Highscores.txt";
        //Checks if the highscore file exists and creates one if it doesn't
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }
    }
    #region Buttons
    public void SubmitButton()
    {
        highScoreNames[10] = inputNameField.textComponent.text;
        highScoreNumbers[10] = loseManager.loseCounter;
        SortDictionaries();
        inputNameField.enabled = false;
        submitButton.enabled = false;
    }
    public void HideHighScoreButton()
    {
        inputNameField.enabled = true;
        submitButton.enabled = true;
        highScoreCanvas.enabled = false;
    }
    #endregion
    /// <summary>
    /// Rewrites the highscore file
    /// </summary>
    private void OverrideFile()
    {
        File.WriteAllText(filePath, fileContent);
    }

    /// <summary>
    /// sorts both dictionaries using bubble sort in ascending order
    /// </summary>
    private void SortDictionaries()
    {
        string tempNameSave;
        int tempNumberSave;
        for (int firstPos = 0; firstPos < 11; firstPos++)
        {
            for(int secondPos = firstPos + 1; secondPos < 11; secondPos++)
            {
                if(highScoreNumbers[firstPos] > highScoreNumbers[secondPos])
                {
                    //save first position in tempSaves
                    tempNameSave = highScoreNames[firstPos];
                    tempNumberSave = highScoreNumbers[firstPos];
                    //override first postion with values from second position
                    highScoreNames[firstPos] = highScoreNames[secondPos];
                    highScoreNumbers[firstPos] = highScoreNumbers[secondPos];
                    //override second position with formerly first values
                    highScoreNames[secondPos] = tempNameSave;
                    highScoreNumbers[secondPos] = tempNumberSave;
                }
            }
        }
    }
    /// <summary>
    /// overrides the filecontent string with values from the dictionaries
    /// </summary>
    private void DictionariesToString()
    {
        fileContent = "";
        for(int index = 0; index < 11; index++)
        {
            fileContent += highScoreNames[index] + ";;" + highScoreNumbers + ";;";
        }
    }
    #endregion
}