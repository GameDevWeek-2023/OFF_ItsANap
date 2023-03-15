using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Interactable : MonoBehaviour
{

    void Start()
    {
        gameObject.tag = "Interactable";
    }

    abstract public void interact(Player player);
}
