using UnityEngine;

public class FlagScript : MonoBehaviour
{



    //SceneManager.LoadScene(sceneName);



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().swapCurrentScene("End", "Win");
        }
    }
}
