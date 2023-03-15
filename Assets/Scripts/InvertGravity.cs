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
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer spriteRenderer in spriteRenderers) spriteRenderer.enabled = false;
   }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer spriteRenderer in spriteRenderers) spriteRenderer.enabled = true;
        Physics2D.gravity *= -1;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        Physics2D.gravity *= -1;
    }
}
