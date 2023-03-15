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
<<<<<<< HEAD
        PushPlayer,
        InstaDeath,
        pickFlower,
        moveGroundUp
=======
        MovePlatform,
        InstaDeath
    }
    enum direction
    {
        up,
        right,
        down,
        left
>>>>>>> origin/main
    }
    [SerializeField] typeOfTrap trapType;
    [SerializeField] direction triggerDirection;
    [SerializeField] GameObject trapToTrigger;
    [SerializeField] LoseManager loseManager;
<<<<<<< HEAD

    private bool moveGroundDown = false;
    private bool moveGroundUp = false;
    
=======
    [SerializeField] bool moveGround = false;
>>>>>>> origin/main
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
                case typeOfTrap.MovePlatform:
                    break;
                case typeOfTrap.InstaDeath:
                    //play trap animation
                    //wait till animation ends
                    KillPlayer(1);
                    break;
<<<<<<< HEAD
                case typeOfTrap.pickFlower:
                    PickFlower();
                    break;
                case typeOfTrap.moveGroundUp:
                    MoveGroundUp();
                    break;
=======
>>>>>>> origin/main
                default:
                    break;
            }
        }
    }
    private void KillPlayer(float delay)
    {
        waiter(delay);
        loseManager.UpdateLose();
    }
    #region TypeOfTraps
    private void DisappearGroundTrap()
    {
        trapToTrigger.GetComponent<GameObject>().SetActive(false);
    }
    private void MovePlatformTrap()
    {
        moveGroundDown = true;
    }
<<<<<<< HEAD

    private void MoveGroundDown()
    {
        moveGroundDown = true;
    }
    
    private void MoveGroundUp()
    {
        moveGroundUp = true;
=======
    /// <summary>
    /// moves the platform into a selected direction
    /// </summary>
    private void MoveGround()
    {
        switch (triggerDirection)
        {
            case direction.up:
                break;
            case direction.right:
                break;
            case direction.down:
                if (trapToTrigger.transform.position.y > -100)
                    trapToTrigger.transform.Translate(Vector3.down * 10 * Time.deltaTime);
                break;
            case direction.left:
                break;
            default:
                break;
        }
>>>>>>> origin/main
    }
    #endregion
    #endregion

    private void Update()
    {
        if (moveGroundDown)
        {
            MoveGround();
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
