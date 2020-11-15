using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleController : MonoBehaviour
{
    // Start is called before the first frame update
    private float xSpeed;

    void Start()
    {
        this.xSpeed = GameHandler.obstacleXSpeed;
        Debug.Log("Screen :: " + Screen.height);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.left * xSpeed * Time.deltaTime;
        // Debug.Log(transform.position.y);
    }


}
