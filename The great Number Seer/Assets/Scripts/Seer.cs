using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seer : MonoBehaviour {

	private int min;
	private int max;
	private int guess;
	private LevelManager levelManager;

	public int attempts;
	public Text guessLabel;

	//Initialization
	void Start (){
		levelManager = FindObjectOfType<LevelManager>();
		StartGame();
		ShowGuess();
	}

	void Update () {

	}

	void StartGame(){
		min = 1;
		max = 1001;
		//attempts = 0;
		NextGuess ();
	}

	public void NextGuess(){
		guess = Random.Range (min, max);
		attempts--;
	}
		
	public void ShowGuess(){
		if (attempts == 0)
		{
			levelManager.LoadLevel("Lose");
		}
		else
		{
			guessLabel.text = "Is your number " + guess + "?";
		}
	}

	public void GuessHiger(){
		min = guess + 1;
		NextGuess();
		ShowGuess();
	}

	public void GuessLower(){
		max = guess;
		NextGuess();
		ShowGuess();
	}

	public void CorrectGuess(){
		levelManager.LoadLevel("Win");
	}


}