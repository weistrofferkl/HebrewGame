using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Text;


public class TextFileReader : MonoBehaviour {

	public string filename;
	public Text[] tArray;
	public Text[] sentenceArray = new Text[5];
	public Text[] answerArray = new Text[5];

	//public Canvas myCanvas;
	// this must match the definition in PostBuildScript
	public const string DATA_DIR = "DataFiles";
	private StringReader reader;
	// Use this for initialization
	void Start () {
		shuffle(answerArray);
		//reader = GetStringReaderFromFilename (filename);
		//readArray();


		tArray = new Text[10];
		tArray[0] = sentenceArray[0];
		tArray[1] = answerArray[0];
		tArray[2] = sentenceArray[1];
		tArray[3] = answerArray[1];
		tArray[4] = sentenceArray[2];
		tArray[5] = answerArray[2];
		tArray[6] = sentenceArray[3];
		tArray[7] = answerArray[3];
		tArray[8] = sentenceArray[4];
		tArray[9] = answerArray[4];
		reader = GetStringReaderFromFilename (filename);
		readArray();


	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetButtonDown ("Jump") == true) { 
			// read one line at a time if they press the space bar
		//string line = "";// = reader.ReadLine ();
//		Debug.Log("Line: " + line);
			//Text nextText = gameObject.AddComponent<Text> ();
			//nextText.transform.parent = transform.FindChild ("Canvas");
		//nextText.text = line;


	//		GameObject names = new GameObject();
	//			names.text = line;
			//textField.text = line;
//			Debug.Log ("First line: " + line);
		//}
	}
/*	public string reverse(string s){
		char[] ar = s.ToCharArray();
		System.Array.Reverse(ar);


		return new string(ar);

	}
*/
	public void shuffle(Text[] answers){
		for (int i = 0; i < answers.Length; i++) {
			Text temp = answers[i];
			int r = Random.Range(i, answers.Length);

			answers[i] = answers[r];
			answers[r] = temp;
		}
		
	}
	public void readArray(){
		
		string line = "";
		string answer = "";
	
		for (int i = 0; i < tArray.Length; i+=2) {

		
			line = FlipFont.bob(reader.ReadLine()); 
			tArray[i].text = line; 

			answer = FlipFont.bob(reader.ReadLine());
				
			tArray[i+1].text = answer;

				tArray[i].GetComponentInParent<Trigger>().TheAnswer = answer;

		}
	}
	// this just creates a string reader regardless of whether it's a file or not
	public StringReader GetStringReaderFromFilename(string filename)
	{
		//FileStream reader;
		StreamReader reader;
		/*FileInfo sourceFile = new FileInfo (Application.dataPath 
			+ Path.DirectorySeparatorChar 
			+ DATA_DIR 
			+ Path.DirectorySeparatorChar
			+ filename);
			*/
		string path = Application.dataPath
		              + Path.DirectorySeparatorChar
		              + DATA_DIR
		              + Path.DirectorySeparatorChar
		              + filename;
		string filestr = File.ReadAllText(path, new UnicodeEncoding());
		//if (sourceFile != null && sourceFile.Exists) {
		//	UnicodeEncoding encoding = new UnicodeEncoding();
		//	reader = sourceFile.OpenText();

				return new StringReader(filestr);
		/*
		} else 
		{
			Debug.Log ("Unable to find " + Application.dataPath + "/" + filename);
		}
		return null;
		*/
	}
}
