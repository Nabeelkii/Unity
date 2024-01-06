using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject manager = null;    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Invoke("reset", 0.1F);
        }
    }
    void reset()
    {
            manager.GetComponent<Manager>().ReloadScene();    
    }
}
