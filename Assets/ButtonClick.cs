using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour {
	public bool loadNextlvl = false;
	public string levelName;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (loadNextlvl) {
			//	Debug.Log ("changing to next lvl");
			loadNextlvl = false;

			SceneManager.LoadScene (levelName);
		}

	}

	public void OnMyClick(){
		loadNextlvl = true;
		//Debug.Log ("Button Clicked");
		//		Application.LoadLevel ("First Scene");
	}
}
