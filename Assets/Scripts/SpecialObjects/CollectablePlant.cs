using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablePlant : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private AudioSource audioSource;
    private Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        audioSource = GetComponent<AudioSource>();
        text.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(player == null) return;
        if(Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(collectFlower());
        }
    }

    IEnumerator collectFlower()
    {
        player.flowerCollected = true;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject);
    }

    public void PlayerInRange(Player p)
    {
        text.enabled = true;
        player = p;
    }

    public void PlayerOutOfRange()
    {
        text.enabled = false;
        player = null;
    }
}
