using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamingPilz : MonoBehaviour
{
    [SerializeField] GameObject eyesClosed;
    [SerializeField] GameObject screaming;
    // Start is called before the first frame update
    void Start()
    {
        eyesClosed.SetActive(false);
        screaming.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player;
        if (!other.TryGetComponent<Player>(out player)) return;
        if (player.flowerCollected)
        {
            screaming.SetActive(false);
            eyesClosed.SetActive(true);
        }
    }


}
