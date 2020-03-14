using UnityEngine;

public class Stars : MonoBehaviour {
    [SerializeField] GameObject prefabPart;
    [SerializeField] GameObject crunchSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Candy>())
        {
            GameObject.Find("@GameController").GetComponent<GameController>().AddStar();
            for (int i = 0; i < 11; i++)
            {
                GameObject gb = Instantiate(prefabPart, transform.position, Quaternion.identity);
                gb.GetComponent<CookieParticle>().SetSprite(i);

                gb.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-200.0f, 200.0f), Random.Range(-200.0f, 200.0f)));
            }
            Instantiate(crunchSound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
