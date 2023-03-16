using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiggleStone : MonoBehaviour
{
    [SerializeField] private float degree = 5f;
    [SerializeField] private float speed = 30f;
    [SerializeField] private float scale = .001f;
    public bool jiggle = false;
    private float xScale;
    private float yScale;
    // Start is called before the first frame update
    void Awake()
    {
        if (GetComponent<BoxCollider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
    }
    
    void Start()
    {       
        
        xScale = transform.localScale.x;
        yScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!jiggle) return;
        jiggleRotate();  
        jiggleScale();
    }

    private void jiggleRotate()
    {
        float r = degree * Mathf.Sin(speed * Time.time);
        transform.eulerAngles = new Vector3(0, 0, r);
    }

    private void jiggleScale()
    {
        float r = 1 + scale * Mathf.Cos(speed * Time.time);
        transform.localScale = new Vector3(r * xScale, r * yScale, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player") return;
        jiggle = true;
    }
}
