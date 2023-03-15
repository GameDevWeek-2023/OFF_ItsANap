using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertGravity : MonoBehaviour
{
   
   void Awake()
   {
        if (GetComponent<BoxCollider2D>() == null)
        {
            Debug.LogError("Add Trigger to " + name);
        }
   }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        Physics2D.gravity *= -1;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        Physics2D.gravity *= -1;
    }
}
