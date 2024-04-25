using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Buttons : MonoBehaviour
{   
    [SerializeField] GameObject Endscreen = null;
    [SerializeField] GameObject settingscreen=null;
    [SerializeField] GameObject cam = null;

    public void Start()
    {                
        settingscreen.SetActive(false);
    }
    public void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LevelComplete()
    {
        Endscreen.SetActive(true);
        settingscreen.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

   
    public void Quit()
    {
        Application.Quit();
    }

    public void GoSettings()
    {
        Endscreen.SetActive(false);
        settingscreen.SetActive(true);
    }

    public void ExitSettings()
    {
        Endscreen.SetActive(true);
        settingscreen.SetActive(false);
    }
    public void Sensitivity(float s)
    {
        cam.GetComponent<Camerascript>().sensitivity = s;
        PlayerPrefs.SetFloat("s", s); //save settings 
    }

}
