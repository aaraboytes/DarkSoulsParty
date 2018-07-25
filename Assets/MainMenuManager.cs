using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour {
	public Slider numOfGamesSlider;
	public GameManager gameManager;
	public string[] scenes;
	int numOfPlayers;
	int numOfGames;
	public void setNumOfPlayers(int num){
		numOfPlayers = num;
	}
	void setNumOfGames(){
		numOfGames = (int)numOfGamesSlider.value;
	}
	public void startGame(){
		setNumOfGames ();
		gameManager.GetComponent<GameManager> ().setGamePrefs (numOfPlayers, numOfGames);
		//SceneManager.LoadScene (scenes [Random.Range(0,scenes.Length-1)]);
		SceneManager.LoadScene("Crown");
	}
}
