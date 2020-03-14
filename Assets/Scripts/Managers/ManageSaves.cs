using UnityEngine;
using UnityEngine.UI;

public class ManageSaves : MonoBehaviour
{

    int[] Levels;
  
    public void Init()
    {
        Levels = new int[10];
        GameObject canvas = GameObject.Find("Menu Canvas");
        for (int i = 0; i < 10; i++)
        {
            //PlayerPrefs.SetInt("world Level" + i, 0);
            Levels[i] = PlayerPrefs.GetInt("world Level" + i, 0);
            for (int j =0; j< Levels[i];j++)
            {
                canvas.transform.GetChild(i).transform.GetChild(j).GetComponent<Image>().enabled = true;
            }
        }
    }

    public void SetStars(int indexLevel, int nbStars)
    {
        if (nbStars > Levels[indexLevel])
        {
            Levels[indexLevel] = nbStars;
            PlayerPrefs.SetInt("world Level" + indexLevel, Levels[indexLevel]);
            PlayerPrefs.Save();
        }
    }

}
