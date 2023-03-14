using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonster : MonoBehaviour
{
    
    private Rigidbody2D player = null;
    [SerializeField] private float eps = 0.01f;
    [SerializeField] private float timer = 1f;
    private float currentTimer;
    private bool followPlayer = false;
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
            Move();
        }
        Debug.Log("Velocity " + player.velocity);
        if (player.velocity.magnitude < eps) 
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
        Debug.Log("Move");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if (!other.TryGetComponent<Rigidbody2D>(out player))
        {
            return;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        player = null;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collsion");
    }
}
