using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadARScene()
    {
        SceneManager.LoadScene("ARScene");
    }

    public void LoadDigitalTwinScene()
    {
        SceneManager.LoadScene("DigitalTwinScene");
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
