using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    Transform tr;
    bool isActivated = false;
    [SerializeField] GameObject bubble_sound;
    public void DestroyWhenActivate()
    {
        if (tr)
        {
            tr.GetComponent<Candy>().SetInBubble(false);
            Destroy(gameObject);
            Instantiate(bubble_sound, transform.position, Quaternion.identity);
        }
    }

    // Use this for initialization
    void Start()
    {
        tr = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Candy>())
        {
            if (!collision.GetComponent<Candy>().SetInBubble(true))
            {
                tr = collision.GetComponent<Candy>().transform;
            }
        }
    }

    private void Update()
    {
        if (tr)
        {
            isActivated = true;
            transform.position = tr.position;
            if (tr.GetComponent<Candy>().IsEat)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (isActivated)
            {
                Destroy(gameObject);
            }
        }
    }
}
