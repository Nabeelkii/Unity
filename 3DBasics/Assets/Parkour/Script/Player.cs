using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform shoot=null;
    [SerializeField] GameObject pausemenu=null;    
    Vector3 target;    
    Rigidbody rbd;    
    int movespeed = 3;
    int jumpforce = 6;    
    float playerdist = 0.6F;
    bool grounded = true;
    bool wallrun = false;
    bool grapple = false;
    bool pause = false;
    LineRenderer lr;
    public int hookcount = 0;
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        pausemenu.SetActive(false);
    }

    void Update()
    {
        Grapple();       
        Grounded();
        DrawRope();
        Pause();
    }
    void FixedUpdate()
    {
        Move();       
    }

    void Move()
    {
        if (Input.GetKey("w"))
        {
            if(wallrun)
            {
                rbd.velocity = transform.forward * movespeed;
            }
            else if(!wallrun)
            {
                rbd.velocity = transform.forward * movespeed + transform.up * rbd.velocity.y;
            }            
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
        if (Input.GetKey("space") && (grounded || wallrun))
        {
            rbd.velocity = transform.up * jumpforce + transform.forward * rbd.velocity.x;
            grounded = false;
            wallrun = false;
        }              
    }   
        
    void Grounded()
    {
        RaycastHit ray;
        if (Physics.Raycast(transform.position, Vector3.down, out ray))
        {
            if (ray.distance < playerdist)
            {
                grounded = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!grounded)
        {
        wallrun = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        wallrun = false;
    }



    void Grapple()
    {        
        if(grapple && Input.GetKey("q"))
        {
            float dist = Vector3.Distance(transform.position, target);            
            if (dist > 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, 0.25F);
                rbd.velocity = Vector3.zero;
                rbd.useGravity = false;
            }
            else if(dist<1)
            {               
                rbd.constraints=RigidbodyConstraints.FreezePosition;
            }
        }
        if (Input.GetKeyDown("q"))
        {
            grapple = true;
            SetPoint();
            hookcount++;
        }
        else if (Input.GetKeyUp("q"))
        {
            grapple = false;
            rbd.constraints = RigidbodyConstraints.None;
            rbd.useGravity = true;
        }

    }

    void DrawRope()
    {
        if (grapple)
        {
            lr.positionCount = 2;
            lr.SetPosition(0, shoot.position);
            lr.SetPosition(1, target);
        }
        else
        {
            lr.positionCount = 2;
            lr.SetPosition(0, shoot.position);
            lr.SetPosition(1, shoot.position);
        }
    }

    void SetPoint()
    {
        RaycastHit hit;
        Physics.Raycast(shoot.position, shoot.forward, out hit, 20);
        if(hit.collider!=null)
        {
        target = hit.point;
        }
        else
        {            
            grapple = false;
        }
        
    }

    void Pause()
    {
        if(Input.GetKeyDown("p"))
        {
            if (pause) //unpause
            {
                pause = false;
                pausemenu.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                gameObject.GetComponentInChildren<Camerascript>().rotate = true;                

            }
            else if (!pause) //pause
            {
                pause = true;
                pausemenu.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                gameObject.GetComponentInChildren<Camerascript>().rotate = false;
            }
        }
        
    }

    public void ButtonResume()
    {
        pause = false;
        pausemenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.GetComponentInChildren<Camerascript>().rotate = true;
    }




}
