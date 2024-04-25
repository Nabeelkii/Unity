using System;
using UnityEngine;

public class Endscreen : MonoBehaviour
{    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Quit()
    {
        Application.Quit();
    }


}
