using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : Interactable
{
    [SerializeField] private Vector2 destination;
    public override void interact(Player player)
    {
        player.Teleport(destination);
    }
}
