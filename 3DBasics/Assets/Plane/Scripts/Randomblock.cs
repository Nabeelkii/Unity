using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Randomblock : MonoBehaviour
{
    Object Spawned;
    [SerializeField] float rotationspeed = 0.5F;
    

    void Start()
    {
        Spawned = Resources.Load("Bullet");        
    }

    void Update()
    {
        transform.RotateAround(new Vector3(0,4,0), transform.up, rotationspeed);        
        transform.RotateAround(target.spot,transform.up,rotationspeed)
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag=="Bullet")
        {
            GameObject balls = (GameObject)Instantiate(Spawned);
            balls.transform.position = new Vector3(transform.position.x, 10, transform.position.z);
            Destroy(balls, 6);            
        }       
       
    }
   

}
