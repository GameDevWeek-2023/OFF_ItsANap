using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandwichmaker : MonoBehaviour
{
    private float startX;
    private Player player;
    private Transform child;
    
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        player = FindObjectOfType<Player>();
        child = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == startX)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, player.transform.position.y, transform.position.z),transform.rotation);
        }
        child.transform.Rotate(Vector3.forward, 180*Time.deltaTime);
    }
}
