using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    #region Fields
    private LoseManager loseManager;
    [SerializeField] Text insertNameField;
    [SerializeField] Text highScoreListNames;
    [SerializeField] Text highScoreListNumbers;
    [SerializeField] string scoreKey = "Deathscore";
    private string[] highScoreNames = new string[11];
    private int[] highScoreNumbers = new int[11];
    #endregion
    #region Methods
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        loseManager = FindObjectOfType<LoseManager>();
        loseManager.loseCounter = PlayerPrefs.GetInt(scoreKey, 0);
        loseManager.UpdateCounterText();
    }
    /// <summary>
    /// OnDisable is called when the behaviour becomes disabled 
    /// </summary>
    private void OnDisable()
    {
        PlayerPrefs.SetInt(scoreKey, loseManager.loseCounter);
    }
    /// <summary>
    /// Resets the deathcounter to 0, including the PlayerPrefs
    /// </summary>
    public void ResetScore()
    {
        PlayerPrefs.SetInt(scoreKey, 0);
        loseManager.loseCounter = 0;
        loseManager.UpdateCounterText();
    }
    /// <summary>
    /// always overrides last place in highscore list, then sorts the list
    /// </summary>
    public void SaveScore()
    {
        highScoreNames[10] = insertNameField.text;
        highScoreNumbers[10] = loseManager.loseCounter;
        SortHighScoreList();
    }
    /// <summary>
    /// Fills highScoreNames and highScoreNumbers with saved values from PlayerPrefs
    /// </summary>
    private void GetHighScores()
    {
        string listKey;
        for (int listIndex = 0; listIndex < 10; listIndex++)
        {
            listKey = $"Place {listIndex + 1}";
            highScoreNumbers[listIndex] = PlayerPrefs.GetInt(listKey, 2500);
            highScoreNames[listIndex] = PlayerPrefs.GetString(listKey, "leer");
        }
    }
    /// <summary>
    /// sorts the high score list from lowest to highest
    /// </summary>
    private void SortHighScoreList()
    {
        int tempScoreSave;
        string tempNameSave;
        GetHighScores();
        for (int firstPos = 0; firstPos < 11; firstPos++)
        {
            for(int secondPos = firstPos + 1; secondPos < 11; secondPos++)
            {
                //if highest score has more deaths
                if (highScoreNumbers[firstPos] > highScoreNumbers[secondPos])
                {
                    //temporarily save stats from first place
                    tempScoreSave = highScoreNumbers[firstPos];
                    tempNameSave = highScoreNames[firstPos];
                    //save stats from second place in first place
                    highScoreNumbers[firstPos] = highScoreNumbers[secondPos];
                    highScoreNames[firstPos] = highScoreNames[secondPos];
                    //put stats saved from previous first place into second place
                    highScoreNumbers[secondPos] = tempScoreSave;
                    highScoreNames[secondPos] = tempNameSave;
                }
            }
        }
        SaveHighScoreList();
    }
    /// <summary>
    /// Saves the highscores and names of the highscore list, except for the last place (index 10)
    /// </summary>
    private void SaveHighScoreList()
    {
        string listKey;
        for(int listIndex = 0; listIndex < 10; listIndex++)
        {
            listKey = $"Place {listIndex + 1}";
            PlayerPrefs.SetInt(listKey, highScoreNumbers[listIndex]);
            PlayerPrefs.SetString(listKey, highScoreNames[listIndex]);
        }
    }
    private void PrintHighScoreList()
    {
        string listKey;
        highScoreListNames.text = "";
        highScoreListNumbers.text = "";
        for (int listIndex = 0; listIndex < 10; listIndex++)
        {
            listKey = $"Place {listIndex + 1}";
            highScoreListNames.text += PlayerPrefs.GetString(listKey, "leer") + "\n";
            highScoreListNumbers.text += PlayerPrefs.GetInt(listKey, 2500) + "\n";
        }
    }
    #endregion
}