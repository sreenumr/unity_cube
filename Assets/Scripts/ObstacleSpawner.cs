using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]public GameObject obstacle;
    public float maxTime = 2.5f;
    private float timer = 0;
    public float height;

    // Start is called before the first frame update

    void Start()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = transform.position + new Vector3(0,Random.Range(-height,height),0);
        Destroy(newObstacle,5);
    }

    // Update is called once per frame
    void Update()
    {
        spawn();
    }

    void spawn(){
        if(timer > maxTime){
            
            GameObject newObstacle = Instantiate(obstacle);
            newObstacle.transform.position = transform.position + new Vector3(0,Random.Range(-height,height),0);
            Destroy(newObstacle,5);
            timer = 0;
        }
        
        timer += Time.deltaTime;
    }
}
