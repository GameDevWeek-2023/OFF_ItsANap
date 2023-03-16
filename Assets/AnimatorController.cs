using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Player player;
    public Animator animator;

    private void Start()
    {
        player.jump += JumpAnim;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            Debug.Log("a");
           animator.SetBool("walking", true);
           transform.localScale = new Vector3(-0.25f, transform.localScale.y, transform.localScale.z);
        }
        if (Input.GetKey(KeyCode.D)) {
            Debug.Log("d");
            animator.SetBool("walking", true);
            transform.localScale = new Vector3(0.25f, transform.localScale.y, transform.localScale.z);
        }


        if(player.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0.01f && player.onGround())
            animator.SetBool("jumping", false);
        
        
        if(player.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0.01f)
            animator.SetBool("walking", false);
    }

    void JumpAnim()
    {
        animator.SetBool("jumping", true);
    }
}