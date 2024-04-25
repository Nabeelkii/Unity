using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]GameObject bullet=null;
    void Start()
    {
        InvokeRepeating("Shoot", 0.5F, 0.1F);        
    }
    

    void Shoot()
    {
        GameObject bullets = Instantiate(bullet);
        bullets.GetComponent<Laserbeam>();
        bullets.transform.position = transform.position;
        bullets.transform.rotation = transform.rotation;       
    }
}
