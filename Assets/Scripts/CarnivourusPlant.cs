using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivourusPlant : MonoBehaviour
{
    [SerializeField] private GameObject window;
    [SerializeField] private float destinationY;
    [SerializeField] private float speed = 10f;
    private float originPosition;
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        originPosition = window.transform.position.y;
        destination = new Vector3(transform.position.x, destinationY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (window.transform.position.y < originPosition)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
    }
}
