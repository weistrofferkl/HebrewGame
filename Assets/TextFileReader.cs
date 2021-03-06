﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
using System;

public class TextFileReader : MonoBehaviour
{

	public string filename;
	public string nextLevel;
	public static int counter = 0;
	public Text[] tArray;
	public Text[] sentenceArray = new Text[5];
	public Text[] answerArray = new Text[5];

	//public Canvas myCanvas;
	// this must match the definition in PostBuildScript
	public const string DATA_DIR = "DataFiles";
	private StringReader reader;
	// Use this for initialization
	void Start ()
	{

		StartCoroutine (LoadText ());

	}

	IEnumerator LoadText ()
	{
		Debug.Log ("TFR.LoadText()");
		//yield return GetComponent<WWWFile> ().LoadText ();

		Debug.Log ("Continuing TFR.LoadText()");

		shuffle (answerArray);
		//reader = GetStringReaderFromFilename (filename);
		//readArray();

		tArray = new Text[10];
		tArray [0] = sentenceArray [0];
		tArray [1] = answerArray [0];
		tArray [2] = sentenceArray [1];
		tArray [3] = answerArray [1];
		tArray [4] = sentenceArray [2];
		tArray [5] = answerArray [2];
		tArray [6] = sentenceArray [3];
		tArray [7] = answerArray [3];
		tArray [8] = sentenceArray [4];
		tArray [9] = answerArray [4];
		reader = GetStringReaderFromFilename (filename);
		Debug.Log ("Received string reader from filename");
		readArray ();

		yield return null;
	}


	// Update is called once per frame
	void Update ()
	{
		//if (Input.GetButtonDown ("Jump") == true) { 
		// read one line at a time if they press the space bar
		//string line = "";// = reader.ReadLine ();
		//        Debug.Log("Line: " + line);
		//Text nextText = gameObject.AddComponent<Text> ();
		//nextText.transform.parent = transform.FindChild ("Canvas");
		//nextText.text = line;


		//        GameObject names = new GameObject();
		//            names.text = line;
		//textField.text = line;
		//            Debug.Log ("First line: " + line);
		//}

		if (counter == tArray.Length / 2)
		{
			counter = 0;
			Debug.Log ("Loading: " + nextLevel);
			SceneManager.LoadScene (nextLevel);
		}
	}
	/*    public string reverse(string s){
        char[] ar = s.ToCharArray();
        System.Array.Reverse(ar);


        return new string(ar);

    }
*/
	public int getCounter ()
	{
		return counter;
	}
	//public  void setCounter(int counter){
	//        this.counter = counter;
	//}
	public void shuffle (Text[] answers)
	{
		for (int i = 0; i < answers.Length; i++)
		{
			Text temp = answers [i];
			int r = UnityEngine.Random.Range (i, answers.Length);

			answers [i] = answers [r];
			answers [r] = temp;
		}

	}


	public void readArray ()
	{

		string line = "";
		string answer = "";

		for (int i = 0; i < tArray.Length; i += 2)
		{


			line = FlipFont.bob (reader.ReadLine ()); 
			//Debug.Log ("found line: " + line);
			tArray [i].text = line; 


			answer = FlipFont.bob (reader.ReadLine ());
			tArray [i + 1].text = answer;


			tArray [i].GetComponentInParent<Trigger> ().TheAnswer = answer;

		}
	}
	// this just creates a string reader regardless of whether it's a file or not
	public StringReader GetStringReaderFromFilename (string filename)
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

		// note, just now always read from a URL
		//if (!Application.isWebPlayer)
		//{
		//    string filestr = File.ReadAllText (path, new UnicodeEncoding ());
		//    return new StringReader (filestr);
		//
		//}
		//else
	/*	{

			try
			{
				string filestr = GetComponent<WWWFile> ().GetText ();
				return new StringReader (filestr);
			}
			catch (Exception e)
			{
				Debug.LogError ("Erorr creating the string reader: " + e);
				return null;
			}

		}
*/
		string filestr = File.ReadAllText(path, new UnicodeEncoding());
		//if (sourceFile != null && sourceFile.Exists) {
		//    UnicodeEncoding encoding = new UnicodeEncoding();
		//    reader = sourceFile.OpenText();

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