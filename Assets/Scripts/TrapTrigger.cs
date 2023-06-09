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
        RotateTrap,
        Visable,
        PlayAnimation
    }
    enum direction
    {
        up,
        right,
        down,
        rightdown,
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
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    public float killduration;
    public float moveTrapSpeed = 20;
    private Player player;
    private LoseManager loseManager;
    #endregion
    #region Methods
    private void Start()
    {
        player = FindObjectOfType<Player>();
        loseManager = FindObjectOfType<LoseManager>();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (animator != null)
        {
            animator.speed = 0;
        }
        if (audioSource == null && trapToTrigger != null)
        {
            trapToTrigger.TryGetComponent<AudioSource>(out audioSource);
        }
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
            MoveGround();
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
            if (animator != null)
            {
                animator.speed = 1;
            }
            if (audioSource != null)
            {
                audioSource.enabled = true;
                Debug.Log("Play Audio " + audioSource.clip.name);
                if (trapType != typeOfTrap.Jump)
                {
                    
                }
                
            }
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
                    StartCoroutine(KillPlayer(killduration));
                    break;
                case typeOfTrap.Jump:
                    //dontJump = true;
                    player.jump += DontJump;
                    break;
                case typeOfTrap.RotateTrap:
                    RotationTrap();
                    break;
                case typeOfTrap.Visable:
                    trapToTrigger.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player") return;
        if (audioSource != null) audioSource.enabled = false;
        player.jump -= DontJump;
    }
    /// <summary>
    /// Kills the player after a delay
    /// </summary>
    /// <param name="delay"></param>
    public IEnumerator KillPlayer(float delay)
    {
        player.dead = true;
        yield return new WaitForSeconds(delay);
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
                    trapToTrigger.transform.Translate(Vector3.up * moveTrapSpeed * Time.deltaTime);
                break;
            case direction.right:
                Debug.Log("flieg nach rechts");
                if (trapToTrigger.transform.position.x < travelDistance)
                    trapToTrigger.transform.Translate(Vector3.right * moveTrapSpeed * Time.deltaTime);
                break;
            case direction.down:
                Debug.Log("flieg nach unten");
                if (trapToTrigger.transform.position.y > -travelDistance)
                    trapToTrigger.transform.Translate(Vector3.down * moveTrapSpeed * Time.deltaTime);
                break;
            case direction.rightdown:
                if (trapToTrigger.transform.position.y > -travelDistance)
                    trapToTrigger.transform.Translate(new Vector3(1, -1, 0) * moveTrapSpeed * Time.deltaTime);
                break;
            case direction.left:
                Debug.Log("flieg nach links");
                if (trapToTrigger.transform.position.x > -travelDistance)
                    trapToTrigger.transform.Translate(Vector3.left * moveTrapSpeed * Time.deltaTime);
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

    private void DontJump()
    {
        if (audioSource != null) audioSource.enabled = true;
        dontJump = true;
    }

}
