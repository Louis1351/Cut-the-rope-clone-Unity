using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieParticle : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;

    public void SetSprite(int index)
    {
        GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    private void Update()
    {
        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }
    }
}
