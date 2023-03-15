using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D capsuleCollider;

    [SerializeField] private LayerMask groundLayer;

    public float moveForce = 15f;
    public float jumpForce = 5f;
    public float maxSpeed = 5f;
    public Interactable interactable = null;
    public bool dead = false;
    public Vector2 direction;

    public bool flowerCollected = false;

    // last Checkpoint
    [SerializeField] private Vector2 lastCheckpoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            return;
        }
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (interactable == null)
            {
                // Jump
                HandleJump();
            }
            else
            {
               // TODO interact with interactable
               interactable.interact(this);
            }
            
        }
    }

    public void Respawn() 
    {
        // respawn on last checkpoint
        dead = false;
        transform.position = lastCheckpoint;
        Camera.main.transform.position = new Vector3(lastCheckpoint.x, lastCheckpoint.y, Camera.main.transform.position.z);
    }

    public void Dead()
    {
        dead = true;
        // die animation
        // stopp movement    
        Time.timeScale = 0f; 
    }

    public void Teleport(Vector2 destionation)
    {
        transform.position = destionation;
    }

    private void HandleMovement(Vector2 direction)
    {
        if (Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.AddRelativeForce(direction * moveForce);
        }
    }

    private void HandleJump()
    {
        if (!onGround()) return;
        rb.AddRelativeForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public bool onGround()
    {
        RaycastHit2D hit = Physics2D.CapsuleCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 
                                                capsuleCollider.direction, 0, Vector2.down, 0.1f, groundLayer);
        return hit.collider != null;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Interactable")
        {
            interactable = other.GetComponent<Interactable>();
        }
        if (other.tag == "Flower")
        {
            flowerCollected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Interactable")
        {
            interactable = null;
        }
        if (other.tag == "Flower")
        {
            Destroy(other.gameObject);
        }
    }
}
