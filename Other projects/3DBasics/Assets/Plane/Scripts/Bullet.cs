using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int Bulletspeed=20;
    public void Shoot(float x)
    {
        Rigidbody rbd = GetComponent<Rigidbody>();        
        transform.localRotation = Quaternion.Euler(0, x, 0);
        rbd.velocity = transform.forward * Bulletspeed;        
        Destroy(gameObject, 6);
    }    
    
    






}
