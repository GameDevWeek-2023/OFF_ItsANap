using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    private AudioManager audioManager;
    //[SerializeField] private CapsuleCollider2D capsuleCollider;
    private BoxCollider2D boxCollider;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioSource dieSound;
    [SerializeField] private AudioSource jumpSound;
    public delegate void Jump();
    public Jump jump;

    public float moveForce = 15f;
    public float jumpForce = 5f;
    public float maxSpeed = 5f;
    public Interactable interactable = null;
    public bool dead = false;
    public int direction;

    public bool flowerCollected = false;

    private Vector2 up {
        get { return -1 * Physics2D.gravity.normalized; }
    }
    private Vector2 down {
        get { return Physics2D.gravity.normalized; }
    }

    // last Checkpoint
    [SerializeField] private Vector2 lastCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        jump += HandleJump;
        boxCollider = GetComponent<BoxCollider2D>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead || !(GameState.state==stateOfGame.running))
        {
            return;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // move left
            direction = -1;
            HandleMovement();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // move right
            direction = 1;
            HandleMovement();
        }
        if ((Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.UpArrow)) ||
            (!Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.UpArrow)) ||
            (!Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (interactable == null)
            {
                // Jump
                jump?.Invoke();
            }
            else
            {
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
        dieSound.Play();
        // die animation in Animation Controller
        // stopp movement    
        StartCoroutine(StopTime());

    }

    public IEnumerator StopTime()
    {
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0; 
    }

    public void Teleport(Vector2 destination)
    {
        transform.position = destination;
    }

    private void HandleMovement()
    {
        /*
        if (Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.AddRelativeForce(direction * moveForce);
        }
        */
        float d = direction * maxSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + d, transform.position.y, transform.position.z);
    }

    private void HandleJump()
    {
        if(onGround() && rb.velocity.y < 0.01f)
        {
            rb.AddRelativeForce(up * jumpForce, ForceMode2D.Impulse);
            jumpSound.Play();
        }
        
    }

    public bool onGround()
    {
        RaycastHit2D hit = Physics2D.CapsuleCast(boxCollider.bounds.center, boxCollider.bounds.size, 
                                                CapsuleDirection2D.Vertical, 0, down, 0.1f, groundLayer);
        //RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider)
        //if (hit.collider != null) Debug.Log("hit " + hit.collider.name);
        
        return hit.collider != null;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Interactable")
        {
            interactable = other.GetComponent<Interactable>();
            if (other.GetComponent<Oven>() != null)
            {
                other.GetComponent<Oven>().HoverPlayer(true);
            }
            
        }
        if (other.tag == "Flower")
        {
            other.GetComponent<CollectablePlant>().PlayerInRange(this);
            
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Interactable")
        {
            interactable = null;
            other.GetComponent<Oven>().HoverPlayer(false);
        }
        if (other.tag == "Flower")
        {
            other.GetComponent<CollectablePlant>().PlayerOutOfRange();
        }
    }
}
