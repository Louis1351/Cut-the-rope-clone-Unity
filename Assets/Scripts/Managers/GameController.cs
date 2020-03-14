using UnityEngine;

public class GameController : MonoBehaviour
{
    ManageScene scriptSceneManagement;
    ManageSaves scriptSaveManagement;
    GameObject candy;
    int nbStars = 0;
    float yBound = 8.0f;
    float transitionTime = 0.0f;
    bool win = false;

    public bool Win
    {
        set
        {
            win = value;
        }
    }

    public void AddStar()
    {
        nbStars++;
    }

    void Start()
    {
        candy = GameObject.Find("Candy");
        scriptSceneManagement = Resources.LoadAll<GameObject>("Prefabs/@GameToolsManagement")[0].GetComponent<ManageScene>();
        scriptSaveManagement = Resources.LoadAll<GameObject>("Prefabs/@GameToolsManagement")[0].GetComponent<ManageSaves>();
    }

    // Update is called once per frame
    void Update()
    {
        if (candy)
        {
            if (candy.transform.position.y < -yBound
                || candy.transform.position.y > yBound)
            {
                nbStars = 0;
                scriptSceneManagement.Restart();
            }
        }
        else
        {
            if (win)
            {
                transitionTime += Time.deltaTime;
                if (transitionTime > 2.0f)
                {
                    scriptSaveManagement.SetStars(ManageScene.currentScene - 1, nbStars);
                    scriptSceneManagement.Next();
                }

            }
            else
            {
                nbStars = 0;
                scriptSceneManagement.Restart();
            }
        }
    }
}
