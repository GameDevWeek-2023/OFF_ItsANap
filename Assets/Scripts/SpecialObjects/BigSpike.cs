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
    public float delay = 3f;
    private int moveSpike = 0;
    private Vector3 spikeDestination;
    private Vector3 spikeOrigin;
    private Player player;
    private float groundY;
    // Start is called before the first frame update
    void Start()
    {
        spikeDestination = new Vector3(spike.transform.position.x, spikeMoveTo, spike.transform.position.z);
        spikeOrigin = spike.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        if (player.onGround())
        {
            groundY = player.transform.position.y;
        }
        if (moveSpike > 0)
        {
            spike.transform.position = Vector3.MoveTowards(spike.transform.position, spikeDestination, speed * Time.deltaTime);
            if (spike.transform.position.y == spikeMoveTo)
            {
                StartCoroutine(WaitSpike(delay));
            }
        }
        else if (moveSpike < 0)
        {
            spike.transform.position = Vector3.MoveTowards(spike.transform.position, spikeOrigin, speed * Time.deltaTime);
        }

        //if (moveSpike <= 0 && )

    }

    IEnumerator WaitSpike(float delay)
    {
        yield return new WaitForSeconds(delay);
        moveSpike = -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<Player>(out player)) return;
        player.jump += playerJumped;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent<Player>(out player)) return;
        player.jump -= playerJumped;
        player = null;
    }

    private void playerJumped()
    {
        moveSpike = 1;
    }
}
