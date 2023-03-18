using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : Interactable
{
    public override void interact(Player player)
    {
        GameState.state = stateOfGame.win;
        SceneManager.LoadScene("EndScene");
        
    }
}
