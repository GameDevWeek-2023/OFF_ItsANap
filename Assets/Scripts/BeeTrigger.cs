using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeTrigger : MonoBehaviour
{


    
    [SerializeField] private GameObject bee;
    [SerializeField] private LayerMask groundLayer;
    public bool attack = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!attack) return;
        if (Distance() > 0)
            bee.transform.Translate(Vector3.up * 10 * Time.deltaTime);
    }

    private float Distance()
    {
        RaycastHit2D hit = Physics2D.Raycast(bee.transform.position, Vector2.down, Mathf.Infinity, groundLayer);
        Debug.Log("h"+ hit.collider);
        if (hit.collider == null) return 0f;
        return Vector2.Distance(bee.transform.position, hit.collider.transform.position);
    }



    private void Attack()
    {
        attack = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player;
        if (!other.TryGetComponent<Player>(out player)) return;
        player.jump += Attack;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player player;
        if (!other.TryGetComponent<Player>(out player)) return;
        player.jump -= Attack;
    }

}
