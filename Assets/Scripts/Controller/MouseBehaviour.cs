using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
    [SerializeField] GameObject cutSound;
    Vector2 lastMousePos;
    Vector2 currentMousePos;
    TrailRenderer trail;
    // Use this for initialization
    void Start()
    {
        lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        trail.emitting = false;
        transform.position = currentMousePos;
        if (Input.GetMouseButton(0))
        {

            lastMousePos = currentMousePos;
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            if ((currentMousePos - lastMousePos).sqrMagnitude > 0.01f)
            {
                trail.emitting = true;
                RaycastHit2D[] hits;
                hits = Physics2D.LinecastAll(lastMousePos, currentMousePos);
                Debug.DrawLine(lastMousePos, currentMousePos, Color.red);
                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i])
                    {
                        if (hits[i].transform.gameObject.layer == 8)
                        {
                            Destroy(hits[i].transform.gameObject);
                            Instantiate(cutSound, hits[i].transform.position,Quaternion.identity);
                            hits[i].transform.parent.GetComponent<Rope>().ActivateRigidbody2D(false);

                        }
                    }
                }

            }
            else
            {
                RaycastHit2D[] hits;
                hits = Physics2D.RaycastAll(currentMousePos, Camera.main.transform.forward);
                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i])
                    {
                        if (hits[i])
                        {
                            if (hits[i].transform.GetComponent<Bubble>())
                            {
                                hits[i].transform.GetComponent<Bubble>().DestroyWhenActivate();
                            }
                        }
                    }
                }
            }

        }
        else
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastMousePos = currentMousePos;
        }
    }

}
