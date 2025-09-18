using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.name == "Player") //IT DETECTS THE JUMPCHECKER INSTEAD
        {
            collision.GetComponent<PlayerScript>().dealPlayerDamage("spike", 1);
        }
    }
}
