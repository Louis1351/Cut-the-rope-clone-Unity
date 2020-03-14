using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour {

    public static int currentScene;
    private int maxScene = 10;
   

    public void GoToLevel(int index)
    {
        currentScene = index;
        SceneManager.LoadScene(currentScene);
    }

    public void Restart()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void Next()
    {
        
        
        currentScene++;
        if (currentScene <= maxScene)
        {
            GoToLevel(currentScene);
        }
        else
        {
            GoToLevel(0);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
