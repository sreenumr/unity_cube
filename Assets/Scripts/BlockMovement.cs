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
    private int rotationSpeed;
    private int maxRotationSpeed = -10;
    private int multiplier = 35; 
    private float zRotation;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        transform.position =  transform.position + new Vector3(0,Random.Range(-height,height),0);
        this.ySpeed= GameHandler.obstacleYSpeed;
        System.Random random = new System.Random();
        this.ySpeed *=  randInt[random.Next(0,randInt.Length)];
        maxRotationSpeed *= multiplier;
        this.rotationSpeed = Random.Range(-maxRotationSpeed,maxRotationSpeed);
        Debug.Log("[INFO] Rotation Speed " + rotationSpeed);
        
        audioSource = GetComponent<AudioSource> ();

    }

    // Update is called once per frame

    void Update(){
        // Debug.Log("[INFO] Rotation " + transform.rotation);
    }

    void FixedUpdate()
    {   

        zRotation +=  Time.deltaTime * rotationSpeed;
        Debug.Log("[INFO] Rotation " + transform.rotation);
    
        transform.rotation = Quaternion.Euler(0,0,zRotation);
        transform.position -= Vector3.up * ySpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.layer == 10){ //Int value of layer from Layer Dropdown
            ySpeed *= -1;
        }

        audioSource.Play();

        Debug.Log("Obstacle block collided " + collision);
    }
}
