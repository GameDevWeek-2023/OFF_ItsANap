using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    #region Fields
    enum typeOfTrap
    {
        DisappearGround,
        MovePlatform,
        InstaDeath,
        Jump
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
    [SerializeField] float travelDistance;
    [SerializeField] GameObject trapToTrigger;
    [SerializeField] LoseManager loseManager;
    [SerializeField] bool moveGround = false;
    [SerializeField] bool dontJump = false;
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
                    MovePlatformTrap();
                    break;
                case typeOfTrap.InstaDeath:
                    //play trap animation
                    //wait till animation ends
                    KillPlayer(1);
                    break;
                case typeOfTrap.Jump:
                    dontJump = true;
                    break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// Kills the player after a delay
    /// </summary>
    /// <param name="delay"></param>
    private void KillPlayer(float delay)
    {
        waiter(delay);
        loseManager.UpdateLose();
    }
    #region TypeOfTraps
    private void DisappearGroundTrap()
    {
        Debug.Log("platform deaktiviert. lmao git rekt");
        trapToTrigger.SetActive(false);
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
                Debug.Log("flieg nach oben");
                if (trapToTrigger.transform.position.y < travelDistance)
                    trapToTrigger.transform.Translate(Vector3.up * 10 * Time.deltaTime);
                break;
            case direction.right:
                Debug.Log("flieg nach rechts");
                if (trapToTrigger.transform.position.x < travelDistance)
                    trapToTrigger.transform.Translate(Vector3.right * 10 * Time.deltaTime);
                break;
            case direction.down:
                Debug.Log("flieg nach unten");
                if (trapToTrigger.transform.position.y > -travelDistance)
                    trapToTrigger.transform.Translate(Vector3.down * 10 * Time.deltaTime);
                break;
            case direction.left:
                Debug.Log("flieg nach links");
                if (trapToTrigger.transform.position.x > -travelDistance)
                    trapToTrigger.transform.Translate(Vector3.left * 10 * Time.deltaTime);
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

        if (dontJump)
        {
            if (!player.onGround())
            {
                Debug.Log("aa");
                MoveGround();
            }
        }
    }
    
    IEnumerator waiter(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
