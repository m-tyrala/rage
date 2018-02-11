using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class MusicPlayer : MonoBehaviour {

	private static MusicPlayer instance = null;
	// Use this for initialization
	void Start() {
		if (instance != null) {
			Destroy(gameObject);
		}
		else {
			instance = this;
			GameObject.DontDestroyOnLoad(instance);
		}
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
