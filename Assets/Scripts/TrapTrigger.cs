using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    #region Fields
    [SerializeField] GameObject trapToTrigger;
    [SerializeField] GameObject deathZone;
    [SerializeField] GameObject deathCounter;
    #endregion
    #region Methods
    /// <summary>
    /// Checks if the object colliding is the player and sets it to true
    /// </summary>
    /// <param name="collision">the object entering the collider</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //play animation
            //wait till animation ends
            deathZone.GetComponent<Collider2D>().enabled = true;
        }
    }
    private void ResetTrap()
    {
        //stop or reset animation
        //show former sprite
    }
    #endregion
}
