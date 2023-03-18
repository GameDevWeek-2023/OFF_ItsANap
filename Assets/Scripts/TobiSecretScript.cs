using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TobiSecretScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer tobiFace;
    private Player playerCharacter;
    private string cheatCode = "";
    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = FindObjectOfType<Player>();
        tobiFace.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && !Input.GetKeyDown(KeyCode.T) && !Input.GetKeyDown(KeyCode.O) && !Input.GetKeyDown(KeyCode.B) && !Input.GetKeyDown(KeyCode.I))
        {
            cheatCode = "";
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            cheatCode = "";
            cheatCode += "t";
        }
        if (Input.GetKeyDown(KeyCode.O) && cheatCode == "t")
        {
            cheatCode += "o";
        }
        if (Input.GetKeyDown(KeyCode.B) && cheatCode == "to")
        {
            cheatCode += "b";
        }
        if (Input.GetKeyDown(KeyCode.I) && cheatCode == "tob")
        {
            cheatCode = "";
            tobiFace.enabled = true;
        }
        if (playerCharacter.dead)
        {
            tobiFace.enabled = false;
        }
    }
}
