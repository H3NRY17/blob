using UnityEngine;



public class SpikeScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") 
        {
            collision.gameObject.GetComponent<PlayerScript>().dealPlayerDamage("spike", 1);
        }
    }
}
