using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]Transform player = null;
    [SerializeField] Transform Bulletspot = null;
    Rigidbody rbd;
    GameObject rotations;
    Object Bullet;
    float PRT;
    float currentdiff;
    float finaldiff;
    float posY=90;
    [SerializeField]  public int movespeed = 10;
    
   
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        rotations = GameObject.FindGameObjectWithTag("MainCamera");
        Bullet = Resources.Load("Bullet");        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, rotations.GetComponent<Camerafollow>().xrotation, 0);        
        Playerc();
    }
    private void Playerc()
    {        
        if (Input.GetKey("w"))
        {
            posY = 90;
            player.transform.localRotation = Quaternion.Euler(0, posY, 90);           
            rbd.velocity = transform.forward * movespeed;
        }
        else if (Input.GetKey("s"))
        {
            posY = -90;
            player.transform.localRotation = Quaternion.Euler(0, posY, 90);            
            rbd.velocity = transform.forward * -movespeed;
        }

        else if (Input.GetKey("a"))
        {
            posY = 0;
            player.transform.localRotation = Quaternion.Euler(0, posY, 90);            
            rbd.velocity = transform.right * -movespeed;
        }
        else if (Input.GetKey("d"))
        {
            posY = 180;
            player.transform.localRotation = Quaternion.Euler(0, posY, 90);            
            rbd.velocity = transform.right * movespeed;
        }
        else
        {
            rbd.velocity = Vector3.zero;           
        }
        if (Input.GetMouseButtonDown(0))
        {                
            Bullets();
        }        

    }
    private void Bullets()
    {       
        PRT = transform.localRotation.eulerAngles.y;
        GameObject Bullets = (GameObject)Instantiate(Bullet);
        Bullets.GetComponent<Bullet>().Shoot(PRT);
        Bullets.transform.position = Bulletspot.transform.position;      
    }

   
    
   

}
