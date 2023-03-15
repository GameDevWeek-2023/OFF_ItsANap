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
        MovePlatform,
        InstaDeath
    }
    enum direction
    {
        up,
        right,
        down,
        left
    }
    [SerializeField] typeOfTrap trapType;
    [SerializeField] direction triggerDirection;
    [SerializeField] GameObject trapToTrigger;
    [SerializeField] LoseManager loseManager;
    [SerializeField] bool moveGround = false;
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
        moveGround = true;
    }
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
    }
    #endregion
    #endregion

    private void Update()
    {
        if (moveGround)
        {
            MoveGround();
        }
    }
    
    IEnumerator waiter(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
