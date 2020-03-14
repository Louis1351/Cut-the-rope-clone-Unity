using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRope : MonoBehaviour
{

    [SerializeField] GameObject link;
    float linkSize;
    Color[] Rainbow;
    float candyMass = 20.0f;
    private void Awake()
    {
        Rainbow = new Color[7];
        Rainbow[0] = Color.red;
        Rainbow[1] = new Color(1.0f, 0.5f, 0.0f);
        Rainbow[2] = new Color(1.0f, 1.0f, 0.0f);
        Rainbow[3] = Color.green;
        Rainbow[4] = Color.blue;
        Rainbow[5] = new Color(0.3f, 0.0f, 0.5f);
        Rainbow[6] = new Color(0.6f, 0.0f, 0.8f);
        //0.18f
        linkSize = 0.21f;
    }

    public void GenerateNewRope(Vector2 start, Vector2 end, HingeJoint2D lastElem)
    {
        GameObject gb = null;
        GameObject rope = new GameObject();

        rope.name = "Rope";
        rope.AddComponent<Rope>();
        Rigidbody2D rb = null;
        Vector2 distance = (end - start);

        int nbLinks = (int)(distance.magnitude / linkSize);

        for (int i = 0; i < nbLinks; i++)
        {
            gb = Instantiate(link, new Vector2(0.0f, -linkSize - i * linkSize), Quaternion.identity, rope.transform);
            gb.name = "Link" + i;
            gb.GetComponent<HingeJoint2D>().connectedBody = rb;
            rb = gb.GetComponent<Rigidbody2D>();
            rb.mass = candyMass / nbLinks;
            gb.GetComponent<LineRenderer>().startColor = Rainbow[i % 7];
            gb.GetComponent<LineRenderer>().endColor = Rainbow[i % 7];

        }

        if (lastElem)
        {
            lastElem.connectedBody = rb;
        }
        else
        {
            gb.AddComponent<HingeJoint2D>();
        }


        float rot_z = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        rope.transform.position = new Vector2(start.x, start.y + linkSize);
        rope.transform.RotateAround(start, Vector3.forward, rot_z + 90);
    }

}
