using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupmain : MonoBehaviour
{
    [SerializeField] GameObject grabrange = null;
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject progress = null;
    bool grab = false;
    float idletime = 0;
    float barscaled = 0;
    
    void Update()
    {               
        //sets grab position
        if (player.GetComponent<Rigidbody2D>().velocity.x==0 && player.GetComponent<Rigidbody2D>().velocity.y==0)
        {
           
            if (!grab && idletime < 200)
            {
                idletime += 200 * Time.deltaTime;
                if (idletime > 150){ grab = true; }
            }            
            else
            {
                idletime -= 200 * Time.deltaTime;
                if (idletime < 20) { grab = false; }
            }
            
        }        
        else
        {
            if (grab) { idletime = 200; }
            else if (!grab) { idletime = 0; }
        }
       
        if(grab) { grabrange.SetActive(true); }
        else if (!grab) { grabrange.SetActive(false); }

        //display bar    
        barscaled = idletime / 100;
        progress.transform.localScale = new Vector3(barscaled, transform.localScale.y);        
    }
    

   


}
   
    
   
