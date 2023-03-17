using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreamingPilz : MonoBehaviour
{
    [SerializeField] GameObject eyesClosed;
    [SerializeField] GameObject screaming;
    [SerializeField] Text text;
    [SerializeField] GameObject flower;
    public float speed = 10f;
    private Player player; 
    // Start is called before the first frame update
    void Start()
    {
        eyesClosed.SetActive(false);
        screaming.SetActive(true);
        text = GetComponentInChildren<Text>();
        text.enabled = false;
        flower.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        if(Input.GetKeyDown(KeyCode.F) && player.flowerCollected)
        {
            screaming.SetActive(false);
            eyesClosed.SetActive(true);

            flower.SetActive(true);
            flower.transform.position = player.transform.position;
        }
        if(flower.activeSelf)
        {
            flower.transform.position = Vector3.MoveTowards(flower.transform.position, transform.position, speed * Time.deltaTime);
            if (flower.transform.position == transform.position)
            {
                flower.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<Player>(out player)) return;
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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag != "Player") return;
        text.enabled = false;

    }


}
