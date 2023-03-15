using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignFallOver : MonoBehaviour
{
    private bool fallOver;
    public GameObject bla;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (transform.localEulerAngles.x < 80)
            {
                transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime*(transform.localEulerAngles.x+1)/10);
            }
        }
    }
}
