using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    LineRenderer line;
    HingeJoint2D h;
    bool EnableAlpha;
    float whiteEffect = 0.0f;
    Color c;
    public bool EnableAlpha1
    {
        get
        {
            return EnableAlpha;
        }

        set
        {
            EnableAlpha = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        EnableAlpha = false;
        line = GetComponent<LineRenderer>();
        h = GetComponent<HingeJoint2D>();
        c = line.startColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (h.connectedBody)
            line.SetPosition(0, h.connectedBody.transform.position);
        else
        {
            line.SetPosition(0, transform.position - transform.up * 0.2f);
        }

        line.SetPosition(1, transform.position);
        if (EnableAlpha)
        {
            if(whiteEffect <0.04f)
            {
                whiteEffect += Time.deltaTime;
                line.startColor = Color.white;
                line.endColor = Color.white;
            }
            else
            {
                float newAlpha = line.startColor.a - Time.deltaTime;
                line.startColor = new Color(c.r, c.g, c.b, newAlpha);
                line.endColor = line.startColor;
                if (newAlpha <= 0.0f)
                {
                    Destroy(gameObject);
                    Destroy(transform.parent.gameObject);
                }
            }

            
        }

    }
}
