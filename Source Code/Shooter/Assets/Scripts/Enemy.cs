using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField] GameObject enemy=null;
    [SerializeField] GameObject script=null;
    [HideInInspector] public int enemies = 0;   
    [HideInInspector]  public int total=0;
    public int enemyspawnspeed = 2;
    void Start()
    {
        InvokeRepeating("Randomspawn", 1, enemyspawnspeed);
    }
    // Update is called once per frame
    private void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, 0.5F);
        if (script.GetComponent<Score>().endgame) { CancelInvoke(); }
    }

    void Randomspawn()
    {
        int tempx = Random.Range(9, 15);        
        GameObject dummy = Instantiate(enemy);
        dummy.transform.position = new Vector3(tempx, transform.position.y+2,transform.position.z);
        enemies++;
        total++;
    }
}
