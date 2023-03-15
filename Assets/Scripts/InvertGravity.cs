using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertGravity : MonoBehaviour
{
    public GameObject stairs;
   void Awake()
   {
        if (GetComponent<BoxCollider2D>() == null)
        {
            Debug.LogError("Add Trigger to " + name);
        }
        stairs.SetActive(false);
   }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        stairs.SetActive(true);
        Physics2D.gravity *= -1;
    }
}
