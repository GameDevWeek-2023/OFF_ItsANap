using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Player player;
    public Animator animator;

    private bool notLeft;
    private bool notRight;

    private void Start()
    {
        player.jump += JumpAnim;
    }

    void Update()
    {
        if (player.dead)
        {
            animator.SetBool("dead", true);
            return;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            Debug.Log("a");
           animator.SetBool("walking", true);
           transform.localScale = new Vector3(-0.25f, transform.localScale.y, transform.localScale.z);
           notLeft = false;
        }
        else
        {
            notLeft = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            Debug.Log("d");
            animator.SetBool("walking", true);
            transform.localScale = new Vector3(0.25f, transform.localScale.y, transform.localScale.z);
            notRight = false;
        }
        else
        {
            notRight = true;
        }

        if (notLeft && notRight)
        {
            animator.SetBool("walking", false);
        }


        if(player.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0.01f && player.onGround())
            animator.SetBool("jumping", false);

    }

    void JumpAnim()
    {
        animator.SetBool("jumping", true);
    }
}
