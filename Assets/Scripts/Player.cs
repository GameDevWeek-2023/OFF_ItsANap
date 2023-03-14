using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D capsuleCollider;

    [SerializeField] private LayerMask groundLayer;

    private float moveForce = 15f;
    private float jumpForce = 40f;
    private float maxSpeed = 5f;
    public Vector2 direction;

    // last Checkpoint
    private Vector2 lastCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // move left
            direction = Vector2.left;
            HandleMovement(Vector2.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // move right
            direction = Vector2.right;
            HandleMovement(Vector2.right);
        }
        if (Input.GetKey(KeyCode.W))
        {
            // Jump
            HandleJump();
        }
    }

    public void Respawn() 
    {
        // respawn on last checkpoint
    }

    private void HandleMovement(Vector2 direction)
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddRelativeForce(direction * moveForce);
        }
    }

    private void HandleJump()
    {
        if (!onGround()) return;
        rb.AddRelativeForce(Vector2.up * jumpForce);
    }

    private bool onGround()
    {
        RaycastHit2D hit = Physics2D.CapsuleCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 
                                                capsuleCollider.direction, 0, Vector2.down, 0.1f, groundLayer);
        return hit.collider != null;
    }
}
