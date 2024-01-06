using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camerascript : MonoBehaviour
{    
    Vector2 rotation;
    public bool rotate=true;
    public float sensitivity = 1;
    [SerializeField] GameObject slider=null;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (PlayerPrefs.HasKey("s"))
        {
            sensitivity = PlayerPrefs.GetFloat("s");
            slider.GetComponent<Slider>().value = sensitivity;
        }
        else
        {
            sensitivity = 10;
            slider.GetComponent<Slider>().value = sensitivity;
        }        
    }
    void Update()
    {
        if (rotate) { Rotation(); }       

    }
     void Rotation()
    {
        float mouseY = Input.GetAxis("Mouse Y") * -1 * sensitivity;
        float mouseX = Input.GetAxis("Mouse X") * 1 * sensitivity;
        rotation.y += mouseY;
        rotation.x += mouseX;
        rotation.y = Mathf.Clamp(rotation.y, -90, 90);
        transform.localRotation = Quaternion.Euler(rotation.y, 0, 0);
        transform.parent.localRotation = Quaternion.Euler(0, rotation.x, 0);
    }
}
