using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class CreditsScrollScript : MonoBehaviour
{
    private Image creditsImage;
    // Start is called before the first frame update
    void Start()
    {
        creditsImage = FindObjectOfType<Image>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("MainLevel");
        }
        else if(creditsImage.rectTransform.position.y >= 63)
        {
            CreditWait();
            Time.timeScale = 0;
            SceneManager.LoadScene("MainLevel");
        }
        else
        {
            Debug.Log(Convert.ToString(creditsImage.rectTransform.position.y));
            creditsImage.transform.Translate(Vector3.up * 3 * Time.deltaTime);
        }
    }
    IEnumerator CreditWait()
    {
        yield return new WaitForSeconds(5);
    }
}
