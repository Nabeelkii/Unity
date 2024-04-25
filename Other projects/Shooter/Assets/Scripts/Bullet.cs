using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rbd;
    GameObject player;
    GameObject camer;
    int bulletspeed = 30;
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        camer = GameObject.FindGameObjectWithTag("MainCamera");
        transform.rotation = player.transform.rotation;
        rbd.velocity = camer.transform.forward * bulletspeed;
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
