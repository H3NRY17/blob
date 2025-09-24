using UnityEngine;

public class NewEmptyCSharpScript : MonoBehaviour {
    void Awake() {
     DontDestroyOnLoad(this);
    }
}