using UnityEngine;

public class BounceScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            //collision.transform.parent.gameObject.GetComponent<PlayerScript>().bouncePlayer();

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            transform.parent.gameObject.GetComponent<PlayerScript>().bouncePlayer();
        }
    }
}
