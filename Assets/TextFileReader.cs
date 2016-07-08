using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;


public class TextFileReader : MonoBehaviour {

	public string filename;
	public Text textField;
	//public Canvas myCanvas;
	// this must match the definition in PostBuildScript
	public const string DATA_DIR = "DataFiles";
	//int i = 0;
	//string names = "texts" + i;
	private StringReader reader;
	// Use this for initialization
	void Start () {
		reader = GetStringReaderFromFilename (filename);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump") == true) { 
			// read one line at a time if they press the space bar
			string line = reader.ReadLine ();
			Text nextText = gameObject.AddComponent<Text> ();
			nextText.transform.parent = transform.FindChild ("Canvas");
			nextText.text = line;
	//		GameObject names = new GameObject();
	//			names.text = line;
			//textField.text = line;
			Debug.Log ("First line: " + line);
		}
	}

	// this just creates a string reader regardless of whether it's a file or not
	public StringReader GetStringReaderFromFilename(string filename)
	{
		StreamReader reader;
		FileInfo sourceFile = new FileInfo (Application.dataPath 
			+ Path.DirectorySeparatorChar 
			+ DATA_DIR 
			+ Path.DirectorySeparatorChar
			+ filename);
		if (sourceFile != null && sourceFile.Exists) {
			reader = sourceFile.OpenText ();
			return new StringReader (reader.ReadToEnd ());
		} else 
		{
			Debug.Log ("Unable to find " + Application.dataPath + "/" + filename);
		}
		return null;
	}
}
