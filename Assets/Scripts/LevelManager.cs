using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;


    void Awake()
    {
        Instance=this;
    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }



    public void ExitGame()
    {
        Application.Quit();
    }
}
