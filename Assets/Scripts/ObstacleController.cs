using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]public float ySpeed = 2f;
    public float maxHeight;
    public float minHeight;
    private Rigidbody2D rigidbody2d;
    private float speed;

    void Start()
    {
        this.speed = GameHandler.obstacleSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(speed);

        transform.position += Vector3.left * speed * Time.deltaTime;
        Debug.Log(transform.position.y);

        transform.position -= Vector3.up * ySpeed * Time.deltaTime;

        //increase speed every n scor

        if(transform.position.y > maxHeight || transform.position.y < minHeight){
            ySpeed *= -1;
        }

    }

    void Update(){

    }
}
