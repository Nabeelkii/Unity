using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] GameObject levelselect = null;
    [SerializeField] GameObject mainscreen = null;
    [SerializeField] GameObject settings = null;
    [SerializeField] GameObject cam = null;

    private void Start()
    {
        mainscreen.SetActive(true);
        settings.SetActive(false);
        levelselect.SetActive(false);
    }
    public void LevelSelect()
    {
        mainscreen.SetActive(false);
        settings.SetActive(false);
        levelselect.SetActive(true);
    }

    public void Settings()
    {
        mainscreen.SetActive(false);
        settings.SetActive(true);
        levelselect.SetActive(false);
    }

    public void Back()
    {
        mainscreen.SetActive(true);
        settings.SetActive(false);
        levelselect.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Sensitivity(float s)
    {
        cam.GetComponent<Camerascript>().sensitivity = s;
        PlayerPrefs.SetFloat("s", s); //save settings 
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
    }

}
