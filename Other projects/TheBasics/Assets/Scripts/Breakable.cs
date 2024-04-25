using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    int health = 2;    
    bool shake = false;
    Vector2 startpos;
    GameObject adm;

    private void Start()
    {
        startpos = transform.position;
        adm = GameObject.FindGameObjectWithTag("AudioM");
    }
    void Update()
    {
        if (health <= 0) { Destroy(gameObject); }
        if (shake) { Shake(); }       
    }  

    void Shake()
    {        
        transform.position = startpos + UnityEngine.Random.insideUnitCircle * 0.05F;       
    }  

    void StopShake()
    {
        transform.position = startpos;
        shake = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interact")
        {
            health--;
            shake = true;
            Invoke("StopShake", 0.5F);
            adm.GetComponent<AudioManager>().PlaySound("Pop");
        }
    }
    
    
}
