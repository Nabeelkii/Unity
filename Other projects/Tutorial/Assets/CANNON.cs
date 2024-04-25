using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CANNON : MonoBehaviour
{
    Vector3 _initialPosition;
    private bool launched;
    private int stayed;

    private void Awake()
    {
        _initialPosition = transform.position;
        }

    private void Update()
    {
        if (launched == true && GetComponent<Rigidbody2D>().velocity.magnitude < 1)
        { stayed ++; }
    
        if(transform.position.y>20 || transform.position.y < -10 || transform.position.x >40 || transform.position.x<-10)
          {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
          }

    
    
    }
    private void OnMouseUp()
    {
        Vector2 flight = _initialPosition - transform.position;    
        GetComponent<Rigidbody2D>().AddForce(flight*200);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        launched = true;
    }
    
            
            private void OnMouseDrag()
    {
        Vector3 Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(Origin.x, Origin.y);
    }
}
