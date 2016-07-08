using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SpawningScript : MonoBehaviour {

	public Text textPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump") == true) {
			Text temp = Instantiate<UnityEngine.UI.Text> (textPrefab);
			temp.text = "wahoo";
			GameObject canObj = GameObject.FindWithTag ("TheCanvas");
			if (canObj != null) {
				temp.GetComponent<RectTransform>().SetParent(canObj.GetComponent<Canvas>().GetComponent<RectTransform> (), false);
			} else
				Debug.Log ("Error, no canvas!");
		}
	
	}
}
