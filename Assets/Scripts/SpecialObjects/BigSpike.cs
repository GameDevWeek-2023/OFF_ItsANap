using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSpike : MonoBehaviour
{
    [SerializeField] GameObject spike;
    [SerializeField] GameObject mushroom;
    [SerializeField] float spikeMoveTo;
    [SerializeField] float mushroomMoveTo;
    [SerializeField] bool playerInRange = false;
    public float speed = 10f;
    private int moveSpike = 0;
    private Vector3 spikeDestination;
    private Vector3 spikeOrigin;
    // Start is called before the first frame update
    void Start()
    {
        spikeDestination = new Vector3(spike.transform.position.x, spikeMoveTo, spike.transform.position.z);
        spikeOrigin = spike.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInRange) return;
        if (moveSpike > 0)
        {
            spike.transform.position = Vector3.MoveTowards(spike.transform.position, spikeDestination, speed * Time.deltaTime);
        }
        else if (moveSpike < 0)
        {
            spike.transform.position = Vector3.MoveTowards(spike.transform.position, spikeOrigin, speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player;
        if (!other.TryGetComponent<Player>(out player)) return;
        player.jump += playerJumped;
        playerInRange = true;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player player;
        if (!other.TryGetComponent<Player>(out player)) return;
        player.jump -= playerJumped;
        playerInRange = false;
    }

    private void playerJumped()
    {

    }
}
