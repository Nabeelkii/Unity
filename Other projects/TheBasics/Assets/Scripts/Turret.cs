using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject gunbullet = null;   

    private void Start()
    {
        InvokeRepeating("spawnprojectile", 5, 5);
    }

    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;   //distance between target and transform
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg+90; //finding angle between target and transform        
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); //translate the angle to quaternion value
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5 * Time.deltaTime); //rotate      
        
    }
    
   
  
    void spawnprojectile()
    {       
        GameObject shots = Instantiate(gunbullet);
        shots.transform.rotation = transform.rotation;
        shots.transform.position = transform.position;        
        shots.GetComponent<projectile>();      
        
    }
    
}
