using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]public float speed = 40f;
    [SerializeField]public float upSpeed = 40f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        // transform.position += Vector3.up * upSpeed * Time.deltaTime;
    }
}
