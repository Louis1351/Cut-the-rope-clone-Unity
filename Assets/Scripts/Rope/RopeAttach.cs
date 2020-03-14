using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeAttach : MonoBehaviour
{
    [SerializeField] GameObject radiusVisual;
    [SerializeField] Transform[] hook;
    [SerializeField] bool isHook = true;
    [SerializeField] bool isAttractiv = false;
    bool isAlreadyAttach = false;
    [SerializeField] float radius;
    GenerateRope scpt;
    List<GameObject> objects;
    float candyRadius;

    // Use this for initialization
    void Start()
    {
        objects = new List<GameObject>();
        candyRadius = GameObject.Find("Candy").GetComponent<SpriteRenderer>().bounds.size.x * 0.5f;
        radius += candyRadius;
        scpt = GameObject.Find("@GenerateRope").GetComponent<GenerateRope>();
        for (int i = 0; i < hook.Length; i++)
        {
            if (hook[i])
            {
                if (isHook)
                    scpt.GenerateNewRope(hook[i].position, transform.position, null);
                else
                {
                    scpt.GenerateNewRope(hook[i].position, transform.position, gameObject.AddComponent<HingeJoint2D>());
                }

            }
        }

        if (isAttractiv)
        {

            float nbPoints = 360 / (radius * 30);
            for (float i = 0; i < 360; i += nbPoints)
            {
                GameObject gb = Instantiate(radiusVisual, transform.position + Vector3.up * (radius + candyRadius * 2.0f), Quaternion.identity);

                gb.transform.RotateAround(transform.position, Vector3.forward, i);
                gb.transform.parent = transform;
                objects.Add(gb);
            }
        }

    }

    private void FixedUpdate()
    {
        if (isAttractiv && !isAlreadyAttach)
        {
            Collider2D[] c = Physics2D.OverlapCircleAll(transform.position, radius + candyRadius);
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i])
                {
                    if (c[i].GetComponent<Candy>())
                    {
                        isAlreadyAttach = true;
                        scpt.GenerateNewRope(transform.position, c[i].transform.position, c[i].gameObject.AddComponent<HingeJoint2D>());
                        foreach(GameObject g in objects)
                        {
                            Destroy(g);
                        }
                        break;
                    }
                }
            }
        }
    }
}
