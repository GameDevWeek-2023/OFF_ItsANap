using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonster : MonoBehaviour
{
    [SerializeField] LoseManager loseManager;
    private Rigidbody2D player = null;
    private bool playerInRange = false;
    [SerializeField] private float eps = 0.01f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float timer = 1f;
    private float currentTimer;
    private bool followPlayer = false;

    void Awake()
    {
        loseManager = FindObjectOfType<LoseManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        if (followPlayer)
        {
            if (PlayerCollision())
            {
                // kill Player
                loseManager.UpdateLose();
            } 
            else 
            {
                Move();
            }
            
        }
        if (playerInRange && player.velocity.magnitude < eps) 
        {
            if (currentTimer <= 0)
            {
                // Follow player
                followPlayer = true;
            } 
            else 
            {
                currentTimer -= Time.deltaTime;
            }
        }
        else 
        {
            currentTimer = timer;
        }
    }

    private void Move()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime * speed;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        if (!other.TryGetComponent<Rigidbody2D>(out player))
        {
            return;
        }
        playerInRange = true;

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        loseManager.UpdateLose();
    }

    private bool PlayerCollision()
    {
        if (player == null) return false;
        if ((player.transform.position - transform.position).magnitude < eps) return true;
        return false;
    }
}
