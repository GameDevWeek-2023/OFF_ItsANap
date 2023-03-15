using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    #region Fields
    [SerializeField] LoseManager loseManager;
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //disable deathzone and count another loss
            Debug.Log("Player Entered Deathzone");
            //set on false so it doesn't get triggered multiple times
            this.GetComponent<Collider2D>().isTrigger = false;
            //update death counter and kill player
            KillPlayer();
        }
    }
    private void KillPlayer()
    {
        loseManager.UpdateLose();
    }
    #endregion
}
