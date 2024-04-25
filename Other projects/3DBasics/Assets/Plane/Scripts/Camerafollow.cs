using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    
    float yrotation = 0;
    public float xrotation = 10;
    float sensitivity = 10;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * -sensitivity;        
        xrotation += mouseX;
        yrotation += mouseY;       
        yrotation = Mathf.Clamp(yrotation, 0, 40);
        transform.localRotation = Quaternion.Euler(yrotation,0, 0);        
        

    }
}
