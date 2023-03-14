using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    #region Fields
    enum typeOfTrap
    {
        DisappearGround,
        PushPlayer,
        InstaDeath
    }
    [SerializeField] typeOfTrap trapType;
    [SerializeField] GameObject trapToTrigger;
    [SerializeField] GameObject playerCharacter;
    #endregion
    #region Methods
    /// <summary>
    /// Checks if the object colliding is the player and sets it to true
    /// </summary>
    /// <param name="collision">the object entering the collider</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (trapType)
            {
                case typeOfTrap.DisappearGround:
                    break;
                case typeOfTrap.PushPlayer:
                    break;
                case typeOfTrap.InstaDeath:
                    playerCharacter.GetComponent<Player>().Dead();
                    //play trap animation
                    //wait till animation ends
                    break;
                default:
                    break;
            }
        }
    }
    #region TypeOfTraps
    private void ResetTrap()
    {
        //stop or reset animation
        //show former sprite
    }
    private void DisappearGroundTrap()
    {
        //trapToTrigger.GetComponent<Rigidbody2D>().
    }
    #endregion
    #endregion
}
