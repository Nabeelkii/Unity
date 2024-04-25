using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupchild : MonoBehaviour
{    
    //check if object is in grab range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {

            collision.transform.parent = transform.parent;
            collision.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.transform.position = transform.position;
            collision.transform.rotation = transform.rotation;
        }
            
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            collision.GetComponent<Rigidbody2D>().isKinematic = false;
            collision.transform.parent = null;            
        }
      
    }
}
