using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicornAnimation : MonoBehaviour {
    Animator anim;
    // Use this for initialization
    void Start () {
        anim = transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Candy>())
        {
            anim.SetBool("IsNear", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Candy>())
        {
            anim.SetBool("IsNear", false);
        }
    }
}

