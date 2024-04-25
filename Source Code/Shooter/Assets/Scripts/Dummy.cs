using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    GameObject player=null;
    GameObject enemy = null;
    void Start()
    {
        Invoke("ReduceCount", 6);
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Respawn");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            player.GetComponent<Player>().Score++;
            enemy.GetComponent<Enemy>().enemies--;
            Destroy(gameObject);
        }        
    }

    void ReduceCount()
    {
        enemy.GetComponent<Enemy>().enemies--;
        Destroy(gameObject);
    }


}
