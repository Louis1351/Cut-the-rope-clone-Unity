using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    Rigidbody2D rb;
    bool isInBubble;
    bool isEat;
    float speedBubble = 25.0f;
    Animator anim;
    float timeAnim = 0.0f;
    public bool IsEat
    {
        get
        {
            return isEat;
        }
        set
        {
            isEat = value;
        }
    }

    // Use this for initialization
    public bool SetInBubble(bool enable)
    {
        bool b = isInBubble;
        isInBubble = enable;
        return b;
    }

    void Start()
    {
        isInBubble = false;
        IsEat = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeAnim += Time.deltaTime;
        if (timeAnim > 6.0f)
        {
            anim.Rebind();
            timeAnim = 0.0f;
        }
        if (!isEat)
        {
            if (isInBubble)
            {
                rb.velocity = new Vector2(rb.velocity.x * 0.99f, Mathf.Clamp(rb.velocity.y + speedBubble * Time.deltaTime, -1000.0f, 2.0f));
            }
            HingeJoint2D[] h = GetComponents<HingeJoint2D>();

            for (int i = 0; i < h.Length; i++)
            {
                if (!h[i].connectedBody)
                {
                    Destroy(h[i]);
                    break;
                }
            }
        }
        else
        {

            HingeJoint2D[] h = GetComponents<HingeJoint2D>();

            for (int i = 0; i < h.Length; i++)
            {
                if (h[i].connectedBody)
                {
                    h[i].connectedBody.transform.parent.GetComponent<Rope>().ActivateRigidbody2D(false);
                }
            }
            transform.localScale -= new Vector3(Time.deltaTime * 10, Time.deltaTime * 10, 0.0f);

            rb.velocity = Vector2.zero;
            Vector2 endPos = GameObject.Find("End").transform.position;

            transform.position = Vector3.Lerp(transform.position, new Vector2(endPos.x, endPos.y + 1.2f), 0.1f);
            if (transform.localScale.x <= 0.0f)
            {
                GameObject.Find("@GameController").GetComponent<GameController>().Win = true;
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {

    }
}
