using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappingPlant : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private LoseManager loseManager;
    [SerializeField] private PolygonCollider2D col;
    
    // Start is called before the first frame update
    void Start()
    {
        anim.speed = 0;
        loseManager = FindObjectOfType<LoseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player;
        if (!other.TryGetComponent<Player>(out player)) return;
        player.jump += PlayerJumped;
        

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player player;
        if (!other.TryGetComponent<Player>(out player)) return;
        player.jump -= PlayerJumped;
    }

    private void PlayerJumped()
    {
        anim.speed = 1;
        //StartCoroutine(KillPlayer(1));
        col.enabled = false;
    }

    IEnumerator KillPlayer(float delay)
    {
        yield return new WaitForSeconds(delay);
        loseManager.UpdateLose();
    }
}
