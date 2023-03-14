using System;
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
        InstaDeath,
        pickFlower
    }
    [SerializeField] typeOfTrap trapType;
    [SerializeField] GameObject trapToTrigger;
    [SerializeField] GameObject loseManager;

    private bool moveGround = false;
    #endregion
    #region Methods
    /// <summary>
    /// Checks if the object colliding is the player and sets it to true
    /// </summary>
    /// <param name="collision">the object entering the collider</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (trapType)
            {
                case typeOfTrap.DisappearGround:
                    DisappearGroundTrap();
                    break;
                case typeOfTrap.PushPlayer:
                    break;
                case typeOfTrap.InstaDeath:
                    //play trap animation
                    //wait till animation ends
                    KillPlayer();
                    break;
                case typeOfTrap.pickFlower:
                    PickFlower();
                    break;
                default:
                    break;
            }
        }
    }
    private void KillPlayer()
    {
        loseManager.GetComponent<LoseManager>().UpdateLose();
    }
    #region TypeOfTraps
    private void DisappearGroundTrap()
    {
        trapToTrigger.GetComponent<GameObject>().SetActive(false);
    }
    private void PushPlayerTrap()
    {
        //push into direction
        //trapToTrigger.GetComponent<Transform>().
    }

    private void PickFlower()
    {
        moveGround = true;
    }

    private void MoveGround()
    {
        
    }
    
    #endregion
    #endregion

    private void Update()
    {
        if (moveGround)
        {
            if(trapToTrigger.transform.position.y > -100)
                trapToTrigger.transform.Translate(Vector3.down*10*Time.deltaTime);
        }
    }
}
