using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject interact = null;
    [SerializeField] Transform groundpos = null;
    [SerializeField] int sensitivity = 10;
    GameObject adm;
    Vector2 mousepos;
    Animator anim;
    Rigidbody2D rbd;
    bool grounded;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        anim = GetComponent<Animator>();
        rbd = GetComponent<Rigidbody2D>();
        adm = GameObject.FindGameObjectWithTag("AudioM");        
           
    }
  
    void Update()
    {
        mousepos.x = Input.GetAxisRaw("Mouse X") *sensitivity *10000*Time.deltaTime;
        mousepos.y = Input.GetAxisRaw("Mouse Y") * sensitivity *10000* Time.deltaTime;       
    }

    void FixedUpdate()
    {
        Move();
        Ground();
    }

    private void Move()
    {
        if(mousepos.x>0)
        {
            rbd.velocity = transform.right * 3 + transform.up * rbd.velocity.y;
            if (grounded) { anim.Play("Player_walk"); }          
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            CancelInvoke();
        }
        else if (mousepos.x < 0) 
        {
            rbd.velocity = transform.right * 3 + transform.up * rbd.velocity.y;
            if (grounded) { anim.Play("Player_walk"); }
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            CancelInvoke();
        }
        else if (mousepos.y > 0.001F && grounded) //jump
        {
            rbd.velocity = transform.up * 6 + transform.right * rbd.velocity.x;            
            grounded = false;
            adm.GetComponent<AudioManager>().PlaySound("Move");
            CancelInvoke();
        }
        else
        {
            Invoke("Idle", 10*Time.deltaTime);
        }
        if (!grounded)
        {
            anim.Play("Player_jump");
        }
       
    }

    private void Idle()
    {        
        anim.Play("Player_idle");
    }
    void Ground()
    {
        Vector2 endpos = groundpos.position + Vector3.down * 0.1F;
        RaycastHit2D middle = Physics2D.Linecast(groundpos.position, endpos, 1 << LayerMask.NameToLayer("Ground"));
        if (middle.collider == null)
        {
            
            interact.SetActive(true);           
        }
        else if (middle.collider != null)
        {
            grounded = true;
            interact.SetActive(false);            
        }        

    }   
}
