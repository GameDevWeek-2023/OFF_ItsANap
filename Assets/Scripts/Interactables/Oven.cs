using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Oven : Interactable
{
    [SerializeField] private Vector2 destination;
    [SerializeField] private SpriteRenderer openSprite;
    [SerializeField] private SpriteRenderer closedSprite;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void interact(Player player)
    {
        player.Teleport(destination);
        Debug.Log(audioSource.clip.name);
        audioSource.Play();
    }

    public void HoverPlayer(bool b)
    {
        if (b)
        {
            openSprite.gameObject.SetActive(true);
            closedSprite.gameObject.SetActive(false);
        }
        else
        {
            openSprite.gameObject.SetActive(false);
            closedSprite.gameObject.SetActive(true);
        }
    }
}
