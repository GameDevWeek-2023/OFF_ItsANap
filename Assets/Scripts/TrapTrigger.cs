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
        InstaDeath,
        Jump,
        RotateTrap
    }
    enum direction
    {
        up,
        right,
        down,
        left,
        clockwise,
        counterclockwise
    }
    [SerializeField] typeOfTrap trapType;
    /// <summary>
    /// determines what direction a MoveTrap moves, or if a RotationTrap rotates clockwise or counterclockwise
    /// </summary>
    [SerializeField] direction triggerDirection;
    /// <summary>
    /// determines how many units the MovePlatform Trap travels
    /// or how many degrees the RotationTrap rotates
    /// </summary>
    [SerializeField] float travelDistance;
    [SerializeField] GameObject trapToTrigger;
    [SerializeField] bool moveGround = false;
    [SerializeField] bool dontJump = false;
    [SerializeField] bool rotationTrigger = false;
    private Player player;
    private LoseManager loseManager;
    #endregion
    #region Methods
    private void Start()
    {
        player = FindObjectOfType<Player>();
        loseManager = FindObjectOfType<LoseManager>();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Update()
    {
        if (moveGround)
        {
            MoveGround();
        }
        if (rotationTrigger)
        {
            RotateTheTrap();
        }
        if (dontJump)
        {
            Debug.Log("dwa");
            if (!player.onGround())
            {
                Debug.Log("aa");
                MoveGround();
            }
        }
    }
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
                    Debug.Log("a");
                    StartCoroutine(KillPlayer(1));
                    break;
                case typeOfTrap.Jump:
                    dontJump = true;
                    break;
                case typeOfTrap.RotateTrap:
                    RotationTrap();
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
    IEnumerator KillPlayer(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("a");
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
                    trapToTrigger.transform.Translate(Vector3.up * 20 * Time.deltaTime);
                break;
            case direction.right:
                Debug.Log("flieg nach rechts");
                if (trapToTrigger.transform.position.x < travelDistance)
                    trapToTrigger.transform.Translate(Vector3.right * 20 * Time.deltaTime);
                break;
            case direction.down:
                Debug.Log("flieg nach unten");
                if (trapToTrigger.transform.position.y > -travelDistance)
                    trapToTrigger.transform.Translate(Vector3.down * 20 * Time.deltaTime);
                break;
            case direction.left:
                Debug.Log("flieg nach links");
                if (trapToTrigger.transform.position.x > -travelDistance)
                    trapToTrigger.transform.Translate(Vector3.left * 20 * Time.deltaTime);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// activates the rotation and sets up the rotation for clockwise rotations
    /// </summary>
    private void RotationTrap()
    {
        //check if it wasn't triggered yet
        if (!rotationTrigger)
        {
            switch (triggerDirection)
            {
                //rotates the trap by 1 degree as a setup for the clockwise rotation in RotateTheTrap()
                case direction.clockwise:
                    trapToTrigger.transform.localEulerAngles = new Vector3(0, 0, 359);
                    break;
                default:
                    break;
            }
        }
        rotationTrigger = true;
    }
    /// <summary>
    /// Rotates the Trap, call it in Update
    /// </summary>
    private void RotateTheTrap()
    {
        switch (triggerDirection)
        {
            case direction.clockwise:
                Debug.Log("Im Uhrzeigersinn");
                if (trapToTrigger.transform.localEulerAngles.z > 360 - travelDistance)
                {
                    trapToTrigger.transform.Rotate(new Vector3(0, 0, -25) * Time.deltaTime);
                }
                break;
            case direction.counterclockwise:
                Debug.Log("Gegen Uhrzeigersinn");
                if (trapToTrigger.transform.localEulerAngles.z < travelDistance)
                    trapToTrigger.transform.Rotate(new Vector3(0, 0, 25) * Time.deltaTime);
                break;
            default:
                break;
        }
    }
    #endregion
    #endregion

}
