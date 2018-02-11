using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    
    private void Start() {
        Screen.SetResolution(1366, 768, true);
    }

    public void LoadLevel(string name) {
        Debug.Log("level load requested for: " + name);
        Application.LoadLevel(name);
        
    }
    public void QuitRequest() {
        Debug.Log("guit requested");
        Application.Quit();
    }
}
