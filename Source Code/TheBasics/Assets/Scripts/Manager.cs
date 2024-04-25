using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] GameObject screen=null;

    public GameObject player = null;
    bool pause = false;

    void Update()
    {
        if (!player.activeSelf) { Invoke("ReloadScene", 1); }
        if (Input.GetKeyDown("escape") || Input.GetKeyDown("p"))
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (pause) 
        { 
            screen.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            pause = false; 
        }
        else if (!pause) //default state
        {
            screen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            pause = true; 
        }        
    }
   
    public void StopScreen()
    {
        screen.SetActive(false);
    }

    public void StartScreen()
    {
        screen.SetActive(true);
    }

    public void NextScene()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }

    public void ReloadScene()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
    }
    

}
