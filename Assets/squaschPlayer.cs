using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squaschPlayer : MonoBehaviour
{
    private CameraController cameraController;
    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cameraController.enabled = false;
        }
    }
}
