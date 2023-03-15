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
        pickFlower,
        moveGroundUp
    }
    [SerializeField] typeOfTrap trapType;
    [SerializeField] GameObject trapToTrigger;
    [SerializeField] GameObject loseManager;

    private bool moveGroundDown = false;
    private bool moveGroundUp = false;
    
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
                    KillPlayer(1);
                    break;
                case typeOfTrap.pickFlower:
                    PickFlower();
                    break;
                case typeOfTrap.moveGroundUp:
                    MoveGroundUp();
                    break;
                default:
                    break;
            }
        }
    }
    private void KillPlayer(float delay)
    {
        waiter(delay);
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
        moveGroundDown = true;
    }

    private void MoveGroundDown()
    {
        moveGroundDown = true;
    }
    
    private void MoveGroundUp()
    {
        moveGroundUp = true;
    }
    
    #endregion
    #endregion

    private void Update()
    {
        if (moveGroundDown)
        {
            if(trapToTrigger.transform.position.y > -100)
                trapToTrigger.transform.Translate(Vector3.down*10*Time.deltaTime);
        }

        if (moveGroundUp)
        {
            if (trapToTrigger.transform.position.y < 100)
            {
                trapToTrigger.transform.Translate(Vector3.up*20*Time.deltaTime);
                FindObjectOfType<CameraController>().enabled = false;
                KillPlayer(3);
            }
        }
    }
    
    IEnumerator waiter(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
