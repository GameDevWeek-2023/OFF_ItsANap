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
    [SerializeField] Canvas mainMenuCanvas;
    public string scoreKey = "Deathscore";
    private LoseManager loseManager;
    #region FilePath
    private string filePath;
    private string fileContent;
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
        Debug.Log("Scoremanager " + loseManager.loseCounter);
        loseManager.UpdateCounterText();
        if (GameState.state == stateOfGame.win)
        {
            highScoreCanvas.enabled = true;
        }
        else
        {
            highScoreCanvas.enabled = false;
        }
        filePath = Application.dataPath + "/Highscores.txt";
        //Checks if the highscore file exists and creates one if it doesn't
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
            fileContent = "";
            for(int index = 0; index < 11; index++)
            {
                fileContent += "empty_2500" + "\n";
            }
            OverrideFile();
            FileDataToDictionary();
            PrintHighScoreList();
        }
        else
        {
            FileDataToDictionary();
            PrintHighScoreList();
        }
    }
    private void OnDisable() {
        Debug.Log("scorekey" + scoreKey);
        Debug.Log("loseCounter"+ loseManager.loseCounter);
        PlayerPrefs.SetInt(scoreKey, loseManager.loseCounter);
    }
    #region Buttons
    public void SubmitButton()
    {
        highScoreNames.Remove(10);
        highScoreNumbers.Remove(10);
        highScoreNames.Add(10, inputNameField.textComponent.text);
        highScoreNumbers.Add(10, loseManager.loseCounter);
        SortDictionaries();
        PrintHighScoreList();
        inputNameField.enabled = false;
        submitButton.enabled = false;
    }
    public void HideHighScoreButton()
    {
        OverrideFile();
        GameState.state = stateOfGame.newStart;
        inputNameField.enabled = true;
        submitButton.enabled = true;
        mainMenuCanvas.enabled = true;
        highScoreCanvas.enabled = false;
    }
    #endregion
    /// <summary>
    /// Rewrites the highscore file
    /// </summary>
    private void OverrideFile()
    {
        DictionariesToString();
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
    /// writes the contents of a file into their respective dictionaries
    /// </summary>
    private void FileDataToDictionary()
    {
        string[] fileDataArray = File.ReadAllLines(filePath);
        int dictIndex = 0;
        //used as a work-around because you can't write into highScoreNumbers with try parse for some reason
        int numberParser;
        highScoreNames.Clear();
        highScoreNumbers.Clear();
        // splits every line in fileDataArray into a name and a number and saves them in their dictionaries
        foreach (string fileData in fileDataArray)
        {
            string[] splitArray = fileData.Split('_');
            highScoreNames.Add(dictIndex, splitArray[0]);
            #region DebugLog
            Debug.Log($"{dictIndex} {splitArray[0]} {splitArray[1]}");
            Debug.Log("-----------------");
            Debug.Log($"{dictIndex} " + highScoreNames.GetValueOrDefault(dictIndex));
            #endregion
            int.TryParse(splitArray[1], out numberParser);
            highScoreNumbers.Add(dictIndex, numberParser);
            #region DebugLog
            Debug.Log($"{dictIndex} {highScoreNumbers.GetValueOrDefault(dictIndex)}");
            Debug.Log("-----------------");
            Debug.Log($"{dictIndex} {fileData}");
            Debug.Log("==================");
            #endregion
            dictIndex++;
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
            fileContent += highScoreNames[index] + "_" + Convert.ToString(highScoreNumbers.GetValueOrDefault(index)) + "\n";
        }
    }
    private void PrintHighScoreList()
    {
        highScoreTextNumbers.text = "";
        highScoreTextNames.text = "";
        int numberOutput;
        string stringOutput;
        for (int dictIndex = 0; dictIndex < 10; dictIndex++)
        {
            //highScoreNumbers.TryGetValue(dictIndex, out numberOutput);
            //highScoreNames.TryGetValue(dictIndex, out stringOutput);
            numberOutput = highScoreNumbers.GetValueOrDefault(dictIndex);
            stringOutput = highScoreNames.GetValueOrDefault(dictIndex);
            Debug.Log(Convert.ToString(numberOutput) + " " + Convert.ToString(dictIndex));
            Debug.Log(stringOutput + " " + Convert.ToString(dictIndex));
            highScoreTextNumbers.text += Convert.ToString(numberOutput) + "\n";
            highScoreTextNames.text += stringOutput + "\n";
        }
    }
    #endregion
}