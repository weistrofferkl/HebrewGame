using UnityEngine;
using System.Collections;
using System;
using System.Text;
public class WWWFile : MonoBehaviour
{

	public string URL;
	protected WWW file;
	protected string unicodeString;


	// Use this for initialization
	void Start ()
	{

	}

	public IEnumerator LoadText ()
	{
		// launch the coroutine to get the text
		yield return StartCoroutine (GetData (URL));
	}

	public string GetText ()
	{
		return unicodeString; 
	}

	/** allow us to load the data from a URL in the background */
	IEnumerator GetData (string url)
	{

		file = new WWW (url);
		// this basically returns back to the main thread until it's finished loading
		yield return file;

		//Debug.Log ("Finished loading '" + url + "'");
		//Debug.Log ("loaded " + file.bytes.Length + " bytes");

		// take the text and parse it as unicode encoding

		try
		{
			// interesting--needed to use BigEndianUnicode to make this work
			unicodeString = Encoding.BigEndianUnicode.GetString (file.bytes);
		}
		catch (Exception e)
		{
			Debug.LogError ("Error trying to parse the unicode file: " + e);
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}
}