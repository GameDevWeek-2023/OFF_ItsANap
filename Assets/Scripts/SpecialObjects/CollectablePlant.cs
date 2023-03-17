using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablePlant : MonoBehaviour
{
    [SerializeField] private Text text;
    private Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null) return;
        if(Input.GetKeyDown(KeyCode.F))
        {
            player.flowerCollected = true;
            Destroy(gameObject);
        }
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
