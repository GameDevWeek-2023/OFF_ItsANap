using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreamingPilz : MonoBehaviour
{
    [SerializeField] GameObject eyesClosed;
    [SerializeField] GameObject screaming;
    [SerializeField] Text text;
    [SerializeField] GameObject hotdog;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip screamStart;
    [SerializeField] AudioClip screamLoop;
    [SerializeField] AudioClip eatHotDog;
    public float speed = 10f;
    public bool happy = false;
    private bool audioStarted = false;
    private Player player; 
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        eyesClosed.SetActive(false);
        screaming.SetActive(true);
        text = GetComponentInChildren<Text>();
        text.enabled = false;
        hotdog.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        if(happy)
        {
            hotdog.transform.position = Vector3.MoveTowards(hotdog.transform.position, transform.position, speed * Time.deltaTime);
            if (hotdog.transform.position == transform.position)
            {
                hotdog.SetActive(false);
            }
            return;
        }
        if(Input.GetKeyDown(KeyCode.F) && player.flowerCollected)
        {
            screaming.SetActive(false);
            eyesClosed.SetActive(true);

            //audioSource.enabled = false;
            StopCoroutine(coroutine);
            audioSource.clip = eatHotDog;
            audioSource.loop = false;
            audioSource.Play();
            happy = true;

            hotdog.SetActive(true);
            hotdog.transform.position = player.transform.position;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<Player>(out player) || happy) return;
        Debug.Log("OnTrigger");
        text.enabled = true;
        if (player.flowerCollected)
        {
            Color tmp = text.color;
            tmp.a = 1f;
            text.color = tmp;
        } else {
            Color tmp = text.color;
            tmp.a = 0.5f;
            text.color = tmp;
        }
        if (!audioStarted)
        {
            coroutine = playScream();
            StartCoroutine(coroutine);
            audioStarted = true;
        }
        
        

    }

    IEnumerator playScream()
    {
        audioSource.clip = screamStart;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = screamLoop;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag != "Player") return;
        text.enabled = false;

    }


}
