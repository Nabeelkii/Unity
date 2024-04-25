using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject cam=null;
    [SerializeField] GameObject gunpos = null;
    [SerializeField] GameObject gunbullet=null;
    Rigidbody rbd;
    public bool move = true;
    int movespeed = 5;
    public int Score=0;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();        
    }
    private void Update()
    {
        RotationUpdate();
        if (move)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Bullet();
            }
        }
    }


    private void FixedUpdate()
    {
        if(move)
        {
        Move();
        }
    }

    void Move()
    {
        if(Input.GetKey("w"))
        {
            rbd.velocity = transform.forward * movespeed + transform.up * rbd.velocity.y;
        }
        else if (Input.GetKey("s"))
        {
            rbd.velocity = transform.forward * -movespeed + transform.up * rbd.velocity.y;
        }
        else if (Input.GetKey("a"))
        {
            rbd.velocity = transform.right * -movespeed + transform.up * rbd.velocity.y;
        }
        else if (Input.GetKey("d"))
        {
            rbd.velocity = transform.right * movespeed + transform.up * rbd.velocity.y;
        }
        else
        {
            rbd.velocity = transform.forward * rbd.velocity.x + transform.up * rbd.velocity.y;
        }
        
    }

    void RotationUpdate()
    {
        transform.localRotation = Quaternion.Euler(0, cam.GetComponent<Camerascript>().rotation.y, 0);
    }

    void Bullet()
    {
        GameObject bullet = Instantiate(gunbullet);        
        bullet.transform.position = gunpos.transform.position;
    }
    
    
}
