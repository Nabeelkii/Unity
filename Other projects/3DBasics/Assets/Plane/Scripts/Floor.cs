using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        Renderer rdr = GetComponent<Renderer>();
        int x = Random.Range(1, 11);


        if (x == 1) { rdr.material.color = Color.green; }
        else if (x == 2) { rdr.material.color = Color.yellow; }
        else if (x == 3) { rdr.material.color = Color.magenta; }
        else if (x == 4) { rdr.material.color = Color.black; }
        else if (x == 5) { rdr.material.color = Color.white; }
        else if (x == 6) { rdr.material.color = Color.blue; }
        else if (x == 7) { rdr.material.color = Color.cyan; }
        else if (x == 8) { rdr.material.color = Color.gray; }
        else if (x == 9) { rdr.material.color = Color.red; }
        else if (x == 10) { rdr.material.color = Color.clear; }
    }
   




}
