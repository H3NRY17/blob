using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class EndUIScript : MonoBehaviour
{

    public TMPro.TMP_Text centerText;
    public string finalCause = "NA";

    void Start()
    {
        
        Debug.Log("test");
        finalCause = PlayerScript.endCause;
        Debug.Log(finalCause);
        if (finalCause == "spike")
        {
            centerText.text = "You Lost\n You died to a " + finalCause;
        }
        else if (finalCause == "Win")
        {
            centerText.text = "You win\nYou made it to the end";
        }

        else if (finalCause == "void")
        {
            centerText.text = "You Lost\n You died to the " + finalCause;
        }
        else
        {
            centerText.text = "You Lost\nYou ran out of time";
        }
    }

}  
