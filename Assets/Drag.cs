using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
//http://stackoverflow.com/questions/23152525/drag-object-in-unity-2d
public class Drag : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 startPoint;

	// Use this for initialization
	void Start () {
		startPoint = transform.position;
	}
	
	// Update is called once per frame
//	void Update () {
	
//	}

	void OnMouseDown(){
		Debug.Log ("Down: offset" + offset);
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

	}

	void OnClick(){
		Debug.Log ("Click: offset1" + offset);
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

	}

	void OnMouseDrag(){
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		transform.position = curPosition;
	}
	void OnMouseUp(){
		Debug.Log("Mouse Released");
		transform.position = startPoint;
	}
}
