using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager _instance;
	[SerializeField]
	float scoreP1, scoreP2, scoreP3, scoreP4, scorePC;
	string lastWinner;
	//Num of players playing an num of games to be played
	int numOfPlayers = 4;
	int numOfGames = 1;

	List<string> names = new List<string> ();
	void Awake(){
		if (_instance == null) {
			_instance = this;
		} else if (_instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (this);
	}
	public void setPlayersOnScene(){
		Player[] players = GameObject.FindObjectsOfType<Player> ();
		int currentNumOfPlayers = 1;
		foreach (Player p in players) {
			Debug.Log ("Setting up player " + p.gameObject.name + "there are " + currentNumOfPlayers + " on scene");
			p.setPlayerNum (currentNumOfPlayers);

			if (currentNumOfPlayers > numOfPlayers) {
				p.gameObject.SetActive (false);
			} else {
				p.gameObject.SetActive (true);
				currentNumOfPlayers++;
			}
		}
	}
	public void setBallsOnScene(){
		BallController[] players = GameObject.FindObjectsOfType<BallController> ();
		int currentNumOfPlayers = 1;
		foreach (BallController p in players) {
			p.setPlayerNum (currentNumOfPlayers);
			if (currentNumOfPlayers > numOfPlayers) {
				p.gameObject.SetActive (false);
			} else
				p.gameObject.SetActive (true);
			currentNumOfPlayers++;
		}
	}
	public List<float> GetScores(){
		List<float> scores = new List<float> ();
		scores.Add (scoreP1);
		scores.Add (scoreP2);
		scores.Add (scoreP3);
		scores.Add (scoreP4);
		scores.Add (scorePC);
		return scores;
	}
	public void IncreaseScore(float extraScore,string player){
		switch (player) {
		case "P1.":
			scoreP1 += extraScore;
			break;
		case "P2.":
			scoreP2 += extraScore;
			break;
		case "P3.":
			scoreP3 += extraScore;
			break;
		case "P4.":
			scoreP4 += extraScore;
			break;
		default:
			scorePC += extraScore;
			break;
		}
	}
	public void SetLastWinner(string player){
		lastWinner = player;
	}
	public void ResetTakenNamesList(){
		names.Clear ();
	}
	public string ConsultScore(float score){
		string player;
		if (score == scoreP1 && !names.Contains("One"))
			player = "One";
		else if (score == scoreP2 && !names.Contains("Two"))
			player = "Two";
		else if (score == scoreP3 && !names.Contains("Three"))
			player = "Three";
		else if (score == scoreP4 && !names.Contains("Four"))
			player = "Four";
		else
			player = "PC";
		names.Add (player);
		return player;
	}

	public void setGamePrefs(int _numOfPlayers,int _numOfGames){
		numOfGames = _numOfGames;
		numOfPlayers = _numOfPlayers;
		Debug.Log ("Setted numOfGames to " + numOfGames + " and numOfPlayers " + numOfPlayers);
	}
}
