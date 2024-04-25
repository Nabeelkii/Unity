using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Laserbeam : MonoBehaviour
{
    GameObject manager;
    GameObject player;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.position += transform.up * -10 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="Receiver" || collision.gameObject.name=="BOX")
        {
            Destroy(gameObject);
        }     
        
        else if(collision.gameObject==player)
        {
            Invoke("Reset", 0.1F);
        }
    }
    void Reset()
    {
        manager.GetComponent<Manager>().ReloadScene();
    }

}
