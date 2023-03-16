using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBlock : MonoBehaviour
{
    enum spikeDirektion {
        up = 1,
        down = -1
    }
    
    [SerializeField] private Animator anim;
    [SerializeField] private spikeDirektion direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        Debug.Log("Trigger");
        anim.SetInteger("direction", (int) direction);
    }
}
