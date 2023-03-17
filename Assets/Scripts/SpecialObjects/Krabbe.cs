using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krabbe : MonoBehaviour
{
    [SerializeField] private GameObject window;
    [SerializeField] private float destinationY;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Animator animator;
    [SerializeField] private LoseManager loseManager;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float originPosition;
    private Vector3 destination;
    private bool windowDown = false;

    // Start is called before the first frame update
    void Start()
    {
        loseManager = FindObjectOfType<LoseManager>();
        boxCollider = GetComponent<BoxCollider2D>();

        animator.speed = 0;
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;

        originPosition = window.transform.position.y;
        destination = new Vector3(transform.position.x, destinationY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (window.transform.position.y < originPosition)
        {
            windowDown = true;
            
            //transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player" || windowDown == false) return;
        
        
        animator.speed = 1;
        spriteRenderer.enabled = true;
        boxCollider.enabled =true;
        loseManager.UpdateLose();
    }
}
