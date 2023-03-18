using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum stateOfGame
{
    running,
    win,
    newStart
}

public static class GameState
{
    
    public static stateOfGame state =  stateOfGame.newStart;
}
