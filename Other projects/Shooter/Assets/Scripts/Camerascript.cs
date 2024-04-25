using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{
    [HideInInspector] public Vector3 rotation;
    float sensitivity=10;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
    }

    void LookAround()
    {
        float mouseX = Input.GetAxisRaw("Mouse Y") * sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse X") * sensitivity;
        rotation.x -= mouseX;
        rotation.y += mouseY;
        rotation.x = Mathf.Clamp(rotation.x, -90, 10);
        transform.localRotation = Quaternion.Euler(rotation.x,0,0);
    }
}
