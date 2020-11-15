using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField]public float ySpeed = GameHandler.obstacleYSpeed;
    private float maxHeight = 45;
    private float minHeight = -30;
    private int[] randInt = {-1,1};

    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        this.ySpeed *=  randInt[random.Next(0,randInt.Length)];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= Vector3.up * ySpeed * Time.deltaTime;

        //increase speed every n scor

        if(transform.position.y > maxHeight || transform.position.y < minHeight){
            ySpeed *= -1;
        }
    }
}
