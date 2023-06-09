using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Player player;
    public Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;

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
           animator.SetBool("walking", true);
           transform.localScale = new Vector3(-0.25f, transform.localScale.y, transform.localScale.z);
           boxCollider.offset = new Vector2(-0.3f, boxCollider.offset.y);
           notLeft = false;
        }
        else
        {
            notLeft = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            animator.SetBool("walking", true);
            transform.localScale = new Vector3(0.25f, transform.localScale.y, transform.localScale.z);
            boxCollider.offset = new Vector2(-0.1f, boxCollider.offset.y);
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
