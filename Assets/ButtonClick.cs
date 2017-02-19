using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour {
	public bool LoadNextLevel = false;
	public string levelName;

	// Use this for initialization
	void Start () {
		LoadNextLevel = false;
	}

	// Update is called once per frame
	void Update () {

		if (LoadNextLevel == true) {
			Debug.Log ("changing to next lvl");
			LoadNextLevel = false;

			SceneManager.LoadScene (levelName);
		}

	}

	public void OnMyClick(){
		LoadNextLevel = true;
		//Debug.Log ("Button Clicked");
		//		Application.LoadLevel ("First Scene");
	}
}
