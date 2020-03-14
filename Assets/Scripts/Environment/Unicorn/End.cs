using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Candy>())
        {
            collision.GetComponent<Candy>().IsEat = true;
            GetComponent<Animator>().SetBool("IsEat", true);
        }
    }

}
