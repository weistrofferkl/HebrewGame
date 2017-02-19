using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
//using Syst![alt text][1]em.Collections.Generic;
using System;
using System.Text.RegularExpressions;



public class FlipFont : MonoBehaviour {

	Text myText;
	//string indiLine = "";
//	int numAlphaInLine = 20;

//	string sample = "אני _ לחנות";

	void Awake(){
		myText = GetComponent<Text>();
	}
	// Use this for initialization
	public static string bob (string sample) {

		string text = "";
		List<string> listofWords = Regex.Split(sample, @"\s").ToList();
		foreach (string s in listofWords) {
			text = Reverse(s) + " " + text;
		//	Debug.Log("S: " + Reverse(s));
		}
		return text;
	
	}

	public static string Reverse(string s){
		char[] charArray = s.ToCharArray();
		Array.Reverse(charArray);
		return new string(charArray);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
