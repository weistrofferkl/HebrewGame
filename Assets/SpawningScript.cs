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
			//GameObject temp =  Instantiate(textPrefab) as GameObject;
			Text t = Instantiate<Text>(textPrefab);
			t.text = "wahoo";
			GameObject canObj = GameObject.FindWithTag ("TheCanvas");
			if (canObj) 
			{
				t.rectTransform.parent = canObj.GetComponent<Canvas>().GetComponent<RectTransform>();
				t.rectTransform.localPosition = Vector3.zero;
				t.rectTransform.localScale = new Vector3(1f, 1f, 1f);
				//t.rectTransform.position = new Vector3(.5f, .5f, 0f);

				//t.transform.position = new Vector3(.5f, .5f, 0f);
			}


//			temp.GetComponent<UnityEngine.UI.Text>().text = "abc";
//
////			temp.AddComponent<UnityEngine.UI.Text>
//			Text a;
//			GameObject canObj = GameObject.FindWithTag ("TheCanvas");
//			if (canObj != null) {
//				canObj.AddComponent<CanvasRenderer> ();
//				temp.GetComponent<RectTransform>().SetParent(canObj.GetComponent<Canvas>().GetComponent<RectTransform> (), false);
//			} else
//				Debug.Log ("Error, no canvas!");
			//CreateText(0.5f, 0.5f, "yo dawg");
		}
	}

	GameObject CreateText(float x, float y, string text_to_print, int font_size = 16, Color? c = null)
	{
		Color text_color = c ?? Color.black;
		Transform canvas_transform = GameObject.FindWithTag("TheCanvas").transform;
		GameObject UItextGO = new GameObject("Text2");
		UItextGO.transform.SetParent(canvas_transform);

		RectTransform trans = UItextGO.AddComponent<RectTransform>();
		trans.anchoredPosition = new Vector2(x, y);

		Text text = UItextGO.AddComponent<Text>();
		text.text = text_to_print;
		text.fontSize = font_size;
		text.color = text_color;

		return UItextGO;
	}
}
