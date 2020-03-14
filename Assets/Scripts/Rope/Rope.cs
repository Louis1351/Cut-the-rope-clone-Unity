using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    private bool isNotCut = true;

    public bool IsNotCut
    {
        get
        {
            return isNotCut;
        }
    }

    public void ActivateRigidbody2D(bool enable)
    {
        isNotCut = enable;
        HingeJoint2D[] h = GetComponentsInChildren<HingeJoint2D>();
        Rigidbody2D[] rbs = GetComponentsInChildren<Rigidbody2D>();

        for (int i = 0; i < rbs.Length; i++)
        {
            rbs[i].gravityScale = 0.5f;
        }

        for (int i = 0; i < h.Length; i++)
        {

            h[i].GetComponent<Link>().EnableAlpha1 = true;

        }
    }
}
