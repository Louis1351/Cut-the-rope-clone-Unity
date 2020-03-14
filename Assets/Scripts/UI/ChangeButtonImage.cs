using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeButtonImage : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    bool press;
    Image img;
    [SerializeField] Sprite[] sprites;
    // Use this for initialization
    void Start()
    {
        img = GetComponent<Image>();
        press = false;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!press)
        {
            img.sprite = sprites[0];
        }
        press = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (press)
        {
            img.sprite = sprites[1];
        }
        press = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        press = false;
        img.sprite = sprites[1];
    }
}
