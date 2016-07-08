using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Trigger : MonoBehaviour {

	private Text myText;
	public string TheAnswer{ get; set; }
	bool completed = false;
	// Use this for initialization
	void Start () {
		myText = GetComponentInChildren<Text>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		Text otherText = other.gameObject.GetComponentInChildren<Text>();

		if (otherText != null) {
			
			if (otherText.text == TheAnswer) {
				Debug.Log("you found the answer!");
				myText.color = Color.green;


				completed = true;

				GameObject[] array = GameObject.FindGameObjectsWithTag("Sentence");
				foreach (GameObject O in array) {
					if (O.GetComponent<Trigger>().completed != true) {
						O.GetComponentInChildren<Text>().color = Color.black;

					}

				}
				Destroy(other.gameObject);
			}
		}
		if (otherText.text != TheAnswer && !completed) {
			Debug.Log("couldn't find text object");
			myText.color = Color.red;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (completed) {
			myText.color = Color.green;
		} else if (!completed) {
			myText.color = Color.black;
		}
	}
}
