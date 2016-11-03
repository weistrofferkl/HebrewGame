using UnityEngine;
using System.Collections;

public class WWWFile : MonoBehaviour {
	public WWW file;

	// Use this for initialization
	void Start () {
		LoadText();
	}
	public string LoadText(){
		file = new WWW("http://www.cs.du.edu/~chrisg/hebrewgame/data/Hebrew3.txt");

		while (true) {

			if (file.isDone) {
			
				return file.text;
			//	break;
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
		if (file.isDone) {
			Debug.Log("done");
		}
	}
}
