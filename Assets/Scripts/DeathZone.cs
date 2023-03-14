using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    #region Fields
    [SerializeField] GameObject loseManager;
    #endregion
    #region Methods
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<Collider2D>().enabled = false;
            loseManager.GetComponent<LoseManager>().UpdateLose();
        }
    }
    #endregion
}
