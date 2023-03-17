using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignFallOver : MonoBehaviour
{
    private bool fallOver;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fallOver = true;
        }
    }

    private void Update()
    {
        if (transform.localEulerAngles.x < 80 && fallOver)
        {
            transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime*(transform.localEulerAngles.x+1)/10);
        }
        else
        {

        }
    }
}
