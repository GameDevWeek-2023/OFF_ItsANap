using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    #region Fields
    [SerializeField] GameObject loseManager;
    [SerializeField] bool isAlwaysActive;
    [SerializeField] GameObject playerCharacter;
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //disable deathzone and count another loss
            Debug.Log("Player Entered Deathzone");
            this.GetComponent<Collider2D>().isTrigger = false;
            loseManager.GetComponent<LoseManager>().UpdateLose();
            playerCharacter.GetComponent<Player>().Dead();
        }
    }
    public void ResetTrigger()
    {
        this.GetComponent<Collider2D>().isTrigger = isAlwaysActive;
    }
    #endregion
}
