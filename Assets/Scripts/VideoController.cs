using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    
    [SerializeField] VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPaused || Input.GetKeyDown(KeyCode.Escape) )
        {
            Debug.Log("paused");
            SceneManager.LoadScene("MainLevel");
        }
    }
}
