using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{   
    public void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }
   
    public void Quit()
    {
        Application.Quit();
    }
}
