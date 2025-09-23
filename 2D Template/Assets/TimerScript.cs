using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

    public int type = 0;
    private float time = 0f;

    public TMPro.TMP_Text timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (type == 0)
        {
            time += 200f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 0)
        {
            if (time - 1 < 0)
            {
                PlayerScript.endCause = "You ran out of time";
                SceneManager.LoadScene("End");
            }
            time -= 1 * Time.deltaTime;
        }

        else
        {
            time += 1 * Time.deltaTime;
        }

        timer.text = Mathf.Round(time).ToString();
    }
}
