using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField]public float ySpeed;
    private float height=30f;
    private float maxHeight = 45;
    private float minHeight = -30;
    private int[] randInt = {-1,1};

    // Start is called before the first frame update
    void Start()
    {
        transform.position =  transform.position + new Vector3(0,Random.Range(-height,height),0);
        this.ySpeed= GameHandler.obstacleYSpeed;
        System.Random random = new System.Random();
        this.ySpeed *=  randInt[random.Next(0,randInt.Length)];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= Vector3.up * ySpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.layer == 10){ //Int value of layer from Layer Dropdown
            ySpeed *= -1;
        }

        Debug.Log("Obstacle block collided " + collision);
    }
}
