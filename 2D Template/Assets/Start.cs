using UnityEngine;
using UnityEngine.SceneManagement;


public class Start : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  

   public void switchScenes(string sceneName)
    { 
        SceneManager.LoadScene(sceneName);
    }

}
