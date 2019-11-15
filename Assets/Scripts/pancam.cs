using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pancam : MonoBehaviour {

//	float ydir = 0f;
	public GameObject player;
	//for our GUIText object and our score
	public GUIElement gui;
	float playerScore = 0;

	//this function updates our guitext object
	void OnGUI(){
		//gui.guiText.text = "Score: " + ((int)(playerScore * 10)).ToString ();
	}

	//this is generic function we can call to increase the score by an amount
	public void increaseScore(int amount){
		playerScore += amount;
	}
}
