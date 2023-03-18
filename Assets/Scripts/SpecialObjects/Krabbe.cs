using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krabbe : MonoBehaviour
{
    [SerializeField] private GameObject window;
    [SerializeField] private float destinationY;
    [SerializeField] private Animator animator;
    [SerializeField] private LoseManager loseManager;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource audioSource;
    private float originPosition;
    private bool windowDown = false;

    // Start is called before the first frame update
    void Start()
    {
        loseManager = FindObjectOfType<LoseManager>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

        animator.speed = 0;
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;

        originPosition = window.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (window.transform.position.y < originPosition && !windowDown)
        {
            Snap();
            windowDown = true;           
            
            //transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
    }

    private void Snap()
    {
        animator.speed = 1;
        audioSource.Play();
        spriteRenderer.enabled = true;
        boxCollider.enabled =true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player" || windowDown == false) return;
        
        loseManager.UpdateLose();
    }
}
