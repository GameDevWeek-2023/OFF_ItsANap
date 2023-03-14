using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Player target;
    private float offset = 10f;
    private float offsetSmoothing;
    private Vector3 targetPositon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPositon = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        if (target.direction.x > 0)
        {
            targetPositon = new Vector3(targetPositon.x + offset, targetPositon.y, targetPositon.z);
        } 
        else
        {
            targetPositon = new Vector3(targetPositon.x - offset, targetPositon.y, targetPositon.z);
        }
        transform.position = Vector3.Lerp(transform.position, targetPositon, offsetSmoothing * Time.deltaTime);
        
    }
}
