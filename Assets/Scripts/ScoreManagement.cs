using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    [SerializeField] LoseManager loseManager;
    [SerializeField] int currentPlayerScore;
    [SerializeField] int oldPlayerScore;
    [SerializeField] string scoreKey = "Deathscore";
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        loseManager.loseCounter = PlayerPrefs.GetInt(scoreKey, 0);
    }
    
    private void OnDisable()
    {
        
    }
}